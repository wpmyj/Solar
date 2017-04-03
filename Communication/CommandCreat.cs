using System;
using System.Collections.Generic;
using System.Text;
using Model_Data;
using Model_Data.CommunicateEntity;
using Communication.CommunicateToLowerMonitor;
using MathConvertHelper;

namespace Communication
{
    public class CommandCreat
    {
        #region 接口函数部分

        //创建设备查询命令列表
        public static bool CreatDeviceCommandList(Protocol PortType, DeviceBll Device)
        {
            Device.Device.AnalogCommandList = CreatAnalogCommandList(PortType, Device.Device.UnitId, Device.AnalogList);
            Device.Device.DigitalCommandList = CreatDigitalCommandList(PortType, Device.Device.UnitId, Device.DigitalList);
            return true;
        }

        //创建modbus设置命令
        public static CommandClass CreatModbusSetDivInfoCommand(Protocol PortType, byte UnitId, FunctionCode CommandCode, byte[] SetData, short StartAdr, short RegisterLen)
        {
            CommandClass OneSetCommand = new CommandClass();
            byte[] SetInfoCommand = null;
            byte[] BaseSetInfoCommand = null;
            short RecLength = 6;
            switch (CommandCode)
            {
                case FunctionCode.WriteSingleRegister:
                case FunctionCode.WriteSingleCoil:
                    BaseSetInfoCommand = CreatSetSingleRegisterBaseCommand(UnitId, CommandCode, SetData, StartAdr);
                    break;
                case FunctionCode.WriteMultipleRegisters:
                case FunctionCode.WriteMultipleCoils:
                    BaseSetInfoCommand = CreatSetMultipleRegistersBaseCommand(UnitId, CommandCode, SetData, StartAdr, RegisterLen);
                    break;
            }
            SetInfoCommand = CreatOneFullModBusCommand(PortType, BaseSetInfoCommand, ref RecLength);
            OneSetCommand.Command = SetInfoCommand;
            return OneSetCommand;
        }

        public static List<CommandClass> CreatModbusSetDivInfoCommandList(Protocol PortType, byte UnitId, FunctionCode CommandCode, byte[] SetData, short StartAdr, short RegisterLen = 1)
        {
            List<CommandClass> SetCommandList = new List<CommandClass>();
            CommandClass TempSetCommand = new CommandClass();
            byte[] temponesetdata = new byte[2];
            int StartCout = 0;
            if (SetData.Length < RegisterLen * 2)
            {
                return SetCommandList;
            }
            switch (CommandCode)
            {
                case FunctionCode.WriteSingleRegister:
                case FunctionCode.WriteSingleCoil:
                    TempSetCommand = CreatModbusSetDivInfoCommand(PortType, UnitId, CommandCode, SetData, StartAdr, RegisterLen);
                    SetCommandList.Add(TempSetCommand);
                    break;
                case FunctionCode.WriteMultipleRegisters:
                    for (short i = 0; i < RegisterLen; i++)
                    {
                        short tempStarAdr = (short)(StartAdr + i);
                        temponesetdata[0] = SetData[StartCout++];
                        temponesetdata[1] = SetData[StartCout++];
                        TempSetCommand = CreatModbusSetDivInfoCommand(PortType, UnitId, FunctionCode.WriteSingleRegister, temponesetdata, tempStarAdr, 1);
                        SetCommandList.Add(TempSetCommand);
                    }
                    break;
                case FunctionCode.WriteMultipleCoils:
                    for (short i = 0; i < RegisterLen; i++)
                    {
                        short tempStarAdr = (short)(StartAdr + i);
                        temponesetdata[0] = SetData[StartCout++];
                        temponesetdata[1] = SetData[StartCout++];
                        TempSetCommand = CreatModbusSetDivInfoCommand(PortType, UnitId, FunctionCode.WriteSingleCoil, temponesetdata, tempStarAdr, 1);
                        SetCommandList.Add(TempSetCommand);
                    }
                    break;
                default:
                    break;
            }
            return SetCommandList;

        }

        #endregion

