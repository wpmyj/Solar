using System;
using System.Collections.Generic;

using System.Text;
using Model_Data;
using Model_Data.CommunicateEntity;
using Communication.BasicCommunicateClass;
using MathConvertHelper;
namespace Communication.CommunicateToLowerMonitor.PortBll
{
    class PortBll_ModBusUSB:AllPortBll
    {
        public String ModbusTcpErrorStr = null;//保存错误信息

        public override bool Disconnect()
        {
            return true;
        }

        public override bool Connect()
        {
            if (USBWrapper.connect() == COMMUNICATERESULT.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool ConnectState()
        {
            return USBWrapper.USBConnectState();
        }
        public override bool SetParaMeter(CommSerialEntity SE)
        {
            return true;
        }
        public override bool SetParaMeter(CommTCPEntity SE)
        {
            return true;
        }


        public override COMMUNICATERESULT GetData(DeviceBll Device, ref List<byte> AnalogDate, ref List<byte> DigitalData, ref List<string> CharacterData)
        {
            COMMUNICATERESULT ret = new COMMUNICATERESULT();
            ret = COMMUNICATERESULT.OK;
            byte[] SendCommand = null;
            byte[] RecByte = null;
            byte[] RecData = null;
            int BytesToRec = 0;
            foreach (CommandClass AnalogCommand in Device.Device.AnalogCommandList)
            {
                SendCommand = AnalogCommand.Command;
                BytesToRec = AnalogCommand.RecLen;
                ret = USBWrapper.SendAndReceive(SendCommand, BytesToRec, out RecByte);
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
                AnalogDate.AddRange(RecData);

            }
            foreach (CommandClass DigitalCommand in Device.Device.DigitalCommandList)
            {
                SendCommand = DigitalCommand.Command;
                BytesToRec = DigitalCommand.RecLen;
                ret = USBWrapper.SendAndReceive(SendCommand, BytesToRec, out RecByte);
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
            return COMMUNICATERESULT.OK;
        }

        //去掉包头取得有效数据
        private byte[] GetRecDataFromRecByte(byte[] RecByte)
        {
            List<byte> TemRecData = new List<byte>();
            if (RecByte.Length < 5)
            {
                return TemRecData.ToArray();
            }
            for (int i = 3; i < RecByte.Length - 2; i++)
            {
                TemRecData.Add(RecByte[i]);
            }
            return TemRecData.ToArray();
        }

        //校验数据
        private COMMUNICATERESULT CheckData(byte[] RecData, byte[] SendData)
        {
            byte[] myrecdata = new byte[RecData.Length - 2];
            Array.Copy(RecData, myrecdata, RecData.Length - 2);

            byte[] CRC = CRCCalculate.CRC_16(myrecdata);
            if (RecData[RecData.Length - 1] != CRC[1] || RecData[RecData.Length - 2] != CRC[0])
            {
                return COMMUNICATERESULT.DataCheckFail;
            }

            if (RecData[0] != SendData[1])
            {
                return COMMUNICATERESULT.FailUnitID;
            }
            if (RecData[1] != SendData[2])
            {
                if ((RecData[1] & 0x8) == 0)
                    return COMMUNICATERESULT.UnknownFunCode;
                else
                {
                    switch (RecData[2])
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
                        default:
                            break;
                    }
                }
            }
            return COMMUNICATERESULT.OK;
        }

        public override COMMUNICATERESULT SetData(CommandClass SetInfo)
        {
            int BytestoRec = 8;
            byte[] RecBytes;
            byte[] SendCommand;
            COMMUNICATERESULT ret;

            SendCommand = SetInfo.Command;
            if (!USBWrapper.USBConnectState())
            {
                if (USBWrapper.connect() == COMMUNICATERESULT.OK)
                {
                    ret = USBWrapper.SendAndReceive(SendCommand, BytestoRec, out RecBytes);

                }
                else
                {
                    return COMMUNICATERESULT.PortOpenFail;
                }
            }
            else
            {
                ret = USBWrapper.SendAndReceive(SendCommand, BytestoRec, out RecBytes);
            }
            if (ret == COMMUNICATERESULT.OK)
            {
                ret = CheckData(RecBytes, SendCommand);
            }

            return ret;
        }

        public override COMMUNICATERESULT GetBasicDataFromCommand(byte[] Cmd, ref byte[] RecData, int recLen)
        {
            return COMMUNICATERESULT.OK;
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
                    /*if (usbWrapper != null)
                    {
                        usbWrapper.Dispose();
                    }*/
                }
            }
            isDisposed = true;
        }
        #endregion
    }
}
