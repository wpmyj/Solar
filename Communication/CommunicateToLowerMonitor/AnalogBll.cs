using System;
using System.Collections.Generic;

using System.Text;
using Model_Data;
using Model_Data.CommunicateEntity;
using MathConvertHelper;
namespace Communication.CommunicateToLowerMonitor
{
    public class AnalogBll
    {
        public AnalogModel AnalogInfo = new AnalogModel();
        public string LastalarmResult = AnalogAlarmResultClass.OK;
        private object ThisLock = new object();

        public DelegateEntity.AlarmDelegate AnalogAlarmMethod;

        //保存模拟量到内存并报警
        public void UpdataOneAnalogData(byte[] OneAnalogData)
        {
            object AnalyseValue = AnalyseAnalogData(OneAnalogData);
            if (AnalogInfo.SignalType == "float" || AnalogInfo.SignalType == "int" || AnalogInfo.SignalType == "decimal(18,2)")
            {
                AnalyseValue = Math.Round(Convert.ToSingle(AnalyseValue),3);
            }
            AnalogAlarm(AnalyseValue);
            lock (ThisLock)
            {
                AnalogInfo.Value = AnalyseValue;
            }
        }
        //依据数据类型对模拟量进行解析
        private object AnalyseAnalogData(byte[] OneAnalogData)
        {
            object AnalyseValue = 0;
            #region 依据数据类型解析部分
            switch (AnalogInfo.DataAnalyticalWay)
            {
                case AnalogDataAnalytical.Char:
                    char TempChar = MathConvertHelper.BitConverter.ToChar(OneAnalogData, 0);
                    AnalyseValue = TempChar * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.CharReverse:
                    char TempCharRev = MathConvertHelper.BitConverter.ToCharReverse(OneAnalogData, 0);
                    AnalyseValue = TempCharRev * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Int16:
                    Int16 TempInt16 = MathConvertHelper.BitConverter.ToInt16(OneAnalogData, 0);
                    AnalyseValue = TempInt16 * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Int16Reverse:
                    Int16 TempInt16Rev = MathConvertHelper.BitConverter.ToInt16Reverse(OneAnalogData, 0);
                    AnalyseValue = TempInt16Rev * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Int32:
                    Int32 TempInt32 = MathConvertHelper.BitConverter.ToInt32(OneAnalogData, 0);
                    AnalyseValue = TempInt32 * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Int32ReverseSwap:
                    Int32 TempInt32Rev = MathConvertHelper.BitConverter.ToInt32ReverseSwap(OneAnalogData, 0);
                    AnalyseValue = TempInt32Rev * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Int32Swapped:
                    Int32 TempInt32Swap = MathConvertHelper.BitConverter.ToInt32Swapped(OneAnalogData, 0);
                    AnalyseValue = TempInt32Swap * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Int64:
                    Int64 TempInt64 = MathConvertHelper.BitConverter.ToInt64(OneAnalogData, 0);
                    AnalyseValue = TempInt64 * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Int64Reverse:
                    Int64 TempInt64Rev = MathConvertHelper.BitConverter.ToInt64Reverse(OneAnalogData, 0);
                    AnalyseValue = TempInt64Rev * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.UInt16:
                    UInt16 TempUInt16 = MathConvertHelper.BitConverter.ToUInt16(OneAnalogData, 0);
                    AnalyseValue = TempUInt16 * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.UInt16Reverse:
                    UInt16 TempUInt16Rev = MathConvertHelper.BitConverter.ToUInt16Reverse(OneAnalogData, 0);
                    AnalyseValue = TempUInt16Rev * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.UInt32:
                    UInt32 TempUInt32 = MathConvertHelper.BitConverter.ToUInt32(OneAnalogData, 0);
                    AnalyseValue = TempUInt32 * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.UInt32Reverse:
                    UInt32 TempUInt32Rev = MathConvertHelper.BitConverter.ToUInt32Reverse(OneAnalogData, 0);
                    AnalyseValue = TempUInt32Rev* AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.UInt64:
                    UInt64 TempUInt64 = MathConvertHelper.BitConverter.ToUInt64(OneAnalogData, 0);
                    AnalyseValue = TempUInt64 * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.UInt64Reverse:
                    UInt64 TempUInt64Rev = MathConvertHelper.BitConverter.ToUInt64Reverse(OneAnalogData, 0);
                    AnalyseValue = TempUInt64Rev * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Double:
                    Double TempDouble = MathConvertHelper.BitConverter.ToDouble(OneAnalogData, 0);
                    AnalyseValue = TempDouble * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.Single:
                    float TempFloat = MathConvertHelper.BitConverter.ToSingle(OneAnalogData, 0);
                    AnalyseValue = TempFloat * AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;
                    break;
                case AnalogDataAnalytical.SingleReverse:
                    float TempFloatRev = MathConvertHelper.BitConverter.ToSingleReverse(OneAnalogData, 0);
                    AnalyseValue = TempFloatRev* AnalogInfo.ScalingFactorA + AnalogInfo.ScalingFactorB;;
                    break;
                case AnalogDataAnalytical.StrType:
                    string TempStr = MathConvertHelper.BitConverter.ToASCIIString(OneAnalogData, 0);
                    AnalyseValue = TempStr;
                    break;
                case AnalogDataAnalytical.StrASCII:
                    string TempASCIIStr = MathConvertHelper.BitConverter.ToASCIIString(OneAnalogData, 0);
                    AnalyseValue = TempASCIIStr;
                    break;
                case AnalogDataAnalytical.StrUnicode:
                    string TempUnicodeStr = MathConvertHelper.BitConverter.ToUnicodeString(OneAnalogData, 0);
                    AnalyseValue = TempUnicodeStr;
                    break;
                case AnalogDataAnalytical.BCD16:
                    string TempBCDstr = MathConvertHelper.BitConverter.ToBCD16(OneAnalogData);
                    AnalyseValue = TempBCDstr;
                    break;
            }
            #endregion
            return AnalyseValue;
        }

