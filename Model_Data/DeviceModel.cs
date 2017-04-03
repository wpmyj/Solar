using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO.Ports;
using Model_Data.CommunicateEntity;

namespace Model_Data
{
    [XmlRoot("Device")]
    public class DeviceModel
    {
        public string DeviceName = "-1";
        public byte UnitId;
        public int WriteDBTime;
        public string DeviceTypeName = "-1";
        public bool GenerationState;
        public string TableName = "-1";
        public string UIPath = "-1";

        public PortModel Port = new PortModel();

        public List<AnalogModel> Analog = new List<AnalogModel>();

        public List<DigitalModel> Digital = new List<DigitalModel>();
    }

    public class PortModel
    {
        public string PortName = "-1";
        public string Description = "-1";
        public int ScanningTime;
        public int OverTime;
        public int ReconnectNumber;
        public int RecoveryTime;
        public Protocol PortType;
        public bool EnableState;
        public int ReadOverTime;
        public int WriteOverTime;

        public TcpModel TCP = new TcpModel();

        public SerialModel Serial = new SerialModel();
    }

    public class AnalogModel
    {
        public int SignalId;
        public string SignalName = "-1";
        public string SignalType = "-1";
        public string SignalUnit = "-1";
        public string SignalDescription = "-1";
        public double ScalingFactorB;
        public double ScalingFactorA;
        public string SafeArea = "-1";
        public string SafeLevel = "-1";
        public float HigherRange;
        public float HighestRange;
        public float LowerRange;
        public float LowestRange;
        public short DataLen;
        public short DataStartAddress;
        public byte RegisterType;
        public bool ISContinuous;
        public string DataAnalyticalWay = "-1";
        public string AlarmConditions = "-1";
        public bool ISRecord;
        public string ValChFillAlarmStrType = "-1";
        [XmlIgnore]
        public object Value = 0;
        public string AnalogReadFrequency = "-1";
    }

    public class DigitalModel
    {
        public int SignalId;
        public string SignalName = "-1";
        public string Describe = "-1";
        public string Value0_Describe = "-1";
        public string Value1_Describe = "-1";
        public int Value;
        public short DataStartAddress;
        public byte RegisterType;
        public bool ISContinuous;
        public bool ISRecord;
        public bool ISReport;
        public string DigitalAlarmType = "-1";
        public string DigitalReadFrequency = "-1";
    }

    public class TcpModel
    {
        public string IP = "-1";
        public int Port;
    }

    public class SerialModel
    {
        public int BaudRate;
        public int DataBit;
        public StopBits StopBit;
        public Parity Parity;
        public string PortName = "-1";
        public int RecoveryWaitTime;
    }

}
