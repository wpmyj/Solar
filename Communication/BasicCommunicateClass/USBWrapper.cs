using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Timers;
using Model_Data.CommunicateEntity;
using System.Threading;
namespace Communication.BasicCommunicateClass
{

    class USBWrapper : Win32USB, IDisposable
    {
        /// <summary> USB的厂商Id </summary>
        private static int nVid=01;
        /// <summary> USB的产品Id </summary>
        private static int nPid = 0;
        /// <summary>Handle to the device</summary>
        private static IntPtr m_hHandle = IntPtr.Zero;
        /// <summary>Filestream we can use to read/write from</summary>
        private static FileStream m_oFile = null;

        /// <summary> USB一次读数据的长度</summary>
        private static int m_nInputReportLength = 9;
        /// <summary>USB一次写数据的长度 </summary>
        private static int m_nOutputReportLength = 9;

        /// <summary>HId设备是否存在的标志</summary>
        private static bool HidExist = false;

        /// <summary>
        /// 设置USB信息
        /// </summary>
        /// <param name="Vid">USB的厂商Id </param>
        /// <param name="Pid">USB的产品Id</param>
        /// <returns></returns>
        public static bool SetUSBInfo(int Vid,int Pid)
        {
            nVid = Vid;
            nPid = Pid;
            return true;
        }
        /// <summary>
        /// 返回USB连接状态
        /// </summary>
        /// <returns></returns>
        public static bool USBConnectState()
        {
            return HidExist;
        }

        /// <summary>
        /// 连接USB设备的函数
        /// </summary>
        /// <returns>成功连接则返回OK，否则返回连接失败原因</returns>
        public static COMMUNICATERESULT connect()
        {
            COMMUNICATERESULT ret;
            string strPath = string.Empty;
            string strSearch = string.Format("vid_{0:x4}&pid_{1:x4}", nVid, nPid); // first, build the path search string
            Guid gHid = HIDGuid;
            IntPtr hInfoSet = SetupDiGetClassDevs(ref gHid, null, IntPtr.Zero, DIGCF_DEVICEINTERFACE | DIGCF_PRESENT);	// this gets a list of all HID devices currently connected to the computer (InfoSet)
            
            try
            {
                DeviceInterfaceData oInterface = new DeviceInterfaceData();	// build up a device interface data block
                oInterface.Size = Marshal.SizeOf(oInterface);
                // Now iterate through the InfoSet memory block assigned within Windows in the call to SetupDiGetClassDevs
                // to get device details for each device connected
                int nIndex = 0;
                while (SetupDiEnumDeviceInterfaces(hInfoSet, 0, ref gHid, (uint)nIndex, ref oInterface))	// this gets the device interface information for a device at index 'nIndex' in the memory block
                {
                    string strDevicePath = GetDevicePath(hInfoSet, ref oInterface);	// get the device path (see helper method 'GetDevicePath')

                    if (strDevicePath.IndexOf(strSearch) >= 0)	// do a string search, if we find the VID/PID string then we found our device!
                    {
                        ret=InitialiseFile(strDevicePath);
                        if (ret == COMMUNICATERESULT.OK)
                        {
                            HidExist = true;
                        }
                        else
                        {
                            HidExist = false;
                        }
                        return ret;
                    }
                    nIndex++;	// if we get here, we didn't find our device. So move on to the next one.
                }
            }
            catch (Exception )
            {
                HidExist = false;
                return COMMUNICATERESULT.USB_Exception;
            }
            finally
            {
                // Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
                SetupDiDestroyDeviceInfoList(hInfoSet);
            }
            HidExist = false;
            return COMMUNICATERESULT.USB_NeverFoundDevice;
        }


