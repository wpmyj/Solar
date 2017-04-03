using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Model_Data.UI_Entity;
using Model_Data;
using Model_Data.CommunicateEntity;
namespace SolarMonitor.Solar_PV
{
    public partial class UPS_ThreePhasePage : SolarMonitor.DeviceUI.UI_DevicePublic
    {
        private class CommStateStr
        {
            //public const string Normal = "通讯正常";
            //public const string FailToSnmp = "本机与下位机通讯异常";
            //public const string FailToUPS = "SNMP卡与UPS通讯异常";
            public static string Normal = Model_Data.Language.UPS_ThreePhase.CommunicationNormal;
            public static string FailToSnmp = Model_Data.Language.UPS_ThreePhase.FailCommWithLowerMachine;
            public static string FailToUPS = Model_Data.Language.UPS_ThreePhase.FailCommBetweenUPSAndSNMPCard;
        }
        private enum CommStateInfo : uint
        {
            Normal = 0,
            FailToSnmp = 1,
            FailToUPS = 2
        };
        //private string[] threePhase = { "R相", "S相", "T相" };
        private string[] threePhase = { Model_Data.Language.UPS_ThreePhase.RPhase, 
                                          Model_Data.Language.UPS_ThreePhase.SPhase,
                                          Model_Data.Language.UPS_ThreePhase.TPhase };
        Signal_Info.BasicInfo basic = new Signal_Info.BasicInfo();
        private UI_Info UPS_Three_Info = null;

        public UPS_ThreePhasePage()
        {
            InitializeComponent();
            ArrayInt(CommStateInfo.Normal);
            RefreshPagesShow();
            upsControlPage1.SetInfoDelegate = SetInfoFunction;
            InPageDelegate = SetInfoResultFunction;
        }
        #region 初始化部分
        //其他实时数据初始化部分
        private void OtherRtInfoPageInt()//实时数据
        {
            #region by 师姐
            //int index=0;
            //OtherRtInfoPage.CircularArray[index].Name =  "电池电压";
            //OtherRtInfoPage.CircularArray[index].Value = 0;
            //OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            //OtherRtInfoPage.CircularArray[index].MinValue = 0;
            //OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            //OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Volt;
            //index++;
            //OtherRtInfoPage.CircularArray[index].Name = "电池充放电电流";
            //OtherRtInfoPage.CircularArray[index].Value = 0;
            //OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            //OtherRtInfoPage.CircularArray[index].MinValue = 0;
            //OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            //OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Current;
            //index++;
            //OtherRtInfoPage.CircularArray[index].Name = "电池剩余时间";
            //OtherRtInfoPage.CircularArray[index].Value = 0;
            //OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            //OtherRtInfoPage.CircularArray[index].MinValue = 0;
            //OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            //OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Minute;
            //index++;
            //OtherRtInfoPage.CircularArray[index].Name = "输入频率";
            //OtherRtInfoPage.CircularArray[index].Value = 0;
            //OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            //OtherRtInfoPage.CircularArray[index].MinValue = 0;
            //OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            //OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Frequency;
            //index++;
            //OtherRtInfoPage.CircularArray[index].Name = "旁路电源频率";
            //OtherRtInfoPage.CircularArray[index].Value = 0;
            //OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            //OtherRtInfoPage.CircularArray[index].MinValue = 0;
            //OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            //OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Frequency;
            //index++;
            //OtherRtInfoPage.CircularArray[index].Name = "输出频率";
            //OtherRtInfoPage.CircularArray[index].Value = 0;
            //OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            //OtherRtInfoPage.CircularArray[index].MinValue = 0;
            //OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            //OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Frequency;
            //index++;

            //OtherRtInfoPage.TemperatureArray[0].Name = "  温度";
            //OtherRtInfoPage.TemperatureArray[0].Value=0;
            //OtherRtInfoPage.TemperatureArray[0].MaxValue = 120;
            //OtherRtInfoPage.TemperatureArray[0].MinValue = -30;
            //OtherRtInfoPage.TemperatureArray[0].UnitName=UnitNameClass.Temperature;

            //OtherRtInfoPage.LineArray[0].Name = "电池容量百分比";
            //OtherRtInfoPage.LineArray[0].Value = 0;
            //OtherRtInfoPage.LineArray[0].UnitName = UnitNameClass.Percentage;
            #endregion

            #region modified by zq
            int index = 0;
            OtherRtInfoPage.CircularArray[index].Name = Model_Data.Language.UPS_ThreePhase.BatteryVoltage;
            OtherRtInfoPage.CircularArray[index].Value = 0;
            OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            OtherRtInfoPage.CircularArray[index].MinValue = 0;
            OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Volt;
            index++;
            OtherRtInfoPage.CircularArray[index].Name = Model_Data.Language.UPS_ThreePhase.BatteryChargingOrDischargingData;
            OtherRtInfoPage.CircularArray[index].Value = 0;
            OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            OtherRtInfoPage.CircularArray[index].MinValue = 0;
            OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Current;
            index++;
            OtherRtInfoPage.CircularArray[index].Name = Model_Data.Language.UPS_ThreePhase.BatterySurplusTime;
            OtherRtInfoPage.CircularArray[index].Value = 0;
            OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            OtherRtInfoPage.CircularArray[index].MinValue = 0;
            OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Minute;
            index++;
            OtherRtInfoPage.CircularArray[index].Name = Model_Data.Language.UPS_ThreePhase.InputFre;
            OtherRtInfoPage.CircularArray[index].Value = 0;
            OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            OtherRtInfoPage.CircularArray[index].MinValue = 0;
            OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Frequency;
            index++;
            OtherRtInfoPage.CircularArray[index].Name = Model_Data.Language.UPS_ThreePhase.BypassPowerFre;
            OtherRtInfoPage.CircularArray[index].Value = 0;
            OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            OtherRtInfoPage.CircularArray[index].MinValue = 0;
            OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Frequency;
            index++;
            OtherRtInfoPage.CircularArray[index].Name = Model_Data.Language.UPS_ThreePhase.OutputFre;
            OtherRtInfoPage.CircularArray[index].Value = 0;
            OtherRtInfoPage.CircularArray[index].MaxValue = 500;
            OtherRtInfoPage.CircularArray[index].MinValue = 0;
            OtherRtInfoPage.CircularArray[index].MajorTickCount = 6;
            OtherRtInfoPage.CircularArray[index].UnitName = UnitNameClass.Frequency;
            index++;

            OtherRtInfoPage.TemperatureArray[0].Name = Model_Data.Language.UPS_ThreePhase.Temperature;
            OtherRtInfoPage.TemperatureArray[0].Value = 0;
            OtherRtInfoPage.TemperatureArray[0].MaxValue = 120;
            OtherRtInfoPage.TemperatureArray[0].MinValue = -30;
            OtherRtInfoPage.TemperatureArray[0].UnitName = UnitNameClass.Temperature;

            OtherRtInfoPage.LineArray[0].Name = Model_Data.Language.UPS_ThreePhase.BatteryCapacityLevel;
            OtherRtInfoPage.LineArray[0].Value = 0;
            OtherRtInfoPage.LineArray[0].UnitName = UnitNameClass.Percentage;
            #endregion
        }