        //创建模拟量查询命令列表
        private static List<CommandClass> CreatAnalogCommandList(Protocol PortType, byte UnitId, List<AnalogBll> AnalogList)
        {
            List<CommandClass> AnalogCommandList = new List<CommandClass>();
            CommandClass OneAnalogCommand;

            if (AnalogList.Count < 1)
            {
                return AnalogCommandList;
            }

            AnalogBll tempanalog = AnalogList[AnalogList.Count - 1];
            if (tempanalog.AnalogInfo.ISContinuous)
            {
                tempanalog.AnalogInfo.ISContinuous = false;
            }

            byte CommandCode = 2;
            short StartAdr = 0;
            short Datalength = 0;
            short registerLen = 0;
            bool IsStartAdr = true;//前一数字量与当前数字量是否连续的标志

            foreach (AnalogBll Analog in AnalogList)
            {
                Datalength += Analog.AnalogInfo.DataLen;
                registerLen += Convert.ToInt16((Analog.AnalogInfo.DataLen % 2 == 0) ? (Analog.AnalogInfo.DataLen / 2) : (Analog.AnalogInfo.DataLen / 2 + 1));
                if (IsStartAdr)
                {
                    CommandCode = Analog.AnalogInfo.RegisterType;
                    StartAdr = Analog.AnalogInfo.DataStartAddress;
                }
                IsStartAdr = !Analog.AnalogInfo.ISContinuous;

                if (!Analog.AnalogInfo.ISContinuous)
                {
                    OneAnalogCommand = new CommandClass();
                    Datalength += 3;//加上的长度为地址、功能码、返回数据长度所占用的字节数
                    OneAnalogCommand.Command = CreatOneModbusReadCommand(PortType, UnitId, CommandCode, StartAdr, registerLen, ref Datalength);
                    OneAnalogCommand.RecLen = Datalength;
                    AnalogCommandList.Add(OneAnalogCommand);
                    Datalength = 0;
                    registerLen = 0;
                }
            }
            return AnalogCommandList;
        }
        //创建数字量查询命令列表
        private static List<CommandClass> CreatDigitalCommandList(Protocol PortType, byte UnitId, List<DigitalBll> DigitalList)
        {
            List<CommandClass> DigitalCommandList = new List<CommandClass>();
            CommandClass DigitalCommand;

            if (DigitalList.Count < 1)
            {
                return DigitalCommandList;
            }

            DigitalBll tempdigital = DigitalList[DigitalList.Count - 1];
            if (tempdigital.DigitalInfo.ISContinuous)
            {
                tempdigital.DigitalInfo.ISContinuous = false;
            }

            byte CommandCode = 2;
            short StartAdr = 0;
            short Datalength = 0;
            short RegisterLen = 0;
            bool IsStartAdr = true;//前一数字量与当前数字量是否连续的标志

            foreach (DigitalBll digital in DigitalList)
            {
                RegisterLen++;
                if (IsStartAdr)
                {
                    CommandCode = digital.DigitalInfo.RegisterType;
                    StartAdr = digital.DigitalInfo.DataStartAddress;
                }
                IsStartAdr = !digital.DigitalInfo.ISContinuous;

                if (!digital.DigitalInfo.ISContinuous)
                {
                    DigitalCommand = new CommandClass();
                    Datalength = Convert.ToInt16(RegisterLen % 8 > 0 ? RegisterLen / 8 + 1 : RegisterLen / 8);
                    Datalength += 3;
                    DigitalCommand.Command = CreatOneModbusReadCommand(PortType, UnitId, CommandCode, StartAdr, RegisterLen, ref Datalength);
                    DigitalCommand.RecLen = Datalength;
                    DigitalCommandList.Add(DigitalCommand);
                    RegisterLen = 0;
                }
            }


            return DigitalCommandList;
        }

        #region 创建Modbus命令部分

        //创建一个Modbus读取命令
        public static byte[] CreatOneModbusReadCommand(Protocol PortType, byte UnitId, byte FunctionCode, short StartAdr, short Registerlength, ref short DataLength)
        {
            byte[] BaseModbusCommand;
            byte[] FullModbusCommand = null;
            BaseModbusCommand = CreatBasicModBusReadCommand(UnitId, FunctionCode, StartAdr, Registerlength);
            FullModbusCommand = CreatOneFullModBusCommand(PortType, BaseModbusCommand, ref DataLength);
            return FullModbusCommand;
        }

