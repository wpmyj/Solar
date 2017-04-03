using System;
using System.Collections.Generic;

using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Configuration;
using System.Threading;
using Model_Data;
using Model_Data.CommunicateEntity;

namespace Communication.BasicCommunicateClass
{
    //通讯基类：套接字通讯类
    class SocketWrapper : IDisposable
    {
        //实体字段部分
        public CommTCPEntity TCPPara = null;
        public String SockErrorStr = null;
        private Socket socket = null;
        private IPEndPoint ip = null;
        private AsyncCallback BeginConnectAsynCallback = null;
        private int comunicate = 0;

        private enum SocketConnectState
        {
            Connectting = 0,
            SendFail = 1,
            RecFail = 2,
            ConnectSuccess = 3,
            connectfail = 4
        }
        //连接，成功返回true，失败则把失败信息写入SockErrorStr，返回false
        private Boolean IsconnectSuccess = false;
        private Boolean IsconnectCallBack = true;//标志量，用于标志异步连接是否回调
        private SocketConnectState socketconnectstate = SocketConnectState.Connectting;//套接字连接状态记录值
        private ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public bool SetTCPEntity(CommTCPEntity TCPEntity)
        {
            TCPPara = TCPEntity;
            BeginConnectAsynCallback = new AsyncCallback(ConnectCallBack);
            return CreatSocket(TCPPara);
        }

