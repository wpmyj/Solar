using System;
using System.Collections.Generic;

using System.Text;
using JustinIO;
using SMS;
using System.Diagnostics;
using System.Threading;

namespace Alarm
{
    public class SmsObj
    {
        public List<string> phoneNumbers = new List<string>();
        public string smsContent;
        public string portName;//串口名
        public int BaudRate;//波特率
        public byte databits = 8;//数据位
        public byte parity = 0;//奇偶校验
        public byte stopBits = 1;//停止位
        public int ReadTimeout = 10000;//读超时
    }
    public class SMS
    {
        //Parameters.SerialParameter sp = new Parameters.SerialParameter();
        private Thread Sendsms = null;
        public bool IsThreadOn = false;
        static JustinIO.CommPort ss_port = new JustinIO.CommPort();
        PDUdecoding sms = new PDUdecoding();


        

        private string portName;//串口名
        private int BaudRate;//波特率
        private byte databits = 8;//数据位
        private byte parity = 0;//奇偶校验
        private byte stopBits = 1;//停止位
        private int ReadTimeout = 30000;//读超时


        string CenterNumber = null;
        Queue<SmsObj> NormalPriority = new Queue<SmsObj>();
        Queue<SmsObj> HighPriority = new Queue<SmsObj>();

        public void fillqueue(SmsObj sms, int Priority)
        {
            portName = sms.portName;
            BaudRate = sms.BaudRate;
            databits = sms.databits;
            parity = sms.parity;
            stopBits = sms.stopBits;
            ReadTimeout = sms.ReadTimeout;
            if (Priority == 1)
            {
                NormalPriority.Enqueue(sms);

            }
            else
            {
                HighPriority.Enqueue(sms);
            }

            //IsThreadOn = !IsThreadOn;
            if (!IsThreadOn)
            {
                IsThreadOn = true;
                Sendsms = new Thread(SendSmsThread);
                Sendsms.Start();
            }

        }

        void SendSmsThread()
        {
           
            bool opened = false;
            if (HighPriority.Count + NormalPriority.Count > 0)
            {
                opened = InitCom(portName, BaudRate, databits, parity, stopBits, ReadTimeout);
                try
                {
                    if (opened)
                    {
                        //Debug.WriteLine("获取短信中心号前时间——" + DateTime.Now.ToString());
                        ss_port.Write(Encoding.ASCII.GetBytes("AT+CSCA?\r"));//获取手机短信中心号
                        string getresponse = Encoding.ASCII.GetString(ss_port.Read(128));
                        if (getresponse.Length > 0)
                        {
                            CenterNumber = getresponse.Substring(20, 13);
                            //Connected = true;
                        }
                        else
                        {
                            //Connected = false;
                            return;
                        }
                        //Debug.WriteLine(CenterNumber);
                        while (HighPriority.Count + NormalPriority.Count >0)
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
                            //Thread.Sleep(1000);
                            if (HighPriority.Count + NormalPriority.Count == 0)
                            {
                                //IsThreadOn = false;
                                ss_port.Close();
                                break;
                            }
                        }
                        IsThreadOn = false;
                    }
                }
                catch (Exception e)
                {
                    throw e;

                }
                //Debug.WriteLine("获取短信中心号后时间——" + DateTime.Now.ToString());
            }
            
            IsThreadOn = false;
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        public bool InitCom(string portName, int BaudRate, byte databits, byte parity, byte stopBits, int ReadTimeout)
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
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Send(object sender, System.EventArgs e)
        public void Send(SmsObj smsobj)
        {
            //Debug.WriteLine("发送前时间——" + DateTime.Now.ToString());

            foreach (string phoneNumber in smsobj.phoneNumbers)
            {
                //Debug.WriteLine("发送信息前时间——" + DateTime.Now.ToString());
                string decodedSMS = sms.smsDecodedsms(CenterNumber, phoneNumber, smsobj.smsContent);
                byte[] buf = null;
                buf = Encoding.ASCII.GetBytes(String.Format("AT+CMGS={0}\r", sms.nLength));
                while (ss_port.Read(128).Length>0)
                {
                }
                ss_port.Write(buf);
                Thread.Sleep(5000);
                string response = null;
                response = Encoding.ASCII.GetString(ss_port.Read(128));
                string SendState = "";
                if (response.Length > 0 && response.EndsWith("> "))
                {
                    ss_port.Write(Encoding.ASCII.GetBytes(String.Format("{0}\x01a", decodedSMS)));
                    SendState = "发送成功!";
                }
                else
                {
                    SendState = "发送失败";

                }
                //Debug.WriteLine(SendState);
                Thread.Sleep(5000);
                //Debug.WriteLine("发送信息后时间——" + DateTime.Now.ToString());
            }

            //Debug.WriteLine("发送后时间——" + DateTime.Now.ToString());
        }
    }

}
