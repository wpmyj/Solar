using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Data
{
    public class DelegateEntity
    {
        public delegate void AlarmDelegate(AlarmEntity alarm);//告警时使用的委托
        public delegate void SetInfoMethod(object Ob);//设置设备遥控量时使用的委托
    }
}
