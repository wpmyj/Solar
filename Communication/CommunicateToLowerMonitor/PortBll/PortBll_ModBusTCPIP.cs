using System;
using System.Collections.Generic;

using System.Text;
using System.Timers;
using Model_Data;
using Model_Data.CommunicateEntity;

namespace Communication.CommunicateToLowerMonitor.PortBll
{
    //抽象端口实现类：MODBUS的TCP逻辑
    public class PortBll_ModBusTCPIP : AllPortBll
    {
        public String ModbusTcpErrorStr = null;//保存错误信息
        private BasicCommunicateClass.SocketWrapper socketWrapper = new BasicCommunicateClass.SocketWrapper();
        private short BusinessId = 0;


        public override bool Disconnect()
        {
            return socketWrapper.Disonnect();
        }

        public override bool Connect()
        {
            if (socketWrapper == null)
                return false;
            return socketWrapper.Connect();
        }
        public override bool ConnectState()
        {
            return socketWrapper.ConnectState();
        }
        public override bool SetParaMeter(CommSerialEntity SE)
        {
            return true;
        }
        public override bool SetParaMeter(CommTCPEntity SE)
        {
            return socketWrapper.SetTCPEntity(SE);
        }

        #region 取得要测量部分
        public override COMMUNICATERESULT GetData(DeviceBll Device, ref List<byte> AnalogDate, ref List<byte> DigitalData, ref List<string> CharacterData)
        {
            COMMUNICATERESULT ret = new COMMUNICATERESULT();
            ret = COMMUNICATERESULT.OK;
            byte[] SendCommand=null;
            byte[] RecByte = null;
            byte[] RecData=null;
            int BytesToRec = 0;
            foreach (CommandClass AnalogCommand in Device.Device.AnalogCommandList)
            {
                SendCommand=SetBusinessId(AnalogCommand.Command);
                BytesToRec = AnalogCommand.RecLen;
                ret = socketWrapper.SendAndReceive(SendCommand, BytesToRec, out RecByte);
                if (ret != COMMUNICATERESULT.OK)
                {
                    return ret;
                }
                ret=CheckData(RecByte, SendCommand);
                if (ret != COMMUNICATERESULT.OK)
                {
                    return ret;
                }
                RecData = GetRecDataFromRecByte(RecByte);
                AnalogDate.AddRange(RecData);
                    
            }
            foreach (CommandClass DigitalCommand in Device.Device.DigitalCommandList)
            {
                SendCommand = SetBusinessId(DigitalCommand.Command);
                BytesToRec = DigitalCommand.RecLen;
                ret = socketWrapper.SendAndReceive(SendCommand, BytesToRec, out RecByte);
                if (ret != COMMUNICATERESULT.OK)
                {
                    return ret;
                }
                ret = CheckData(RecByte, SendCommand);
                if (ret != COMMUNICATERESULT.OK)
                {
                    return ret;
                }
                RecData = GetRecDataFromRecByte(RecByte);
                DigitalData.AddRange(RecData);
            }
             
            return ret;
        }
        
        //设置事物元标示符
        private byte[] SetBusinessId( byte[] Command)
        {
            byte[] TempIdArray;
            TempIdArray = BitConverter.GetBytes(BusinessId);
            Command[0] = TempIdArray[0];
            Command[1] = TempIdArray[1];
            BusinessId++;
            return Command;
        }

        //计算模拟量回复帧的长度
        private int CalculateAnalogRecByteLen(byte[] Command)
        {
            if(Command.Length<12)
            {
                return 0;
            }
            short TemLen=BitConverter.ToInt16(Command,10);
            int Reclen = TemLen*2 + 9;
            return Reclen;

        }
        //计算数字量回复帧的长度
        private int CalculateDigitalRecByteLen(byte[] Command)
        {
            int Reclen;
            if (Command.Length < 12)
            {
                return 0;
            }
            short TemLen = BitConverter.ToInt16(Command, 10);
            if (TemLen % 8 > 0)
            {
                Reclen = (TemLen /8 +1)+ 9;
            }
            else
            {
                Reclen = TemLen / 8  + 9;
            }
            
            return Reclen;
        }

        //去掉包头取得有效数据
        private byte[] GetRecDataFromRecByte(byte[] RecByte)
        {
            List<byte> TemRecData = new List<byte>();
            if (RecByte.Length < 10)
            {
                return TemRecData.ToArray();
            }
            for (int i = 9; i < RecByte.Length; i++)
            {
                TemRecData.Add(RecByte[i]);
            }
            return TemRecData.ToArray();
        }