        private void ThreePhaseRtInfoPageInt()
        {
            #region by 师姐
            //int Index = 0;
            //for (int i = 0; i < 3; i++)
            //{
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + "输入电压";
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Volt;
            //    Index++;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + "旁路电压";
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Volt;
            //    Index++;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + "输出电压";
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Volt;
            //    Index++;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + "负载百分比";
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
            //    ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Percentage;
            //    Index++;
            //}
            #endregion

            #region modified by zq
            int Index = 0;
            for (int i = 0; i < 3; i++)
            {
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + Model_Data.Language.UPS_ThreePhase.InputVoltage;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Volt;
                Index++;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + Model_Data.Language.UPS_ThreePhase.BypassVoltage;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Volt;
                Index++;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + Model_Data.Language.UPS_ThreePhase.OutputVoltage;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Volt;
                Index++;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Name = threePhase[i] + Model_Data.Language.UPS_ThreePhase.LoadLevel;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].Value = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MaxValue = 500;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MinValue = 0;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].MajorTickCount = 6;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[Index].UnitName = UnitNameClass.Percentage;
                Index++;
            }
            #endregion

        }

        private void StatePageInt(CommStateInfo CommState)//状态信息
        {
            #region by 师姐
            //int Index=0;
            //if (CommState == CommStateInfo.Normal)
            //{
            //    StatePage.ThreePhaseStateArray[Index].Name = CommStateStr.Normal;
            //    StatePage.ThreePhaseStateArray[Index].Value = 0;
            //}
            //else if(CommState == CommStateInfo.FailToSnmp)
            //{
            //    StatePage.ThreePhaseStateArray[Index].Name =CommStateStr.FailToSnmp;
            //    StatePage.ThreePhaseStateArray[Index].Value = 1;
            //}
            //else if (CommState == CommStateInfo.FailToUPS)
            //{
            //    StatePage.ThreePhaseStateArray[Index].Name = CommStateStr.FailToUPS;
            //    StatePage.ThreePhaseStateArray[Index].Value = 1;
            //}
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "输入输出类型";
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "整流器运行状态";
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "逆变器运行状态";
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "电池充电状态";//4
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "UPS运行模式";
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "静态开关模式";
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "旁路AC状态";
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "旁路空开状态";
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;
            //StatePage.ThreePhaseStateArray[Index].Name = "旁路频率状态";//9
            //StatePage.ThreePhaseStateArray[Index].Value = 3;
            //Index++;

            //for (int i = 10; i < StatePage.ThreePhaseStateArray.Length; i++)
            //{
            //    StatePage.ThreePhaseStateArray[Index].Name = "";
            //    StatePage.ThreePhaseStateArray[Index].Value = 4;
            //    Index++;
            //}
            #endregion
            #region modified by zq
            int Index = 0;
            if (CommState == CommStateInfo.Normal)
            {
                StatePage.ThreePhaseStateArray[Index].Name = CommStateStr.Normal;
                StatePage.ThreePhaseStateArray[Index].Value = 0;
            }
            else if (CommState == CommStateInfo.FailToSnmp)
            {
                StatePage.ThreePhaseStateArray[Index].Name = CommStateStr.FailToSnmp;
                StatePage.ThreePhaseStateArray[Index].Value = 1;
            }
            else if (CommState == CommStateInfo.FailToUPS)
            {
                StatePage.ThreePhaseStateArray[Index].Name = CommStateStr.FailToUPS;
                StatePage.ThreePhaseStateArray[Index].Value = 1;
            }
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.InputAndOutputType;
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RectifierStatus;
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.InverterStatus;
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BattChargingStatus;//4
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.UPSRunningMode;
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.StaticSwitch;
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BypassACStatus;
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BypAirSwitchStatus;
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;
            StatePage.ThreePhaseStateArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BypFreStatus;//9
            StatePage.ThreePhaseStateArray[Index].Value = 3;
            Index++;

            for (int i = 10; i < StatePage.ThreePhaseStateArray.Length; i++)
            {
                StatePage.ThreePhaseStateArray[Index].Name = "";
                StatePage.ThreePhaseStateArray[Index].Value = 4;
                Index++;
            }
            #endregion
        }

        private void RateInfoPageInt()//额定信息
        {
            #region by 师姐
            //int Index = 0;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定输入电压";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定输入频率";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定旁路电压";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定旁路频率";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定输出电压";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定输出频率";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定电池电压";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "额定功率";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "厂家名称";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "UPS型号";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "UPS固件版本";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "SNMP卡固件版本";
            //Index++;
            //ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = "UPS输入输出相数";
            //Index++;
            //for (int i = 0; i < ThreePhaseRateInfoPage.UPSRateInfoArray.Length; i++)
            //{
            //    ThreePhaseRateInfoPage.UPSRateInfoArray[i].Value = "";
            //}
            #endregion
            #region modified by zq
            int Index = 0;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedInputVol;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedInputFre;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedBypVol;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedBypFre;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedOutputVol;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedOutputFre;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedBattVol;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RatedOutputPower;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.ManufacturerName;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.UPSModel;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.UPSFirmwareVer;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.SNMPCardFirmwareVer;
            Index++;
            ThreePhaseRateInfoPage.UPSRateInfoArray[Index].Name = Model_Data.Language.UPS_ThreePhase.UPSInputOutputPhase;
            Index++;
            for (int i = 0; i < ThreePhaseRateInfoPage.UPSRateInfoArray.Length; i++)
            {
                ThreePhaseRateInfoPage.UPSRateInfoArray[i].Value = "";
            }
            #endregion

        }

        private void ArrayInt(CommStateInfo CommState)
        {
            OtherRtInfoPageInt();
            ThreePhaseRtInfoPageInt();
            StatePageInt(CommState);
            RateInfoPageInt();
        }

        private void RefreshPagesShow()
        {
            OtherRtInfoPage.UpdateThreePhaseOtherRtInfoView(basic);
            ThreePhaseRTInfo.UpdateThreePhaseInfoView(basic);
            ThreePhaseRateInfoPage.UpdateThreePhaseRateInfoView(basic);
            StatePage.UpdateStateView();
        }

        #endregion

        public override void SetParaMeter(List<UI_Analog> AnalogSignalValueList, List<UI_Digital> DigitalSignalValueList, UI_Info Info)
        {
            basic.PortId = Info.PortId;
            basic.DeviceId = Info.DeviceId;
            basic.PortName = Info.PortName;
            basic.DeviceName = Info.DeviceName;
            CommStateInfo UPSCommState;
            bool ComminicationState = false;
            if (UPS_Three_Info == null)
            {
                UPS_Three_Info = Info;
            }
            if (Info.CommuState == DivCommStateEnum.Success)
            {
                ComminicationState = true;
                UPSCommState = CommStateInfo.Normal;
                if (AnalogSignalValueList != null && DigitalSignalValueList != null)
                {
                    UI_Analog[] AnalogArray = AnalogSignalValueList.ToArray();
                    UI_Digital[] DigitalArray = DigitalSignalValueList.ToArray();
                    //三相UPS状态信息框更新
                    StatePageInt(UPSCommState);
                    AnalogArray = AnalogSignalValueList.ToArray();
                    DigitalArray = DigitalSignalValueList.ToArray();
                    //设置数字量同时返回UPS与SNMP卡通讯状态
                    UPSCommState = SetDigitalData(DigitalArray);
                    if (UPSCommState == CommStateInfo.Normal)
                    {
                        //设置模拟量
                        SetAnalogData(AnalogArray);
                    }
                    else if (UPSCommState == CommStateInfo.FailToUPS)
                    {
                        ArrayInt(UPSCommState);
                    }

                }
            }
            else if (Info.CommuState == DivCommStateEnum.Failed)
            {
                ComminicationState = false;
                UPSCommState = CommStateInfo.FailToSnmp;
                ArrayInt(UPSCommState);
            }
            //UPS直接控制页面各控件使能与否
            upsControlPage1.LoadShowInfo(ComminicationState);
            //更新控制页面除外的其他页面
            RefreshPagesShow();
        }

        //设置模拟量
        private void SetAnalogData(UI_Analog[] AnalogArray)
        {
            if (AnalogArray.Length < 33)
                return;
            int SetIndex = 0;
            int AnalogIndex = 0;
            string CurrentValue;
            //三相实时数据
            SetThreePhaseAnalogData(AnalogArray, ref SetIndex, ref AnalogIndex);

            #region 电池电压
            SetIndex = 0;
            OtherRtInfoPage.CircularArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.CircularArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.CircularArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion

            #region 电池容量百分比
            SetIndex = 0; ;
            OtherRtInfoPage.LineArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.LineArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.LineArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion

            #region 电池剩余时间
            SetIndex = 2;
            OtherRtInfoPage.CircularArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.CircularArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.CircularArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion

            #region 电池充放电电流
            SetIndex = 1;
            OtherRtInfoPage.CircularArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.CircularArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.CircularArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion

            #region 机器温度
            SetIndex = 0;
            OtherRtInfoPage.TemperatureArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.TemperatureArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.TemperatureArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion

            #region 输入频率
            SetIndex = 3;
            OtherRtInfoPage.CircularArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.CircularArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.CircularArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion

            #region 旁路电源频率
            SetIndex = 4;
            OtherRtInfoPage.CircularArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.CircularArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.CircularArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion

            #region 输出频率
            SetIndex = 5;
            OtherRtInfoPage.CircularArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            CurrentValue = string.Format("{0:N1}", AnalogArray[AnalogIndex].SignalValue);
            OtherRtInfoPage.CircularArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
            OtherRtInfoPage.CircularArray[SetIndex].UnitName = AnalogArray[AnalogIndex].SignalUnit;
            AnalogIndex++;
            #endregion


            //额定信息与UPS其他信息
            for (int i = 0; i < ThreePhaseRateInfoPage.UPSRateInfoArray.Length - 1; i++)
            {
                ThreePhaseRateInfoPage.UPSRateInfoArray[i].Name = AnalogArray[AnalogIndex].SignalName;
                if (AnalogArray[AnalogIndex].SignalUnit != UnitNameClass.none)
                {
                    ThreePhaseRateInfoPage.UPSRateInfoArray[i].Value = AnalogArray[AnalogIndex].SignalValue.ToString() + AnalogArray[AnalogIndex].SignalUnit;

                }
                else
                {
                    ThreePhaseRateInfoPage.UPSRateInfoArray[i].Value = AnalogArray[AnalogIndex].SignalValue.ToString();
                }
                AnalogIndex++;
            }

            #region UPS输入输出相数
            SetIndex = 12;
            int tempint = Convert.ToInt32(AnalogArray[AnalogIndex].SignalValue);
            ThreePhaseRateInfoPage.UPSRateInfoArray[SetIndex].Name = AnalogArray[AnalogIndex].SignalName;
            if (tempint == 2)
            {
                ThreePhaseRateInfoPage.UPSRateInfoArray[SetIndex].Value = "三进单出";
            }
            else
            {
                ThreePhaseRateInfoPage.UPSRateInfoArray[SetIndex].Value = "三进三出";
            }
            AnalogIndex++;
            #endregion
        }

        private void SetThreePhaseAnalogData(UI_Analog[] AnalogArray, ref int SetIndex, ref int AnalogIndex)
        {
            string CurrentValue;
            int tempIndex = AnalogIndex;
            for (int i = 0; i < 3; i++)
            {
                tempIndex = AnalogIndex;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Name = AnalogArray[tempIndex].SignalName;
                CurrentValue = string.Format("{0:N1}", AnalogArray[tempIndex].SignalValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].UnitName = AnalogArray[tempIndex].SignalUnit;
                SetIndex++;

                tempIndex = AnalogIndex + 3;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Name = AnalogArray[tempIndex].SignalName;
                CurrentValue = string.Format("{0:N1}", AnalogArray[tempIndex].SignalValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].UnitName = AnalogArray[tempIndex].SignalUnit;
                SetIndex++;

                tempIndex = AnalogIndex + 6;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Name = AnalogArray[tempIndex].SignalName;
                CurrentValue = string.Format("{0:N1}", AnalogArray[tempIndex].SignalValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].UnitName = AnalogArray[tempIndex].SignalUnit;
                SetIndex++;

                tempIndex = AnalogIndex + 9;
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Name = AnalogArray[tempIndex].SignalName;
                CurrentValue = string.Format("{0:N1}", AnalogArray[tempIndex].SignalValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].Value = Convert.ToSingle(CurrentValue);
                ThreePhaseRTInfo.UPSThreePhaseInfoArray[SetIndex].UnitName = AnalogArray[tempIndex].SignalUnit;
                SetIndex++;
                AnalogIndex++;
            }
            AnalogIndex = tempIndex + 1;
        }

        //设置数字量
        private CommStateInfo SetDigitalData(UI_Digital[] DigitalArray)
        {
            if (DigitalArray.Length < 20)
                return CommStateInfo.FailToSnmp;
            int DigitalIndex;
            int SetIndex;
            int FaultSetIndex = 10;
            CommStateInfo CommState;

            DigitalIndex = 0;
            //SNMP与UPS的通讯状态
            CommState = SetSNMPCommState(DigitalArray[DigitalIndex]);
            DigitalIndex++;
            if (CommState == CommStateInfo.FailToUPS)
            {//若失败，返回端口状态，并退出数字量设置
                return CommState;
            }

            #region 整流器运行状态
            SetIndex = 2;
            SetOneData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            #endregion

            #region 电池充电状态
            SetIndex = 4;
            SetOneUPSMode(DigitalArray, ref DigitalIndex, ref SetIndex);
            #endregion

            #region UPS运行模式
            SetIndex = 5;
            SetOneUPSMode(DigitalArray, ref DigitalIndex, ref SetIndex);
            #endregion

            #region 输入输出类型
            SetIndex = 1;
            SetOneUPSMode(DigitalArray, ref DigitalIndex, ref SetIndex);
            #endregion

            #region 电池电压低
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 电池低电压关机
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 输入相序反
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 逆变器运行状态
            SetIndex = 3;
            SetOneData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            #endregion

            #region 静态开关模式
            SetIndex = 6;
            SetOneUPSMode(DigitalArray, ref DigitalIndex, ref SetIndex);
            #endregion

            #region 旁路AC状态
            SetIndex = 7;
            SetOneData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            #endregion

            #region 旁路空开状态
            SetIndex = 8;
            SetOneData(DigitalArray, ref  DigitalIndex, ref SetIndex);
            #endregion

            #region 旁路频率状态  0表示正常，1表示异常
            SetIndex = 9;
            if (DigitalArray[DigitalIndex].SignalValue == 0)
            {
                StatePage.ThreePhaseStateArray[SetIndex].Name = StatePage.StateStrArray[DigitalIndex].Normal;
                StatePage.ThreePhaseStateArray[SetIndex].Value = 0;
            }
            else
            {
                StatePage.ThreePhaseStateArray[SetIndex].Name = StatePage.StateStrArray[DigitalIndex].Fault;
                StatePage.ThreePhaseStateArray[SetIndex].Value = 1;
            }
            DigitalIndex++;
            #endregion

            #region 输出短路
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 过温
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 逆变器输出电压故障
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 过载
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 旁路空开闭合关机
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region 直流母线电压高
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            #region EPO紧急关机
            SetOneFaultDigital(DigitalArray, ref  DigitalIndex, ref FaultSetIndex);
            #endregion

            return CommState;

        }
        //设置SNMP卡与UPS通讯状态
        private CommStateInfo SetSNMPCommState(UI_Digital Digital)
        {
            CommStateInfo CommState = CommStateInfo.Normal;
            if (Digital.SignalValue == 1)
            {
                CommState = CommStateInfo.FailToUPS;
                StatePage.ThreePhaseStateArray[0].Name = CommStateStr.FailToUPS;
                StatePage.ThreePhaseStateArray[0].Value = 1;
            }
            return CommState;
        }

        //设置0值表示异常1值表示正常的量
        private void SetOneData(UI_Digital[] DigitalArray, ref int DigitalIndex, ref int SetIndex)
        {
            if (DigitalArray[DigitalIndex].SignalValue == 1)
            {
                StatePage.ThreePhaseStateArray[SetIndex].Name = StatePage.StateStrArray[DigitalIndex].Normal;
                StatePage.ThreePhaseStateArray[SetIndex].Value = 0;
            }
            else
            {
                StatePage.ThreePhaseStateArray[SetIndex].Name = StatePage.StateStrArray[DigitalIndex].Fault;
                StatePage.ThreePhaseStateArray[SetIndex].Value = 1;
            }
            DigitalIndex++;
        }

        //设置那些表示UPS运行方式的量
        private void SetOneUPSMode(UI_Digital[] DigitalArray, ref int DigitalIndex, ref int SetIndex)
        {
            if (DigitalArray[DigitalIndex].SignalValue == 0)
            {
                StatePage.ThreePhaseStateArray[SetIndex].Name = StatePage.StateStrArray[DigitalIndex].Normal;
                StatePage.ThreePhaseStateArray[SetIndex].Value = 0;
            }
            else
            {
                StatePage.ThreePhaseStateArray[SetIndex].Name = StatePage.StateStrArray[DigitalIndex].Fault;
                StatePage.ThreePhaseStateArray[SetIndex].Value = 0;
            }
            DigitalIndex++;
        }

        //设置那些只有错误意义的状态
        private void SetOneFaultDigital(UI_Digital[] DigitalArray, ref int DigitalIndex, ref int FaultSetIndex)
        {
            if (DigitalArray[DigitalIndex].SignalValue == 1)
            {
                StatePage.ThreePhaseStateArray[FaultSetIndex].Name = StatePage.StateStrArray[DigitalIndex].Fault;
                StatePage.ThreePhaseStateArray[FaultSetIndex].Value = 1;
                FaultSetIndex++;
            }
            DigitalIndex++;
        }

        #region 设置遥控量部分
        public void SetInfoResultFunction(object SetInfoResult)
        {
            CommDeviceModbuseControlEntity TempEntity;
            if (SetInfoResult is CommDeviceModbuseControlEntity)
            {
                TempEntity = (CommDeviceModbuseControlEntity)SetInfoResult;
                if (TempEntity.IsSuccess)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("设置成功");
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("设置失败");
                }
            }

        }

        private void SetInfoFunction(object SetInfo)
        {
            CommDeviceModbuseControlEntity TempEntity;
            if (SetInfo is CommDeviceModbuseControlEntity)
            {
                TempEntity = (CommDeviceModbuseControlEntity)SetInfo;
                if (UPS_Three_Info != null)
                {
                    TempEntity.PortID = UPS_Three_Info.PortId;
                    TempEntity.DivID = UPS_Three_Info.UnitId;
                    if (OutPageDelegate != null)
                    {
                        OutPageDelegate.Invoke(SetInfo);
                    }
                }
            }
        }
        #endregion
    }
}
