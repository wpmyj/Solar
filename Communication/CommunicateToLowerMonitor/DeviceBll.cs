using System;
using System.Collections.Generic;
using System.Text;
using Model_Data;
using Model_Data.CommunicateEntity;
using System.Timers;
using System.Data;

namespace Communication.CommunicateToLowerMonitor
{
    public class DeviceBll : IDisposable
    {
        public CommDeviceEntity Device = new CommDeviceEntity();
        public List<AnalogBll> AnalogList = new List<AnalogBll>();
        public List<DigitalBll> DigitalList = new List<DigitalBll>();

        public bool LastConnect = true;

        private Timer InsertToDBTimer = new Timer();
        public DelegateEntity.AlarmDelegate DeviceAlarmDelegate;

        public string ErrorInfo;

        public DeviceBll()
        {
            InsertToDBTimer.Elapsed += new ElapsedEventHandler(Insert2DBresponse);

            InsertToDBTimer.AutoReset = true;
        }

        #region 插入数据库定时器操作

        //插入数据库定时器启动
        public void InsertToDBTimerStart()
        {      
            InsertToDBTimer.Interval = Device.write2DBInterval;
            InsertToDBTimer.Start();
        }
        //插入数据库定时器停止
        public void InsertToDBTimerStop()
        {
            InsertToDBTimer.Stop();
        }

        private void Insert2DBresponse(object sender, ElapsedEventArgs e)
        {
            if (Device.ComState == DivCommStateEnum.Success)
            {
                List<int> ids = new List<int>();
                List<string> values = new List<string>();
                foreach (AnalogBll item in AnalogList)
                {
                    if (!item.AnalogInfo.ISRecord)
                        continue;
                    ids.Add(item.AnalogInfo.SignalId);
                    //if (item.AnalogInfo.SignalType=="decimal(18,2)")
                    //{
                    //解决在某些语言下面 23.4 中的 点号变成 逗号，导致插入数据失败    
                    //}
                    //System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                    //nfi.NumberDecimalSeparator = ".";
                    
                    string a = item.AnalogInfo.Value.ToString();
                    values.Add(item.AnalogInfo.Value.ToString());
                }
                string TableName = Device.AnalogSignalValueTableName;
                ACCESSDBDAL.AccessServer.InsertData(TableName, ids, values);
            }
        }

        #endregion

        //更新模拟量到内存
        public bool UpdateAnalogListData(byte[] AnalogData)
        {
            int startaddress = 0;
            foreach (var item in AnalogList)
            {
                try
                {
                    Byte[] Data2Send = new Byte[item.AnalogInfo.DataLen];
                    for (int i = 0; i < item.AnalogInfo.DataLen; i++)
                    {
                        Data2Send[i] = (byte)AnalogData[startaddress + i];

                    }
                    item.UpdataOneAnalogData(Data2Send);
                    startaddress += item.AnalogInfo.DataLen;
                }
                catch (Exception ee)
                {
                    ErrorInfo = ee.ToString();
                    return false;
                }
            }
            return true;
        }

        //更新数字量到内存
        public bool UpdateDigitalListData(byte[] DigitalData)
        {
            int IndexInArray = -1;
            int IndexInByte = 0;
            int tempdata;
            bool IsStartAdr = true;//前一数字量与当前数字量是否连续的标志
            foreach (DigitalBll item in DigitalList)
            {
                if (IsStartAdr)
                {
                    IndexInArray++;
                    IndexInByte = 0;
                }
                else
                {
                    IndexInArray += IndexInByte / 8;
                    IndexInByte = IndexInByte % 8;
                }
                tempdata = (DigitalData[IndexInArray] & (0x01 << IndexInByte)) >> IndexInByte;
                try
                {
                    item.UpdataOneDigitalData(tempdata);
                }
                catch (Exception ee)
                {
                    ErrorInfo = ee.ToString();
                    return false;
                }

                IsStartAdr = !item.DigitalInfo.ISContinuous;
                IndexInByte++;
            }
            return true;
        }

        //告警的委托函数
        private void AlarmFunction(AlarmEntity alarm)
        {
            alarm.MessageStr = Device.DeviceName + " " + alarm.MessageStr;
            if (DeviceAlarmDelegate != null)
            {
                DeviceAlarmDelegate.Invoke(alarm);
            }
        }

        //设置信号告警的响应函数
        public void SetSignalAlarmDelegate()
        {
            foreach (AnalogBll analog in AnalogList)
            {
                analog.AnalogAlarmMethod = AlarmFunction;
            }
            foreach (DigitalBll digital in DigitalList)
            {
                digital.DigitalAlarmMethod = AlarmFunction;
            }
        }

        #region 析构函数
        private bool isDisposed = false;
        public void Dispose()
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
                    DisposeList();
                }
            }
            isDisposed = true;
        }

        public void DisposeTimer()
        {
            if (InsertToDBTimer.Enabled)
            {
                InsertToDBTimer.Stop();
            }
            if (InsertToDBTimer != null)
            {
                InsertToDBTimer.Dispose();
                InsertToDBTimer = null;
            }
        }
        private void DisposeList()
        {
            Device = null;
            AnalogList.Clear();
            DigitalList.Clear();
        }
        #endregion

    }
}