        private bool CreatSocket(CommTCPEntity TCPEntity)
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, TCPEntity.WriteOverTime);//设置套接字发送超时
            if (TCPEntity.ReadOverTime > 200)
            {
                this.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, TCPEntity.ReadOverTime);//设置套接字接收超时
            }
            else
            {
                this.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 200);//设置套接字接收超时
            }
            ip = new IPEndPoint(IPAddress.Parse(TCPEntity.IP), TCPEntity.Port);//IP和Port "192.168.0.225"
            return true;
        }
        private IAsyncResult ar;
        //string filename = "socketconncetdebug.txt";
        public bool Connect()
        {
            TimeoutObject.Reset();
            comunicate++;
            //string outputstring="判断,socketconnectstate="+socketconnectstate.ToString()+"IsconnectCallBack="+IsconnectCallBack.Equals(true).ToString();
            //DebugHelp.WriteToFile.WriteToFileWithBG2313(outputstring, filename);

            if ((!ConnectState() && IsconnectCallBack) || comunicate > 20)
            {
                comunicate = 0;
                IsconnectSuccess = false;
                try
                {
                    this.socket.Disconnect(true);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("socket");

                }
                try
                {
                    //DebugHelp.WriteToFile.WriteToFileWithBG2313("beginsocket", filename);
                    ar = this.socket.BeginConnect(ip, BeginConnectAsynCallback, socket);
                    IsconnectCallBack = false;
                    //DebugHelp.WriteToFile.WriteToFileWithBG2313("IsconnectCallBack = false", filename);

                }
                catch (Exception err)
                {
                    //出现套接字已释放的异常则重新创建套接字
                    if (err is System.ObjectDisposedException)
                    {
                        CreatSocket(TCPPara);
                    }
                    SockErrorStr = err.ToString();
                    socketconnectstate = SocketConnectState.connectfail;
                    return false;
                }
                if (TimeoutObject.WaitOne(1000, false))
                {
                    if (IsconnectSuccess)
                    {
                        socketconnectstate = SocketConnectState.ConnectSuccess;
                        return true;
                    }
                    else
                    {
                        socketconnectstate = SocketConnectState.connectfail;
                        return false;
                    }
                }
                else
                {
                    SockErrorStr = "Time Out";
                    return false;
                }
            }
            else if (ConnectState())
            {
                return true;
            }
            else
            {
                SockErrorStr = "套接字没有赋值";
                return false;
            }
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            IsconnectCallBack = true;
            IsconnectSuccess = false;
            //DebugHelp.WriteToFile.WriteToFileWithBG2313("ConnectCallBack", filename);
            try
            {
                socket.EndConnect(ar);
                IsconnectSuccess = true;
                socketconnectstate = SocketConnectState.ConnectSuccess;
                //DebugHelp.WriteToFile.WriteToFileWithBG2313("socketconnectstate = SocketConnectState.ConnectSuccess;", filename);
            }
            catch (Exception ex)
            {
                string jj = "insideclose" + ex.ToString();
                //DebugHelp.WriteToFile.WriteToFileWithBG2313(jj, filename);
                socketconnectstate = SocketConnectState.connectfail;
                SockErrorStr = ex.ToString();
            }
            finally
            {
                TimeoutObject.Set();
            }
        }

        //断开连接，成功返回true，失败则把失败信息写入SockErrorStr，返回false
        public bool Disonnect()
        {
            try
            {
                this.socket.Shutdown(SocketShutdown.Both);
                this.socket.Disconnect(true);
                this.socket.Close();
            }
            catch (Exception err)
            {
                SockErrorStr = err.ToString();
                return false;
            }
            return true;
        }

        public bool ConnectState()
        {
            if (socket != null)
            {
                switch (socketconnectstate)
                {
                    case SocketConnectState.ConnectSuccess:
                    case SocketConnectState.RecFail:
                        return true;
                    default:
                        return false;
                }
                // return socket.Connected;
            }
            else
            {
                return false;
            }
        }

        //读取数据---直到有数据返回或者超时
        //输入参数：需要接收的数据个数
        //输出参数，实际接收到的数据个数
        private byte[] data = new byte[256];
        private byte[] Read(int length, out int ReadCount)
        {
            byte[] returndata = new byte[length];

            Array.Clear(data, 0, data.Length);
            try
            {
                ReadCount = this.socket.Receive(data);
                //--------------
                //调试用于输出到输出窗口
                // string result = String.Join(",", Array.ConvertAll(data, (Converter<byte, string>)Convert.ToString));
                //////DebugHelper.StringOut.OutputWindowStringWithTime(result);
                //------------------------
                if (ReadCount >= length)
                {
                    Array.Copy(data, returndata, length);
                    return returndata;
                }
                else if (ReadCount == 9)//9为错误响应的长度
                {
                    Array.Copy(data, returndata, 9);
                    return returndata;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ee)
            {
                socketconnectstate = SocketConnectState.RecFail;
                SockErrorStr = ee.ToString();
                //--------------
                //调试用于输出到输出窗口
                //DebugHelper.StringOut.OutputWindowStringWithTime(SockErrorStr);
                //------------------------
                ReadCount = 0;
                return null;
            }

        }

        //写数据
        private int sendcount = 0;
        private bool Write(byte[] data)
        {
            //-------------------
            //调试用于输出到输出窗口
            //string result = String.Join(",", Array.ConvertAll(data, (Converter<byte, string>)Convert.ToString));
            //DebugHelper.StringOut.OutputWindowStringWithTime(result);
            //----------------
            sendcount = 0;
            try
            {
                sendcount = this.socket.Send(data);
                if (sendcount == data.Length)
                {
                    return true;
                }
                else
                {
                    SockErrorStr = null;
                    return false;
                }
            }
            catch (Exception ee)
            {
                SockErrorStr = ee.ToString();
                //DebugHelper.StringOut.OutputWindowStringWithTime(SockErrorStr);
                socketconnectstate = SocketConnectState.SendFail;
                return false;
            }
        }

        //根据发送的报文 要求
        /// <summary>
        /// Send Data and Get Expected Data Back
        /// </summary>
        /// <param name="SendData">The Data to be sent and has been organized</param>
        /// <param name="_BytesToRec">expected datalength to receive</param>
        /// <param name="RetData">Buffer to store received data</param>
        /// <returns>Return MODBUSRESULT </returns>
        private int readcount = 0;
        public COMMUNICATERESULT SendAndReceive(byte[] SendData, int _BytesToRec, out byte[] RetData)
        {
            //COMMUNICATERESULT ret;
            readcount = 0;
            //int RSendNumber = 0;

            //while (true)
            //{
            RetData = null;
            if (socketconnectstate != SocketConnectState.SendFail)
            {
                if (Write(SendData))
                {
                    if (_BytesToRec > 0)
                    {
                        //读取数据
                        RetData = Read(_BytesToRec, out readcount);
                        if (RetData == null)
                        {
                            return COMMUNICATERESULT.DataRecFail;
                        }
                        else
                        {
                            socketconnectstate = SocketConnectState.ConnectSuccess;
                            return COMMUNICATERESULT.OK;
                        }
                    }
                    else
                    {
                        return COMMUNICATERESULT.OK;
                    }
                }
                else
                {
                    return COMMUNICATERESULT.DataSendFail;
                }
            }
            else
            {
                return COMMUNICATERESULT.DataSendFail;
            }
            //判断是否成功读取数据
            /* if (ret == COMMUNICATERESULT.OK)
             {
                 return ret;
             }
             else
             {
                 RSendNumber++;
                 if (RSendNumber >= 3)
                 {
                     //如果连续多次读取不成功，则清空超时次数
                     RSendNumber = 0;
                     return ret;
                 }
                    
             }*/
            //}
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
                    if (this.socket.Connected)
                    {
                        Disonnect();
                    }
                    if (this.socket != null)//手动销毁
                    {
                        ((IDisposable)this.socket).Dispose();
                    }
                    if (this.BeginConnectAsynCallback != null)
                    {
                        this.BeginConnectAsynCallback = null;
                    }
                }
            }
            isDisposed = true;

        }
        #endregion

    }
}