        //校验数据
        private COMMUNICATERESULT CheckData(byte[] RecData, byte[] SendData)
        {
            if (RecData[6] != SendData[6])
            {
                //校验第7位-单元标识位
                return COMMUNICATERESULT.FailUnitID;
            }

            if (RecData[0] != SendData[0] || RecData[1] != SendData[1])
            {
                //校验 事务元标志位
                return COMMUNICATERESULT.FailBussinessID;
            }
            if (RecData[2] != SendData[2] || RecData[3] != SendData[3])
            {
                //校验 协议标识位
                return COMMUNICATERESULT.UnknownFunCode;
            }
            if ((short)((((short)RecData[4]) << 8) + RecData[5]) == 3)
            {
                switch (RecData[8])
                {
                    case 1:
                        return COMMUNICATERESULT.UnknownFunCode;
                    case 2:
                        return COMMUNICATERESULT.DataAddrInvalid;
                    case 3:
                        return COMMUNICATERESULT.DataValueInvalid;
                    case 4:
                        return COMMUNICATERESULT.SeverErr;
                    case 5:
                        return COMMUNICATERESULT.ServerDelayOK;
                    case 6:
                        return COMMUNICATERESULT.ServerBusy;
                    case 10:
                        return COMMUNICATERESULT.GateWayFault_RoutingErr;
                    case 11:
                        return COMMUNICATERESULT.GateWayFault_Noresponse;
                    case 0xf1:
                        return COMMUNICATERESULT.DeviceNotExist;
                    case 0xf2:
                        return COMMUNICATERESULT.DeviceCommErrorOrClosed;
                    default:
                        return COMMUNICATERESULT.OtherModbusError;
                }

            }

            return COMMUNICATERESULT.OK;
        }
        #endregion

        #region 遥控量设置部分
        bool SetInfoTimeOutFlage = false;
        public override COMMUNICATERESULT SetData(CommandClass SetInfo)
        {
            int BytestoRec=12;
            byte[] RecBytes;
            byte[] SendCommand;
            COMMUNICATERESULT ret;
            SetSetDataTimeOutTimer();

            SendCommand = SetBusinessId(SetInfo.Command);

            /*while (socketWrapper.ConnectState())
            {
                if (SetInfoTimeOutFlage == 1)
                {
                    return COMMUNICATERESULT.Timeout;
                }
            }*/
            if (!socketWrapper.ConnectState())
            {
                if (socketWrapper.Connect())
                {
                    ret = socketWrapper.SendAndReceive(SendCommand, BytestoRec, out RecBytes);
                    if (ret == COMMUNICATERESULT.OK)
                    {
                        return CheckData(RecBytes, SendCommand);
                    }
                    else
                    {
                        return ret;
                    }

                }
                else
                {
                    return COMMUNICATERESULT.PortOpenFail;
                }
            }
            else
            {
                //SendCommand = SetBusinessId(SetInfo.ToArray());
                ret = socketWrapper.SendAndReceive(SendCommand, BytestoRec, out RecBytes);
                if (ret == COMMUNICATERESULT.OK)
                {
                    return CheckData(RecBytes, SendCommand);
                }
                else
                {
                    return ret;
                }
            }
        }

        private void SetSetDataTimeOutTimer()
        {
            Timer SetInfoTimer = new Timer();
            SetInfoTimeOutFlage = false;
            SetInfoTimer.Interval = 2000;
            SetInfoTimer.Elapsed +=new ElapsedEventHandler(SetInfoTimer_Elapsed);
            SetInfoTimer.Start();
        }

        private void SetInfoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer temptimer = (Timer)sender;
            temptimer.Stop();
            SetInfoTimeOutFlage = true;

        }
        #endregion

        //读取下位机 存储的历史报警数据----专用通道
        public override COMMUNICATERESULT GetBasicDataFromCommand(byte[] Cmd, ref byte[] RecData, int recLen)
        {
            COMMUNICATERESULT ret = new COMMUNICATERESULT();
            ret = COMMUNICATERESULT.OK;
            byte[] RecByte = null;

            ret = socketWrapper.SendAndReceive(Cmd, recLen, out RecByte);
                if (ret != COMMUNICATERESULT.OK)
                {
                    return ret;
                }
                ret = CheckData(RecByte, Cmd);
                if (ret != COMMUNICATERESULT.OK)
                {
                    return ret;
                }
                RecData = GetRecDataFromRecByte(RecByte);
           
            return ret;
        }

        #region IDisposable 成员
        private bool isDisposed = false;
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //通知GC:对象已经被销毁过，不用GC处理了
        }

        private void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    if (socketWrapper != null)
                    {
                        socketWrapper = null;
                    }
                }
            }
            isDisposed = true;
        }
        #endregion
    }
}
