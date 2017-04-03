using System;
using System.Collections.Generic;

using System.Text;
using JustinIO;
using SMS;
using System.Diagnostics;
using System.Threading;

namespace Alarm
{
    public class CallObj    //暂时做成类吧，看起来统一
        {
            public string phoneNumber;
            public string PortNum;
            public int BaudRate;
            public byte DataBits;
            public byte Parity; // 0-4=no,odd,even,mark,space 
            public byte StopBits; // 0,1,2 = 1, 1.5, 2 
            public int ReadTimeout;
        }
    public class CALL
    {
        private Thread Sendsms = null;
        private bool IsThreadOn = false;
        static JustinIO.CommPort ss_port = new JustinIO.CommPort();
        PDUdecoding sms = new PDUdecoding();

        public string PortNum;
        public int BaudRate;
        public byte DataBits;
        public byte Parity; // 0-4=no,odd,even,mark,space 
        public byte StopBits; // 0,1,2 = 1, 1.5, 2 
        public int ReadTimeout;
        

        Queue<CallObj> NormalPriority = new Queue<CallObj>();
        Queue<CallObj> HighPriority = new Queue<CallObj>();

        public void fillqueue(CallObj call, int Priority)
        {
            PortNum = call.PortNum;
            BaudRate = call.BaudRate;
            DataBits = call.DataBits;
            Parity = call.Parity;
            StopBits = call.StopBits;
            ReadTimeout = call.ReadTimeout;
            if (Priority == 1)
            {
                NormalPriority.Enqueue(call);
            }
            else
            {
                HighPriority.Enqueue(call);
            }


            if (!IsThreadOn)
            {
                IsThreadOn = true;
                Sendsms = new Thread(SendCallThread);
                Sendsms.Start();
            }

        }

        void SendCallThread()
        {

            while (true)
            {
                if (HighPriority.Count > 0)
                {
                    while (HighPriority.Count != 0)
                    {
                        Send(HighPriority.Peek());
                        HighPriority.Dequeue();

                    }
                }
                else
                {
                    Send(NormalPriority.Peek());
                    NormalPriority.Dequeue();
                }
                if (HighPriority.Count + NormalPriority.Count == 0)
                {
                    IsThreadOn = false;
                    break;
                }
            }

        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private bool InitCom(string portName, int BaudRate, byte databits, byte parity, byte stopBits, int ReadTimeout)
        {
            ss_port.PortNum = portName;
            ss_port.BaudRate = BaudRate;
            ss_port.ByteSize = databits;
            ss_port.Parity = parity;
            ss_port.StopBits = stopBits;
            ss_port.ReadTimeout = ReadTimeout;
            try
            {
                if (ss_port.Opened)
                {
                    ss_port.Close();
                    ss_port.Open();
                }
                else
                {
                    ss_port.Open();//打开串口
                }
                return true;
            }
            catch
                (Exception e)
            {
                //Console.WriteLine("{0} Exception caught.", e);
                throw e;
                return false;
            }
        }

        /// <summary>
        /// 打电话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Send(CallObj callobj)
        {
            bool opened = false;
            opened = InitCom(PortNum, BaudRate, DataBits, Parity, StopBits, ReadTimeout);
            if (opened)
            {
                ss_port.Write(Encoding.ASCII.GetBytes("ATD" + callobj.phoneNumber + ";\r"));//发送打电话指令
                Thread.Sleep(3000);
                ss_port.Close();
            }

        }
        
    }
}
