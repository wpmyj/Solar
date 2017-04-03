using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Data.CommunicateEntity
{
    //端口类型的枚举
    public enum Protocol
    {
        Modbus_TCPIPPort = 1,
        Modbus_SerialPort = 2,
        Modbus_USBPort=3
    }

    //modbus命令码的枚举  
    public enum FunctionCode : byte
    {
        ReadCoils = 1,
        ReadInputs = 2,
        ReadHoldingRegisters = 3,
        ReadInputRegisters = 4,

        WriteSingleCoil = 5,
        WriteSingleRegister = 6,
        Diagnostics = 8,
        DiagnosticsReturnQueryData = 0,
        WriteMultipleCoils = 15,
        WriteMultipleRegisters = 0x10,
        ReadWriteMultipleRegisters = 23,

    }

    //通讯结果返回字符 代表的意义
    public enum COMMUNICATERESULT : int
    {
        OK = 10,//正常
        PortOpenFail = 11,//端口打开错误   
        DataSendFail = 12,//数据发送失败
        DataRecFail = 13,//数据接收失败
        Timeout = 14,//超时
        DataCheckFail = 15,//校验数据是出错
        OtherError = 16,//其他的错误

        #region Modbus协议通讯的故障类型
        UnknownFunCode = 01,//非法功能码
        DataAddrInvalid = 02,//非法的数据地址(02、04命令)
        OverRegister = 03,//非法的数据地址(06、10命令)
        SeverErr = 04,//CRC校验错误
        FailUnitID = 05,//回复的单元号与请求的单元号不一致
        FailBussinessID = 06,//TCPIP通讯的事物单元ID错误
        DeviceNotExist=07,//设备不存在（TCP/IP modebus）
        DeviceCommErrorOrClosed = 08,//该设备状态为通讯异常或者关机无通讯（TCP/IP modebus）
        OtherModbusError=09,//其他未知的通讯故障
        #endregion


        #region EA协议通讯的故障类型
        EA_1AnalogCommandNubEro = 21,//单相模拟量命令个数不够
        EA_1DigitalCommandNubEro = 22,//单相数字量命令个数不够
        EA_3AnalogCommandNubEro = 23,//单相模拟量命令个数不够
        EA_3DigitalCommandNubEro = 24,//单相数字量命令个数不够
        EA_1Q1Index0Erroe = 25,//Q1命令回复的起始符不是（
        #endregion


        #region USB端口故障类型
        USB_CreateDeviceFileFail = 31,//创建文件失败
        USB_CreatFileStreamFail = 32,//创建文件流失败
        USB_NeverFoundDevice = 33,//没有找到USB设备
        USB_Exception = 34,//系统抛出的异常

        //USB_WriteDataFail=35,//USB写数据失败
        #endregion


        #region snmp协议通讯故障类型
        SnmpIpError=41,//接收ip的格式错误
        SnmpGetDataError=42,//接收数据出错
        SnmpNoResponse=43,//返回数据包没有值
        SnmpRecPduStatusError=44,//返回的节点中有错误
        SnmpSinglePhaseCommandNubError=45,//单相查询命令个数错误
        SnmpSetCommandError=46,//设置命令错误
        SnmpUPSInOrOutPhaseError=47,//梅兰机器的输入输出相序错误
        SnmpThreePhaseCommandNubError = 48,//三相查询命令个数错误
        #endregion

        DataValueInvalid = -3,
        UnknownError = -6,
        DataFormatError = -7,
        ServerDelayOK = -11,
        GateWayFault_RoutingErr = -12,
        GateWayFault_Noresponse = -13,
        ServerBusy = -14

    }

    /// <summary>
    /// 设备通讯状态的枚举
    /// </summary>
    public enum DivCommStateEnum : int
    {
        Connecting = 1,//连接中
        Success = 2,//通讯成功
        Failed = 3,//通讯失败
        NoCommunication=4//无通信
    }


    #region 模拟量相关设置

    //模拟量解析方式
    public class AnalogDataAnalytical
    {
        public const string Char = "Char";
        public const string CharReverse = "CharReverse";
        public const string Int16 = "Int16";
        public const string Int16Reverse = "Int16Reverse";
        public const string Int32 = "Int32";
        public const string Int32Swapped = "Int32Swapped";
        public const string Int32ReverseSwap = "Int32ReverseSwap";
        public const string Int64 = "Int64";
        public const string Int64Reverse = "Int64Reverse";
        public const string UInt16 = "UInt16";
        public const string UInt16Reverse = "UInt16Reverse";
        public const string UInt32 = "UInt32";
        public const string UInt32Reverse = "UInt32Reverse";
        public const string UInt64 = "UInt64";
        public const string UInt64Reverse = "UInt64Reverse";
        public const string Single = "Single";
        public const string SingleReverse = "SingleReverse";
        public const string Double = "Double";
        public const string StrType = "String";//ASCII编码方式转换
        public const string StrASCII = "String_ASCII";//ASCII编码方式转换
        public const string StrUnicode = "String_Unicode";//Unicode编码方式转换
        public const string BCD16 = "BCD16";//BCD编码方式转换
    }

    //模拟量告警条件类型
    public class AnalogAlarmConditionType
    {
        public const string ValueLimitAlarm = "ValueLimitAlarm";//限值告警
        public const string ValueChangeAlarm = "ValueChangAlarm";//值改变告警
        public const string NoAlarm = "NoAlarm";//无告警
    }

    //模拟量  读取频率
    public class AnalogReadFrequency
    {
        public const string OnlyOne = "OnlyOne";
        public const string Multiple = "Multiple";
        public const string EveryTime = "EveryTime";
    }

    //模拟量告警判断结果
    public class AnalogAlarmResultClass
    {
        public const string GLL = "特别低";//特别低
        public const string LLL = "低";//低
        public const string OK = "正常";//正常
        public const string HHH = "高";//高
        public const string GHH = "特别高";//特别高

        public const string ValueChange = "值变化";//值变化
    }

    //模拟量值改变时告警填充告警字符串的方式
    public class ValueChangeAlarmTypeClass
    {
        public const string SystemState_InvertM3 = "M3SystemState";
        public const string SystemState_Invert500k = "500KSystemstate";
        public const string None = "none";
    }

    //太阳能逆变器小机系统状态告警时使用的告警字符
    public class M3_SystemStateStringClass
    {
        public const string SystemState = "系统状态";
        public const string CallWateMode = "待机模式";
        public const string Connecting = "连接中";
        public const string GridConnected = "并网";
        public const string CloseMode = "关机状态";
        public const string WaitingOpen = "等待开机";
        public const string ErrorMode = "故障模式";
    }

    //太阳能逆变器大机系统状态告警时使用的告警字符串
    public class Invert500K_StateStringClass
    {
        public const string SystemState = "启停状态";
        public const string StopMode = "停止";
        public const string RunMode = "运行";
    }
    #endregion

    #region 数字量相关设置
    //数字量告警条件类型
    public class DigitalAlarmConditionType
    {
        public const string ValueChangeAlarm = "ValueChangAlarm";//值改变告警
        public const string NoAlarm = "NoAlarm";//无告警
    }

    //数字量  读取频率
    public class DigitalReadFrequency
    {
        public const string OnlyOne = "OnlyOne";
        public const string Multiple = "Multiple";
        public const string EveryTime = "EveryTime";
    }
    #endregion
}
