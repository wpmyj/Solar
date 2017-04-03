using System;
using System.Collections.Generic;

using System.Text;
using System.Timers;
using Model_Data;
using Model_Data.CommunicateEntity;
using Communication;
using System.Data;
using System.Threading;

namespace Communication.CommunicateToLowerMonitor
{
    //端口类
    public class WrapperBll : IDisposable
    {
        //定义一个端口
        public AllPortBll PortBll;
        //端口实体
        public PortModel Port;
        //端口下的 设备类 列表
        public List<DeviceBll> DeviceList = new List<DeviceBll>();

        #region 添加一个标志位用标志端口是否在通讯中

        private ManualResetEvent mrEvent = new ManualResetEvent(true);

        private enum PortCommunicationState : int
        {
            InCommunicate = 0,
            OutOfCommunicate = 1
        }

        private PortCommunicationState CommunicateFlage = PortCommunicationState.OutOfCommunicate;

        #endregion

        //端口下的轮询定时器
        private System.Timers.Timer ReceiveTimer = new System.Timers.Timer();
        private object LockObject = new object();//用于通讯锁,防止轮询与设置命令发生粘包

        //构造函数
        public WrapperBll()
        {
            ReceiveTimer.Elapsed += ReceiveTimerEventHandler;
        }

        #region 轮询开始和结束

        /**停止轮询
         * 停止轮询定时器,但是不断开端口，也不清内存
         * 停止轮询后 某些状态位要还原----1.上次连接状态
         * **/
        public void StopPoll()
        {
            if (Port != null)
            {
                ReceiveTimer.Stop();
                //如果定时器还在执行，这里必须等待定时器执行完毕
                mrEvent.WaitOne(3000, false);
                PortBll.Disconnect();//关掉端口（如果是串口则释放串口）              
                PortBll.LastConnect = true;

                SetAllDeviceInition();//恢复设备初始状态
            }
        }

        //单机版 取消延时定时器，直接启动轮询定时器
        public void StartPoll()
        {
            if (ReceiveTimer == null)
                return;
            if (Port != null)
                ReceiveTimer.Interval = Port.ScanningTime;

            ReceiveTimerEventHandler(null, null);//让定时器立即执行一次
            ReceiveTimer.Start();
            //轮询开始后，设备数据存储定时器开启
            foreach (var item in DeviceList)
            {
                item.InsertToDBTimerStart();
            }
        }

        #endregion

        //创建命令帧
        public void CreatCommand()
        {
            foreach (DeviceBll Devbll in DeviceList)
            {
                CommandCreat.CreatDeviceCommandList(Port.PortType, Devbll);
            }
        }

        #region 读 下位机存储的 模拟量 历史告警 数据----add by alu