        //模拟量报警
        private void AnalogAlarm(object AnalyseValue)
        {
            bool alarmcheckresult =false;
            AlarmEntity alarm = new AlarmEntity();
            alarm.OrigSource = AlarmEntity.AlarmSourceClass.AnalogSignal;
            alarm.SignalId = AnalogInfo.SignalId;
            alarm.MessageStr = AnalogInfo.SignalName + "";
            switch (AnalogInfo.AlarmConditions)
            {
                case AnalogAlarmConditionType.ValueLimitAlarm:
                    alarmcheckresult = AnalogLimitAlarm((double)AnalyseValue,ref alarm);
                    break;
                case AnalogAlarmConditionType.ValueChangeAlarm:
                    alarmcheckresult = AnalogChangeAlarm((double)AnalyseValue, ref alarm);
                    break;
                default:
                    break;
            }

            if (alarmcheckresult)
            {
                if (AnalogAlarmMethod != null)
                {
                    AnalogAlarmMethod.Invoke(alarm);
                }
            }

        }

        //限值告警
        private bool AnalogLimitAlarm(double AnalyseValue,ref AlarmEntity alarm)
        {
            bool result = false;
            string alamresult = LastalarmResult;
            if (AnalogInfo.LowerRange < AnalyseValue && AnalyseValue <= AnalogInfo.HigherRange)
            {
                alamresult= AnalogAlarmResultClass.OK;
                alarm.MessageStr += AnalogAlarmResultClass.OK;
            }
            else if (AnalyseValue > AnalogInfo.HighestRange)
            {
                alamresult= AnalogAlarmResultClass.GHH;
                alarm.MessageStr += AnalogAlarmResultClass.GHH;
            }
            else if (AnalogInfo.HigherRange < AnalyseValue && AnalyseValue <= AnalogInfo.HighestRange)
            {
                alamresult= AnalogAlarmResultClass.HHH;
                alarm.MessageStr += AnalogAlarmResultClass.HHH;
            }
            else if (AnalogInfo.LowerRange < AnalyseValue && AnalyseValue <= AnalogInfo.LowestRange)
            {
                alamresult= AnalogAlarmResultClass.LLL;
                alarm.MessageStr += AnalogAlarmResultClass.LLL;
            }
            else if (AnalyseValue <= AnalogInfo.LowestRange)
            {
                alamresult= AnalogAlarmResultClass.GLL;
                alarm.MessageStr += AnalogAlarmResultClass.GLL;
            }
            if (alamresult != LastalarmResult)
            {
                LastalarmResult = alamresult;
                result = true;
            }
            return result;
        }

        //值改变告警
        private bool AnalogChangeAlarm(double AnalyseValue, ref AlarmEntity alarm)
        {
            bool result = false;
            string alamresult = LastalarmResult;

            if (AnalyseValue !=Convert.ToDouble( AnalogInfo.Value))
            {
                alamresult = AnalogAlarmResultClass.ValueChange;
            }
            if (alamresult != LastalarmResult)
            {
                result = true;
                LastalarmResult = alamresult;
                switch (AnalogInfo.ValChFillAlarmStrType)
                {
                    case ValueChangeAlarmTypeClass.SystemState_InvertM3:
                        FillInvertM3SystemStateAlarmStr(ref alarm.MessageStr, AnalyseValue);
                        break;
                    case ValueChangeAlarmTypeClass.SystemState_Invert500k:
                        FillInvert500KSystemStateAlarmStr(ref alarm.MessageStr, AnalyseValue);
                        break;
                    default:
                        break;
                }
                
            }
            return result;
        }

        //依据太阳能逆变器小机系统状态填充告警字符串
        private void FillInvertM3SystemStateAlarmStr(ref string alarmstr, double AnalyseValue)
        {
            switch ((int)AnalyseValue)
            {
                case 0x00:
                    alarmstr += M3_SystemStateStringClass.CallWateMode;
                    break;
                case 0x01:
                    alarmstr += M3_SystemStateStringClass.Connecting;
                    break;
                case 0x02:
                    alarmstr += M3_SystemStateStringClass.GridConnected;
                    break;
                case 0x04:
                    alarmstr += M3_SystemStateStringClass.CloseMode;
                    break;
                case 0x08:
                    alarmstr += M3_SystemStateStringClass.WaitingOpen;
                    break;
                case 0x80:
                    alarmstr += M3_SystemStateStringClass.ErrorMode;
                    break;
                default:
                    alarmstr += M3_SystemStateStringClass.SystemState;
                    break;
            }
        }

        //依据太阳能逆变器大机系统状态填充告警字符串
        private void FillInvert500KSystemStateAlarmStr(ref string alarmstr, double AnalyseValue)
        {
            switch ((int)AnalyseValue)
            {
                case 0x00:
                    alarmstr += Invert500K_StateStringClass.StopMode;
                    break;
                case 0x01:
                    alarmstr += Invert500K_StateStringClass.RunMode;
                    break;
                default:
                    alarmstr += Invert500K_StateStringClass.SystemState;
                    break;
            }
        }
    }
}
