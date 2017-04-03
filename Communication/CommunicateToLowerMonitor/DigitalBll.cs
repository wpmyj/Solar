using System;
using System.Collections.Generic;

using System.Text;
using Model_Data;
using Model_Data.CommunicateEntity;
namespace Communication.CommunicateToLowerMonitor
{
    public class DigitalBll
    {
        public DigitalModel DigitalInfo = new DigitalModel();
        public object ThisLock = new object();

        public DelegateEntity.AlarmDelegate DigitalAlarmMethod;

        //保存数字量到内存
        public void UpdataOneDigitalData(int OneDigitalData)
        {
            if (DigitalInfo.DigitalAlarmType == DigitalAlarmConditionType.ValueChangeAlarm)
            {
                DigitalAlarm(OneDigitalData);
            }
            lock (ThisLock)
            {
                if (DigitalInfo.Value != OneDigitalData)
                {
                    DigitalInfo.Value = OneDigitalData;
                }
            }
        }

        //数字量报警
        private void DigitalAlarm(int OneDigitalData)
        {
            AlarmEntity alarm = new AlarmEntity();
            if (DigitalInfo.Value != OneDigitalData)
            {
                if (DigitalAlarmMethod != null)
                {
                    //组织告警字符串
                    if (OneDigitalData == 0)
                    {
                        alarm.MessageStr = DigitalInfo.SignalName + " " + DigitalInfo.Value0_Describe;
                        alarm.DigitalValue = 0;
                        alarm.Success = true;
                    }
                    else
                    {
                        alarm.MessageStr = DigitalInfo.SignalName + " " + DigitalInfo.Value1_Describe;
                        alarm.DigitalValue = 1;
                        alarm.Success = false;
                    }
                    alarm.OrigSource = AlarmEntity.AlarmSourceClass.DigitalSignal;
                    alarm.SignalId = DigitalInfo.SignalId;

                    DigitalAlarmMethod.Invoke(alarm);

                }
            }
        }
    }
}