        //读下位机 历史告警数据
        public int GetHistoricRecordParameters(int DeviceListID, byte UnitID, ref short AddressStart, ref short PerRecordLen, ref short TotalLen, DataTable da)
        {
            //判断端口是否连接，如果没连接，则直接返回；否则关掉轮询定时器
            if (!this.PortBll.ConnectState())
                return -1;

            if (ReceiveTimer.Enabled)
            {
                ReceiveTimer.Stop();
            }
            System.Threading.Thread.Sleep(2000);

            try
            {
                //1.读下位机历史记录 存储状态
                short RecDataLen = 3 * 2 + 3;
                byte[] Cmd = CommandCreat.CreatOneModbusReadCommand(Port.PortType, UnitID, (byte)FunctionCode.ReadInputRegisters, (short)0x26, (short)3, ref RecDataLen);
                byte[] RecData = new byte[RecDataLen];
                PortBll.GetBasicDataFromCommand(Cmd, ref RecData, RecDataLen);
                //2.解析 存储状态
                TotalLen = (short)(RecData[0] * 256 + RecData[1]);
                PerRecordLen = (short)(RecData[2] * 256 + RecData[3]);//默认为5
                AddressStart = (short)(RecData[4] * 256 + RecData[5]);
                //3.判断历史记录是否存在，如果存在就读取，如果不存在继续读实时数据
                if (TotalLen == 0)
                {
                    return TotalLen;
                }
                else
                {
                    for (int i = 0; i < TotalLen; i++)
                    {
                        //每条基本MODBUS长度
                        RecDataLen = (short)(PerRecordLen * 2 + 3);//基本MODBUS为13
                        Cmd = CommandCreat.CreatOneModbusReadCommand(Port.PortType, UnitID, (byte)FunctionCode.ReadInputRegisters, (short)AddressStart, (short)PerRecordLen, ref RecDataLen);
                        byte[] RecData_record = new byte[RecDataLen];//TCP协议应该为19，串口协议为15
                        PortBll.GetBasicDataFromCommand(Cmd, ref RecData_record, RecDataLen);

                        //读完之后更改起始地址
                        AddressStart += 5;
                        //解析报警时间
                        DateTime dt = MathConvertHelper.BitConverter.BCDtoDate(RecData_record);
                        //解析报警量
                        int VarialbeID = RecData_record[6];//=信号ID-1（数字量从0开始）
                        bool Ishappen = RecData_record[7] == 0 ? false : true;//消失或者发生
                        string SignalName = DeviceList[DeviceListID].DigitalList[VarialbeID].DigitalInfo.SignalName;

                        //解析报警值
                        byte[] va = new byte[2];
                        va[0] = RecData_record[8];
                        va[1] = RecData_record[9];
                        int VA = MathConvertHelper.BitConverter.ToInt16Reverse(va);
                        //double value = VA * DeviceList[DeviceListID].AnalogList[VarialbeID].AnalogInfo.ScalingFactorA + DeviceList[DeviceListID].AnalogList[VarialbeID].AnalogInfo.ScalingFactorB;

                        //将 模拟量报警 抛出
                        string alarm_msg;
                        if (Ishappen)
                            alarm_msg = DeviceList[DeviceListID].DigitalList[VarialbeID].DigitalInfo.SignalName + " " + DeviceList[DeviceListID].DigitalList[VarialbeID].DigitalInfo.Value0_Describe;
                        else
                            alarm_msg = DeviceList[DeviceListID].DigitalList[VarialbeID].DigitalInfo.SignalName + " " + DeviceList[DeviceListID].DigitalList[VarialbeID].DigitalInfo.Value1_Describe; ;
                        da.Rows.Add(dt, SignalName, Ishappen, alarm_msg);
                        AlarmThrow(dt, VarialbeID + 1, alarm_msg);
                    }
                    return TotalLen;
                }
            }
            finally
            {
                ReceiveTimer.Start();
            }
        }

        //历史告警
        private void AlarmThrow(DateTime AlarmTime, int SignalID, string Alarmstr)
        {
            AlarmEntity alarm = new AlarmEntity();
            alarm.AlarmTime = AlarmTime;
            alarm.MessageStr = Alarmstr;
            alarm.OrigSource = AlarmEntity.AlarmSourceClass.DigitalSignal;
            alarm.SignalId = SignalID;
            ACCESSDBDAL.AccessServer.InsertAlarm(alarm.AlarmTime, alarm.MessageStr);
            if (PortAlarmDelegate != null)
            {
                PortAlarmDelegate.Invoke(alarm);
            }
        }

        #endregion

        #region 新增接口函数----add by alu

        //单次轮询----用于测试连接 0:通讯失败  >0:通讯正常  -1：端口打开失败 -2：端口不存在 -3：前次通讯未结束        
        public int PollTest()
        {
            if (PortBll == null || Port == null)
                return -2;
            //如果端口是连接的，就去轮询设备
            if (Connect())
            {
                try
                {
                    AnalogDataList.Clear();
                    DigitalDataList.Clear();
                    CharactorDataList.Clear();
                    COMMUNICATERESULT ret = PortBll.GetData(DeviceList[0], ref AnalogDataList, ref DigitalDataList, ref CharactorDataList);
                    if (ret == COMMUNICATERESULT.OK)
                        return 1;
                }
                catch (Exception ee)
                { }
            }
            return 0;
        }

