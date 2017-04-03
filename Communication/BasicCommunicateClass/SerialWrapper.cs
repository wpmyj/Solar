using System;
using System.Collections.Generic;

using System.Text;
using System.Configuration;
using System.Timers;
using System.IO.Ports;
using System.Diagnostics;
using Model_Data;
using Model_Data.CommunicateEntity;
namespace Communication.BasicCommunicateClass
{
    class SerialWrapper:IDisposable
    {
        public CommSerialEntity SerialEntity;
        private SerialPort sp = new SerialPort();
        public string modbusStatus;

        private bool IsReceiveTimeout = false;
        private Timer ReceiveTimer = new Timer();

        public SerialWrapper()
        {

        }

        public bool SetSerialPara(CommSerialEntity Entity)
        {
            try
            {
                SerialEntity = Entity;

                //设置串口的相关配置
                sp.PortName = SerialEntity.PortName;
                sp.BaudRate = SerialEntity.BaudRate;
                sp.DataBits = SerialEntity.DataBit;
                sp.Parity = SerialEntity.Parity;
                sp.StopBits = SerialEntity.StopBit;
                sp.ReadTimeout = SerialEntity.ReadOverTime;
                sp.WriteTimeout = SerialEntity.WriteOverTime;
                sp.RtsEnable = true;
            }
            catch (Exception ee)
            {
                modbusStatus = ee.ToString();
                return false;
            }
            CreatWaitTimer();
            return true;
        }


        #region 数据接收等待计时器操作

        private void CreatWaitTimer()
        {
            ReceiveTimer.Elapsed += new ElapsedEventHandler(ReceiveTimer_Elapsed);
            ReceiveTimer.Interval = SerialEntity.RecoveryWaitTime;
            ReceiveTimer.AutoReset = false;
        }


        private void ReceiveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            IsReceiveTimeout = true;
            Timer mt = (Timer)sender;
            mt.Stop();
            
        }
        #endregion

        #region 端口打开关闭部分
        public bool Connect()
        {

            if (!sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception ee)
                {
                    modbusStatus = SerialEntity.PortName + ee.ToString();
                }
                try
                {
                    sp.Open();
                }
                catch (Exception ee)
                {
                    modbusStatus = SerialEntity.PortName + ee.ToString();
                    return false;
                }
                modbusStatus = SerialEntity.PortName + " opened successfully";
                return true;
            }
            else
            {
                modbusStatus = SerialEntity.PortName + " already opened";
                return true;
            }
        }

        public bool Disonnect()
        {
            if (sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception err)
                {
                    modbusStatus = "Error closing " + sp.PortName + ": " + err.Message;
                    return false;
                }
                modbusStatus = sp.PortName + " closed successfully";
                return true;
            }
            else
            {
                modbusStatus = sp.PortName + " is not open";
                return true;
            }

        }
        #endregion

        public bool ConnectState()
        {
            if (sp != null)
            {
                return sp.IsOpen;
            }
            else
            {
                return false;
            }
        }

        public COMMUNICATERESULT SendAndReceive(byte[] bt, int BytesToRec, out byte[] RetData)
        {
            byte[] SendData = bt;
            byte[] ReadData = new byte[1000];
            RetData = new byte[BytesToRec];
            //发送前先清空接收缓存区
            try
            {
                while (sp.BytesToRead > 0)
                {
                    sp.Read(ReadData, 0, 256);
                }
                sp.Write(SendData, 0, SendData.Length);
                if (BytesToRec > 0)
                {
                    IsReceiveTimeout = false;
                    ReceiveTimer.Start();
                    ////DebugHelper.StringOut.OutputWindowStringWithTime("read");
                    while (IsReceiveTimeout == false)
                    {
                        try
                        {
                            if (sp.BytesToRead >= BytesToRec)
                            {
                                sp.Read(ReadData, 0, sp.BytesToRead);
                                Array.Copy(ReadData, RetData, BytesToRec);
                                ReceiveTimer.Stop();
                                break;
                            }
                        }
                        catch (Exception ee)
                        {
                            string str = ee.ToString();
                        }
                    }
                    if (IsReceiveTimeout == true)
                    {
                        return COMMUNICATERESULT.Timeout;
                    }
                }
                else
                {
                    return COMMUNICATERESULT.OK;
                }
            }
            catch (Exception ee)
            {
                modbusStatus = sp.PortName + ee.ToString();
                return COMMUNICATERESULT.DataSendFail;
            }
            return COMMUNICATERESULT.OK;

        }

        #region IDisposable 成员
        private bool isDisposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //通知GC:对象已经被销毁过，不用GC处理了
        }

        public void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    if (this.sp.IsOpen)
                    {
                        this.sp.Close();
                    }
                    if (this.sp != null)
                    {
                        this.sp = null;
                    }
                }
            }
            isDisposed = true;
        }
        #endregion
    }
}
