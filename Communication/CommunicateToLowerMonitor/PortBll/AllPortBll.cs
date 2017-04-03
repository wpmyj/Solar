using System;
using System.Collections.Generic;

using System.Text;
using Model_Data;
using Model_Data.CommunicateEntity;
using System.Threading;
namespace Communication.CommunicateToLowerMonitor
{
    //端口抽象类：抽象所有端口共有特性
    public abstract class AllPortBll : IDisposable
    {
        public static AllPortBll CreateInstance(Protocol protocol)
        {
            AllPortBll _Instance = null;

            switch (protocol)
            {
                case Protocol.Modbus_TCPIPPort:
                    _Instance = new PortBll.PortBll_ModBusTCPIP();
                    break;
                case Protocol.Modbus_SerialPort:
                    _Instance = new PortBll.PortBll_ModbusSerial();
                    break;
                case Protocol.Modbus_USBPort:
                    _Instance = new PortBll.PortBll_ModBusUSB();
                    break;
                default:
                    break;
            }

            return _Instance;
        }

        public bool LastConnect = true;//上一次端口连接状态标志
        public bool ThisConnect = false;
        public abstract bool Disconnect();
        public abstract bool Connect();
        public abstract bool ConnectState();
        public abstract bool SetParaMeter(CommSerialEntity SE);
        public abstract bool SetParaMeter(CommTCPEntity SE);


        public abstract COMMUNICATERESULT GetData(DeviceBll Device,ref List<byte> AnalogDate,ref List<byte> DigitalData,ref List<string> CharacterData);
        public abstract COMMUNICATERESULT SetData(CommandClass OneSetCommand);

        public COMMUNICATERESULT SetData(List<CommandClass> SetCommandList)
        {
            COMMUNICATERESULT ret = COMMUNICATERESULT.OK;
            for(int i=0;i<SetCommandList.Count;i++)
            {
                ret=SetData(SetCommandList[i]);
                //1、下位机返回值不对，去除返回值判断
                //if (ret != COMMUNICATERESULT.OK)
                //{
                //    return ret;
                //}
                //2、下位机处理速度过比较慢，发送速度过快会出现不稳定的情况，把命令发送间隔延时至1s
                Thread.Sleep(1000);
            }
            return ret;
        }

        public abstract COMMUNICATERESULT GetBasicDataFromCommand(byte[] Cmd, ref byte[] RecData,int recLen);

        #region IDisposable 成员
        public abstract void Dispose();
        #endregion
    }
}