        //创建Modbus读取数据的基本命令
        private static byte[] CreatBasicModBusReadCommand(byte UnitId, byte FunctionCode, short StartAdr, short length)
        {
            List<byte> templist = new List<byte>();
            templist.Add(UnitId);
            templist.Add(FunctionCode);
            templist.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(StartAdr));
            templist.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(length));
            return templist.ToArray();
        }

        //创建写单个寄存器的基本命令
        private static byte[] CreatSetSingleRegisterBaseCommand(byte UnitId, FunctionCode CommandCode, byte[] SetData, short StartAdr)
        {
            List<byte> BaseSetInfoCommand = new List<byte>();
            if (SetData.Length < 2)
            {
                return BaseSetInfoCommand.ToArray();
            }
            BaseSetInfoCommand.Add(UnitId);
            BaseSetInfoCommand.Add((byte)CommandCode);
            BaseSetInfoCommand.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(StartAdr));
            BaseSetInfoCommand.Add(SetData[0]);
            BaseSetInfoCommand.Add(SetData[1]);
            return BaseSetInfoCommand.ToArray();

        }

        //创建写多个寄存器的基本命令
        private static byte[] CreatSetMultipleRegistersBaseCommand(byte UnitId, FunctionCode CommandCode, byte[] SetData, short StartAdr, short RegisterLen)
        {
            List<byte> BaseSetInfoCommand = new List<byte>();
            if (SetData.Length % 2 != 0)
            {
                return BaseSetInfoCommand.ToArray();
            }
            BaseSetInfoCommand.Add(UnitId);
            BaseSetInfoCommand.Add((byte)CommandCode);
            BaseSetInfoCommand.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(StartAdr));
            BaseSetInfoCommand.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(RegisterLen));
            BaseSetInfoCommand.Add((byte)SetData.Length);
            BaseSetInfoCommand.AddRange(SetData);
            return BaseSetInfoCommand.ToArray();

        }

        //创建一个完整的ModBus命令
        private static byte[] CreatOneFullModBusCommand(Protocol PortType, byte[] BaseModbusCommand, ref short RecDataLen)
        {
            byte[] FullModbusCommand = null;
            switch (PortType)
            {
                case Protocol.Modbus_SerialPort:
                    FullModbusCommand = CreatSerialModbusCommand(BaseModbusCommand);
                    RecDataLen += 2;//加上CRC校验占的字节数
                    break;
                case Protocol.Modbus_USBPort:
                    FullModbusCommand = CreatUSBModbusCommand(BaseModbusCommand);
                    RecDataLen += 2;//加上CRC校验占的字节数
                    break;
                case Protocol.Modbus_TCPIPPort:
                    FullModbusCommand = CreatTCPIPModbusCommand(BaseModbusCommand);
                    RecDataLen += 6;//加上TCPIP包头占的字节数
                    break;
                default:
                    //DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("设备协议类型为{0}的设备不能在端口类型为{1}的端口下通讯", DeviceProtocolClass.Modbus, PortType), "警告");
                    break;
            }
            return FullModbusCommand;
        }

        //创建用于485通讯的Modus命令
        private static byte[] CreatSerialModbusCommand(byte[] BaseModbusCommand)
        {
            List<byte> SerialModbusCommand = new List<byte>();

            SerialModbusCommand.AddRange(BaseModbusCommand);
            byte[] CRCArray = CRCCalculate.CRC_16(BaseModbusCommand);
            SerialModbusCommand.AddRange(CRCArray);
            return SerialModbusCommand.ToArray();
        }

        //创建用于USB通讯的Modus命令
        private static byte[] CreatUSBModbusCommand(byte[] BaseModbusCommand)
        {
            List<byte> SerialModbusCommand = new List<byte>();
            //BaseModbusCommand[5] = 30;
            SerialModbusCommand.Add(0);
            SerialModbusCommand.AddRange(BaseModbusCommand);
            byte[] CRCArray = CRCCalculate.CRC_16(BaseModbusCommand);
            SerialModbusCommand.AddRange(CRCArray);
            return SerialModbusCommand.ToArray();
        }

        //创建用于TCPIP通讯的Modbus命令
        private static byte[] CreatTCPIPModbusCommand(byte[] BaseModbusCommand)
        {
            List<byte> TCPIPModbusCommand = new List<byte>();
            TCPIPModbusCommand.AddRange(CreatMBAPHeard((short)BaseModbusCommand.Length));
            TCPIPModbusCommand.AddRange(BaseModbusCommand);
            return TCPIPModbusCommand.ToArray();
        }

        //创建网络传输的报文头
        private static short TransactionIndex = 0;
        private static byte[] CreatMBAPHeard(short CommandLength)
        {
            List<byte> templist = new List<byte>();

            TransactionIndex++;
            short ProtocolIndex = 0;

            templist.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(TransactionIndex));
            templist.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(ProtocolIndex));
            templist.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(CommandLength));

            return templist.ToArray();
        }

        #endregion

    }
}