        public bool Connect()
        {
            if (!PortBll.ConnectState())
            {
                if (PortBll.Connect())
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        //强制终止 读取数据 函数 时候，需要恢复 通讯标志位
        public void ReCommunication()
        {
            CommunicateFlage = PortCommunicationState.OutOfCommunicate;
        }

        #endregion

        #region 读取数据部分

        /**计时器触发响应函数
         * 轮询操作
         * 定时器自动重启
         * **/
        private void ReceiveTimerEventHandler(object sender, ElapsedEventArgs e)
        {
            if (PortBll == null || Port == null)
                return;
            if (CommunicateFlage == PortCommunicationState.OutOfCommunicate)
                CommunicateFlage = PortCommunicationState.InCommunicate;
            else
                return;
            mrEvent.Reset();
            //端口连接
            PortConnect();
            //判断端口状态是否改变，并在改变时抛出告警，改变标志位。
            CheckPortStateChang();

            //如果端口是连接的，就去轮询设备
            if (PortBll.ThisConnect)
            {
                for (short ListID = 0; ListID < DeviceList.Count; ListID++)
                {
                    if (DeviceList[ListID].Device.RecoverState)//当前设备状态为--连接许可，执行以下代码 
                    {
                        try
                        {
                            COMMUNICATERESULT ret = GetOneDeviceData(ListID);//读取一个设备的数据，并返回读取结果
                            CheckOneDeviceStateChange(ListID, ret);//判断该设备是否 通讯成功
                        }
                        catch (Exception ee)
                        {
                            string jj = ee.ToString();
                        }
                    }
                    else
                    {
                        CountAdd_SetRecoverState(ListID);
                    }
                }
            }
            else
            {
                SetAllDeviceToCommFail();
            }
            mrEvent.Set();
            CommunicateFlage = PortCommunicationState.OutOfCommunicate;
        }

        //端口连接
        private void PortConnect()
        {
            if (!PortBll.ConnectState())
            {
                if (PortBll.Connect())
                {
                    PortBll.ThisConnect = true;
                }
                else
                {
                    PortBll.ThisConnect = false;
                }
            }
            else
            {
                PortBll.ThisConnect = true;
            }
        }

        private void PortDisconnect()
        {
            int temp = 0;
            //连接不成功则连续试3次
            while (!PortBll.Disconnect())
            {
                if (++temp > 2)
                {
                    break;
                }
            }
        }

        //判断端口状态是否改变
        private void CheckPortStateChang()
        {
            //判断端口状态是否改变
            if (PortBll.ThisConnect != PortBll.LastConnect)
            {
                if (PortBll.ThisConnect == true)
                {
                    PortOpenAlarm(Model_Data.Language.AlarmClass.PortOpenSuccess, true);//打开成功
                }
                else if (PortBll.ThisConnect == false)
                {
                    PortOpenAlarm(Model_Data.Language.AlarmClass.PortOpenFail, false);//打开失败
                }
                PortBll.LastConnect = PortBll.ThisConnect;
            }
        }

        //取得一个设备的数据
        //用于暂存设备通讯的内容
        private List<byte> AnalogDataList = new List<byte>();
        private List<byte> DigitalDataList = new List<byte>();
        private List<string> CharactorDataList = new List<string>();
        private COMMUNICATERESULT GetOneDeviceData(int ListID)
        {
            COMMUNICATERESULT ret = COMMUNICATERESULT.OtherError;
            AnalogDataList.Clear();
            DigitalDataList.Clear();
            CharactorDataList.Clear();

            //读取数据部分
            lock (LockObject)
            {
                ret = PortBll.GetData(DeviceList[ListID], ref AnalogDataList, ref DigitalDataList, ref CharactorDataList);
            }

            //存储数据
            if (ret == COMMUNICATERESULT.OK)
            {
                if (!DeviceList[ListID].UpdateAnalogListData(AnalogDataList.ToArray()))
                {
                    //告警，模拟量存储错误
                }

                //将状态量数据写入LIST中
                if (!DeviceList[ListID].UpdateDigitalListData(DigitalDataList.ToArray()))
                {
                    //告警，状态量存储错误
                }
            }

            return ret;
        }

        //判断一个设备通讯状态变化的函数。
        private void CheckOneDeviceStateChange(int ListID, COMMUNICATERESULT ret)
        {
            if (ret == COMMUNICATERESULT.OK)
            {
                DeviceList[ListID].Device.RecoverState = true;
                DeviceList[ListID].Device.ComState = DivCommStateEnum.Success;
                if ((DeviceList[ListID].Device.RecoverCounter > Port.ReconnectNumber) && (DeviceList[ListID].LastConnect == false))
                {
                    DevCommAlarm(ListID, Model_Data.Language.AlarmClass.CommResume, ret, true);//zq
                    DeviceList[ListID].LastConnect = true;
                }
                DeviceList[ListID].Device.RecoverCounter = 1;
            }
            else
            {
                if ((DeviceList[ListID].Device.RecoverCounter == Port.ReconnectNumber) && (DeviceList[ListID].LastConnect == true))
                {
                    DeviceList[ListID].Device.ComState = DivCommStateEnum.Failed;
                    DeviceList[ListID].Device.RecoverState = false;
                    DevCommAlarm(ListID, Model_Data.Language.AlarmClass.CommFail, ret, false);//zq
                    DeviceList[ListID].LastConnect = false;
                }
                DeviceList[ListID].Device.RecoverCounter++;
            }
        }

        //重连计数并在一定条件下把连接允许状态位置位
        private void CountAdd_SetRecoverState(int ListID)
        {
            if (DeviceList[ListID].Device.RecoverCounter % DeviceList[ListID].Device.ReconnectCount == 0)
            {
                DeviceList[ListID].Device.RecoverState = true;
            }
            DeviceList[ListID].Device.RecoverCounter++;
        }

        //把端口下所有设备的通讯状态置为false
        private void SetAllDeviceToCommFail()
        {
            for (short ListID = 0; ListID < DeviceList.Count; ListID++)
            {
                DeviceList[ListID].Device.ComState = DivCommStateEnum.Failed;
            }
        }

        //恢复端口下所有设备到初始状态----add by ALU
        private void SetAllDeviceInition()
        {
            for (short ListID = 0; ListID < DeviceList.Count; ListID++)
            {
                DeviceList[ListID].Device.ComState = DivCommStateEnum.Connecting;
                DeviceList[ListID].Device.RecoverState = true;//重连状态
                DeviceList[ListID].Device.RecoverCounter = 1;//重连计数
                DeviceList[ListID].LastConnect = true;
            }

        }

        #endregion

        #region 遥控量设置部分

        public DelegateEntity.SetInfoMethod SetInfoResultMethod;

        public void SetDivInfo(Object Object)
        {
            CommDeviceModbuseControlEntity tempEntity = new CommDeviceModbuseControlEntity();
            COMMUNICATERESULT ret = new COMMUNICATERESULT();
            byte[] tempbyte = new byte[2];
            CommandClass OneSetCommand;
            List<CommandClass> SetCommandList = new List<CommandClass>();
            if (ReceiveTimer.Enabled)
            {
                ReceiveTimer.Stop();
            }
            try
            {
                if (Object is CommDeviceModbuseControlEntity)
                {
                    tempEntity = (CommDeviceModbuseControlEntity)Object;
                    if ((Port.PortType == Protocol.Modbus_USBPort)) //USB端口Modbus协议特殊处理
                    {
                        SetCommandList = CommandCreat.CreatModbusSetDivInfoCommandList(Port.PortType, (byte)tempEntity.DivID, tempEntity.functioncode, tempEntity.SetData, tempEntity.SetInfoStartAdr, tempEntity.RegisterLen);
                        lock (LockObject)
                        {
                            ret = PortBll.SetData(SetCommandList);
                        }
                    }
                    else
                    {
                        switch (Port.PortType)
                        {
                            case Protocol.Modbus_SerialPort:
                            case Protocol.Modbus_TCPIPPort:
                                OneSetCommand = CommandCreat.CreatModbusSetDivInfoCommand(Port.PortType, (byte)tempEntity.DivID, tempEntity.functioncode, tempEntity.SetData, tempEntity.SetInfoStartAdr, tempEntity.RegisterLen);
                                break;
                            default:
                                OneSetCommand = CommandCreat.CreatModbusSetDivInfoCommand(Port.PortType, (byte)tempEntity.DivID, tempEntity.functioncode, tempEntity.SetData, tempEntity.SetInfoStartAdr, tempEntity.RegisterLen);
                                break;
                        }
                        lock (LockObject)
                        {
                            ret = PortBll.SetData(OneSetCommand);
                        }
                    }
                    if (ret == COMMUNICATERESULT.OK)
                    {
                        tempEntity.IsSuccess = true;
                    }
                }
            }
            finally
            {
                ReceiveTimer.Start();
            }
            switch (Port.PortType)//只有在Modbus协议通讯时才返回通讯结果
            {
                case Protocol.Modbus_SerialPort:
                case Protocol.Modbus_TCPIPPort:
                case Protocol.Modbus_USBPort:
                    if (SetInfoResultMethod != null)
                    {
                        SetInfoResultMethod.Invoke(tempEntity);
                    }
                    break;
            }
        }

        public void sendCommand(CommDeviceModbuseControlEntity obj)
        {
            COMMUNICATERESULT ret = new COMMUNICATERESULT();
            byte[] tempbyte = new byte[2];
            CommandClass OneSetCommand;
            List<CommandClass> SetCommandList = new List<CommandClass>();
            bool isEnabled = ReceiveTimer.Enabled;
            if (isEnabled)
                ReceiveTimer.Stop();
            try
            {
                if ((Port.PortType == Protocol.Modbus_USBPort)) //USB端口Modbus协议特殊处理
                {
                    SetCommandList = CommandCreat.CreatModbusSetDivInfoCommandList(Port.PortType, (byte)obj.DivID, obj.functioncode, obj.SetData, obj.SetInfoStartAdr, obj.RegisterLen);
                    lock (LockObject)
                    {
                        ret = PortBll.SetData(SetCommandList);
                    }
                }
                else
                {
                    OneSetCommand = CommandCreat.CreatModbusSetDivInfoCommand(Port.PortType, (byte)obj.DivID, obj.functioncode, obj.SetData, obj.SetInfoStartAdr, obj.RegisterLen);
                    lock (LockObject)
                    {
                        ret = PortBll.SetData(OneSetCommand);
                    }
                }
                obj.IsSuccess = ret == COMMUNICATERESULT.OK ? true : false;
            }
            finally
            {
                if (isEnabled)
                    ReceiveTimer.Start();
            }
        }

        #endregion

        #region 告警委托部分

        public DelegateEntity.AlarmDelegate PortAlarmDelegate = null;
        //设置设备委托的接收函数
        public void SetDeviceDelegate()
        {
            for (int ListID = 0; ListID < DeviceList.Count; ListID++)
            {
                DeviceList[ListID].DeviceAlarmDelegate = DeviceAlarmFunction;
            }
        }

        /**设备委托的接收函数
         * 端口接收设备发送的报警后，继续向上抛
         * **/
        private void DeviceAlarmFunction(AlarmEntity alarm)
        {
            alarm.MessageStr = Port.PortName + " " + alarm.MessageStr;
            ACCESSDBDAL.AccessServer.InsertAlarm(alarm.AlarmTime, alarm.MessageStr);
            if (PortAlarmDelegate != null)
            {
                PortAlarmDelegate.Invoke(alarm);
            }
        }

        /**设备告警函数
         * 如果是端口下 设备发生故障，则触发设备告警
         * **/
        private void DevCommAlarm(int alarmListID, string Alarmstr, COMMUNICATERESULT ret, bool state)
        {
            AlarmEntity alarm = new AlarmEntity();
            alarm.MessageStr = Port.PortName + " " + DeviceList[alarmListID].Device.DeviceName + " " + Alarmstr + ":" + ret.ToString();
            alarm.OrigSource = AlarmEntity.AlarmSourceClass.Device;
            alarm.Success = state;
            ACCESSDBDAL.AccessServer.InsertAlarm(alarm.AlarmTime, alarm.MessageStr);
            if (PortAlarmDelegate != null)
            {
                PortAlarmDelegate.Invoke(alarm);
            }
        }

        /**端口告警函数
         * 填充好告警消息
         * 端口发生告警后，也将告警消息 向上抛
         * **/
        private void PortOpenAlarm(string Alarmstr, bool success)
        {
            AlarmEntity alarm = new AlarmEntity();
            //alarm.MessageStr = "端口" + Port.PortName + " " + Alarmstr;
            alarm.MessageStr = Model_Data.Language.AlarmClass.Port + Port.PortName + " " + Alarmstr;//"端口XX打开成功/失败"//zq
            alarm.OrigSource = AlarmEntity.AlarmSourceClass.Port;
            alarm.Success = success;
            ACCESSDBDAL.AccessServer.InsertAlarm(alarm.AlarmTime, alarm.MessageStr);
            if (PortAlarmDelegate != null)
            {
                PortAlarmDelegate.Invoke(alarm);
            }
        }

        #endregion

        #region 析构函数

        private bool isDisposed = false;
        public void Dispose()
        {
            PortDisconnect();
            Dispose(true);
            GC.SuppressFinalize(this); //通知GC:对象已经被销毁过，不用GC处理了
        }

        private void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    DisposePort();
                    DisposeDeviceList();
                }
            }
            isDisposed = true;
        }

        public void DisposeTimer()
        {
            if (ReceiveTimer == null)
                return;
            if (ReceiveTimer.Enabled)
            {
                ReceiveTimer.Stop();
            }
            if (ReceiveTimer != null)
            {
                ReceiveTimer.Dispose();
                ReceiveTimer = null;
            }


            foreach (DeviceBll Device in DeviceList)
            {
                if (Device != null)
                {
                    Device.DisposeTimer();
                }
            }

        }

        private void DisposePort()
        {
            if (this.PortBll != null)
            {
                PortBll.Dispose();
            }
        }

        private void DisposeDeviceList()
        {
            foreach (DeviceBll Device in DeviceList)
            {
                if (Device != null)
                {
                    Device.Dispose();
                }
            }
            DeviceList.Clear();
        }

        #endregion.

    }
}
