using System;
using System.Collections.Generic;

using System.Text;
using System.Timers;
using Model_Data;
using Model_Data.CommunicateEntity;
using MathConvertHelper;

namespace Communication.CommunicateToLowerMonitor.PortBll
{
    public class PortBll_ModbusSerial : AllPortBll
    {
        public String ModbusTcpErrorStr = null;//保存错误信息
        private BasicCommunicateClass.SerialWrapper serialWrapper = new BasicCommunicateClass.SerialWrapper();

        public override bool Disconnect()
        { 
            return serialWrapper.Disonnect();
        }

        public override bool Connect()
        {
            return serialWrapper.Connect();
        }

        public override bool ConnectState()
        {
            return serialWrapper.ConnectState();
        }

        public override bool SetParaMeter(CommSerialEntity SE)
        {
            return serialWrapper.SetSerialPara(SE);
        }

        public override bool SetParaMeter(CommTCPEntity SE)
        {
            return true;
        }

        #region 遥测量读取部分
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
                ret = serialWrapper.SendAndReceive(SendCommand, BytesToRec, out RecByte);
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
                ret = serialWrapper.SendAndReceive(SendCommand, BytesToRec, out RecByte);
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
        
        //计算模拟量回复帧的长度
        /*private int CalculateAnalogRecByteLen(byte[] Command)
        {
            if(Command.Length<8)
            {
                return 0;
            }
            short TemLen=MathConvertHelper.BitConverter.ToInt16(Command,4);
            int Reclen = TemLen*2 + 5;
            return Reclen;

        }*/

        //计算数字量回复帧的长度
        /*private int CalculateDigitalRecByteLen(byte[] Command)
        {
            int Reclen;
            if (Command.Length < 8)
            {
                return 0;
            }
            short TemLen = MathConvertHelper.BitConverter.ToInt16(Command, 4);
            if (TemLen % 8 > 0)
            {
                Reclen = (TemLen /8 +1)+ 5;
            }
            else
            {
                Reclen = TemLen / 8  + 5;
            }
            
            return Reclen;
        }*/

        //去掉包头取得有效数据
        private byte[] GetRecDataFromRecByte(byte[] RecByte)
        {
            List<byte> TemRecData = new List<byte>();
            if (RecByte.Length < 5)
            {
                return TemRecData.ToArray();
            }
            for (int i = 3; i < RecByte.Length-2; i++)
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

            if (RecData[0] != SendData[0])
            {
                return COMMUNICATERESULT.FailUnitID;
            }
            if (RecData[1] != SendData[1])
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

        #endregion

        //读取下位机 存储的历史报警数据----专用通道（目前只支持MODBUS协议）
        public override COMMUNICATERESULT GetBasicDataFromCommand(byte[] Cmd, ref byte[] RecData, int recLen)
        {
            COMMUNICATERESULT ret = new COMMUNICATERESULT();
            ret = COMMUNICATERESULT.OK;
            byte[] RecByte = null;

            ret = serialWrapper.SendAndReceive(Cmd, recLen, out RecByte);
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

            return COMMUNICATERESULT.OK;
        }

        #region 遥控量设置部分
        bool SetInfoTimeOutFlage = false;
        public override COMMUNICATERESULT SetData(CommandClass SetInfo)
        {
            int BytestoRec = 8;
            byte[] RecBytes;
            byte[] SendCommand;
            COMMUNICATERESULT ret;
            SetSetDataTimeOutTimer();
            SendCommand = SetInfo.Command;
            /*while (serialWrapper.ConnectState())
            {
                if (SetInfoTimeOutFlage == 1)
                {
                    return COMMUNICATERESULT.Timeout;
                }
            }*/
            if (!serialWrapper.ConnectState())
            {
                if (serialWrapper.Connect())
                {

                    ret = serialWrapper.SendAndReceive(SendCommand, BytestoRec, out RecBytes);
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
                //SendCommand = SetInfo.ToArray();
                ret = serialWrapper.SendAndReceive(SendCommand, BytestoRec, out RecBytes);
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
            SetInfoTimer.Elapsed += new ElapsedEventHandler(SetInfoTimer_Elapsed);
            SetInfoTimer.Start();
        }

        private void SetInfoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer temptimer = (Timer)sender;
            temptimer.Stop();
            SetInfoTimeOutFlage = true;

        }
        #endregion

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
                    if (serialWrapper != null)
                    {
                        serialWrapper = null;
                    }
                }
            }
            isDisposed = true;
        }
        #endregion
    }
}