        /// <summary>
        /// 发送命令并返回接收到的数据的函数
        /// </summary>
        /// <param name="SendData">需要发送的数组</param>
        /// <param name="BytesToRec">需要接收的字节个数</param>
        /// <param name="RetData">接收到的数据暂存区</param>
        /// <returns>通讯成功返回OK，否则返回失败原因</returns>
        public static COMMUNICATERESULT SendAndReceive(byte[] SendData, int BytesToRec, out byte[] RetData)
        {
            RetData = new byte[BytesToRec];
            COMMUNICATERESULT ret = new COMMUNICATERESULT();
            //发送命令
            ret = WriteData(SendData);
            if (ret != COMMUNICATERESULT.OK)
            {
                return ret;
            }
            //读取回复
            ret = ReadData(BytesToRec, ref RetData);
            if (ret != COMMUNICATERESULT.OK)
            {
                return ret;
            }
            return ret;
        }

        /// <summary>
        /// 创建文件和文件流
        /// </summary>
        /// <param name="strPath">创建文件的路径</param>
        /// <returns>成功创建则返回OK，失败则返回失败原因</returns>
        private static COMMUNICATERESULT InitialiseFile(string strPath)
        {
            //创建文件，返回句柄
            IntPtr temphandle = CreateFile(strPath, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);
            if (temphandle != InvalidHandleValue && temphandle != IntPtr.Zero)	// if the open worked...
            {
                try
                {
                    //创建文件流
                    m_hHandle = temphandle;
                    m_oFile = new FileStream(new SafeFileHandle(m_hHandle, false), FileAccess.Read | FileAccess.Write, m_nInputReportLength, true);
                    BeginAsyncRead();
                }
                catch (Exception)
                {
                    return COMMUNICATERESULT.USB_CreatFileStreamFail;
                }
            }
            else	// File open failed? 
            {
                if (m_hHandle ==IntPtr.Zero)//USB端口是否已经被本程序使用？
                {
                    return COMMUNICATERESULT.USB_CreateDeviceFileFail;
                }
            }
            return COMMUNICATERESULT.OK;
        }

