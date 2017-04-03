using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Data
{
    public class AlarmEntity
    {
        //告警源
        public class AlarmSourceClass
        {
            public const string DigitalSignal = "DigitalSignal";
            public const string AnalogSignal = "AnalogSignal";
            public const string Device = "Device";
            public const string Port = "Port";
        }

        public string OrigSource;//告警源
        public string MessageStr;//告警字符串`
        public int SignalId;//信号Id
        public DateTime AlarmTime=DateTime.Now;//报警时间 
        public bool Success = false;
        public int DigitalValue = -1;//如果是数字量报警，保存报警值
    }

}