        /// <summary>
        /// Helper method to return the device path given a DeviceInterfaceData structure and an InfoSet handle.
        /// Used in 'FindDevice' so check that method out to see how to get an InfoSet handle and a DeviceInterfaceData.
        /// </summary>
        /// <param name="hInfoSet">Handle to the InfoSet</param>
        /// <param name="oInterface">DeviceInterfaceData structure</param>
        /// <returns>The device path or null if there was some problem</returns>
        private static string GetDevicePath(IntPtr hInfoSet, ref DeviceInterfaceData oInterface)
        {
            uint nRequiredSize = 0;
            // Get the device interface details
            if (!SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, IntPtr.Zero, 0, ref nRequiredSize, IntPtr.Zero))
            {
                DeviceInterfaceDetailData oDetail = new DeviceInterfaceDetailData();
                oDetail.Size = 5;	// hardcoded to 5! Sorry, but this works and trying more future proof versions by setting the size to the struct sizeof failed miserably. If you manage to sort it, mail me! Thx
                if (SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, ref oDetail, nRequiredSize, ref nRequiredSize, IntPtr.Zero))
                {
                    return oDetail.DevicePath;
                }
            }
            return null;
        }


        /// <summary>
        /// Kicks off an asynchronous read which completes when data is read or when the device
        /// is disconnected. Uses a callback.
        /// </summary>
        private static void BeginAsyncRead()
        {
            byte[] arrInputReport = new byte[m_nInputReportLength];
            // put the buff we used to receive the stuff as the async state then we can get at it when the read completes

            m_oFile.BeginRead(arrInputReport, 0, m_nInputReportLength, new AsyncCallback(ReadCompleted), arrInputReport);
        }

        /// <summary>
        /// Callback for above. Care with this as it will be called on the background thread from the async read
        /// </summary>
        /// <param name="iResult">Async result parameter</param>
        protected static void ReadCompleted(IAsyncResult iResult)
        {
            byte[] arrBuff = (byte[])iResult.AsyncState;	// retrieve the read buffer
            byte[]  tempbyte=new byte[8];
            for(int i=0;i<tempbyte.Length;i++)
            {
                tempbyte[i] = arrBuff[i + 1];
            }
            SaveRecDataList.AddRange(tempbyte);
            try
            {
                m_oFile.EndRead(iResult);	// call end read : this throws any exceptions that happened during the read
                BeginAsyncRead();	// when all that is done, kick off another read for the next report

            }
            catch (IOException ex)	// if we got an IO exception, the device was removed
            {
                HidExist = false;
            }
        }

        /// <summary>
        /// 如果设备句柄不是0则关闭设备句柄
        /// </summary>
        /// <returns></returns>
        public static COMMUNICATERESULT DisConnect()
        {
            return COMMUNICATERESULT.OK;
        }

        /// <summary>
        /// 写数据到USB端口的文件流
        /// </summary>
        /// <param name="Data">需要写入的数据</param>
        /// <returns>成功则返回OK，异常则返回DataSendFail</returns>
        private static COMMUNICATERESULT WriteData(byte[] Data)
        {
            try
            {
                SaveRecDataList.Clear();
                //m_oFile.Flush();
                Thread.Sleep(100);
                m_oFile.Write(Data, 0, Data.Length);
            }
            catch (Exception ee)
            {
                // The device was removed! 
                HidExist = false;
                int jj = Marshal.GetLastWin32Error();
                return COMMUNICATERESULT.DataSendFail;
            }
            return COMMUNICATERESULT.OK;
        }

        /// <summary>
        /// 用于接收数据时等待的实例
        /// </summary>
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        private static int templen;
        private static List<byte> SaveRecDataList = new List<byte>();


        /// <summary>
        /// 接收数据的函数
        /// </summary>
        /// <param name="RecLen">需要接收的数据长度</param>
        /// <param name="RecData">存储接收到的数据</param>
        /// <returns>成功则返回OK，异常则返回DataRecFail</returns>
        private static COMMUNICATERESULT ReadData(int RecLen, ref byte[] RecData)
        {
            ////实际从流中读取的字节个数
            //int Readlen=0;
            //需要从流中接收的字节数(每8个字节增加1个字节)
            templen = RecLen;//RecLen % 8 > 0 ? RecLen + RecLen / 8 + 1 : RecLen + RecLen / 8;
            int tempweittime = templen * 9 < 200 ? 200 : templen * 9;
            byte[] TempRead = new byte[templen];

            TimeoutObject.WaitOne(tempweittime);
            if (SaveRecDataList.Count < templen)
            {
                return COMMUNICATERESULT.DataRecFail;
            }
            else
            {
                int index = 0;
                TempRead = SaveRecDataList.ToArray();
                for (int i = 0; i < templen; i++)
                {
                    if (index < RecData.Length)
                    {
                        RecData[index++] = (byte)TempRead[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return COMMUNICATERESULT.OK;
        }



        #region Custom exception
        /// <summary>
        /// Generic HID device exception
        /// </summary>
        public class HIDDeviceException : ApplicationException
        {
            public HIDDeviceException(string strMessage) : base(strMessage) { }

            public static HIDDeviceException GenerateWithWinError(string strMessage)
            {
                return new HIDDeviceException(string.Format("Msg:{0} WinEr:{1:X8}", strMessage, Marshal.GetLastWin32Error()));
            }

            public static HIDDeviceException GenerateError(string strMessage)
            {
                return new HIDDeviceException(string.Format("Msg:{0}", strMessage));
            }
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Disposer called by both dispose and finalise
        /// </summary>
        /// <param name="bDisposing">True if disposing</param>
        protected virtual void Dispose(bool bDisposing)
        {
            try
            {
                if (bDisposing)	// if we are disposing, need to close the managed resources
                {
                    if (m_oFile != null)
                    {
                        m_oFile.Close();
                        m_oFile = null;
                    }
                }
                if (m_hHandle != IntPtr.Zero)	// Dispose and finalize, get rid of unmanaged resources
                {

                    CloseHandle(m_hHandle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
