using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SolarMonitor.DeviceUI.Solar_PV;

namespace SolarMonitor.Solar_PV.EASolar_GF8000
{
    public partial class EASolarStatePage : DevExpress.XtraEditors.XtraUserControl
    {
        public class StateClass
        {
            public string Name;
            public string Normal;
            public string Fault;
        }

        public OneStateUserControl.SetInfo[] StateArray = new OneStateUserControl.SetInfo[23];
        public StateClass[] StateStrArray=new StateClass[23];


        private void CreatArray()
        {
            for (int i = 0; i < StateArray.Length; i++)
            {
                StateArray[i] = new OneStateUserControl.SetInfo();
            }

            for (int i = 0; i < StateStrArray.Length; i++)
            {
                StateStrArray[i] = new StateClass();
            }
        }

        private void StateStrArrayInt()
        {
            #region by 师姐
            /*
            int temp = 0;
            StateStrArray[temp].Name = "AC状态";
            StateStrArray[temp].Normal = "AC正常";
            StateStrArray[temp].Fault = "AC故障";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "PV欠压";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "PV过压";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "PV反接";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "电池欠压";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "电池过放";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "电池故障";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "过载";
            temp++;
            StateStrArray[temp].Name = "AC充电状态";
            StateStrArray[temp].Normal = "AC充电关";
            StateStrArray[temp].Fault = "AC充电开";
            temp++;
            StateStrArray[temp].Name = "PV充电状态";
            StateStrArray[temp].Normal = "PV充电关";
            StateStrArray[temp].Fault = "PV充电开";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "过温保护";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "MPPT IGBT保护";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "母线故障";
            temp++;
            StateStrArray[temp].Name = "开关状态";
            StateStrArray[temp].Normal = "关机状态";
            StateStrArray[temp].Fault = "开机状态";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "倒计时关机激活";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "倒计时开机激活";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "电池过充保护";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "PV充电倒计时开启激活";
            temp++;
            StateStrArray[temp].Name = "AC频率模式";
            StateStrArray[temp].Normal = "AC频率锁相模式";
            StateStrArray[temp].Fault = "AC频率自振模式";
            temp++;
            StateStrArray[temp].Name = "整流器工作模式";
            StateStrArray[temp].Normal = "整流器工作模式";
            StateStrArray[temp].Fault = "PV和电池模式";
            temp++;
            StateStrArray[temp].Name = "优先工作模式";
            StateStrArray[temp].Normal = "AC优先工作模式";
            StateStrArray[temp].Fault = "PV优先工作模式";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "SPI故障";
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = "电池测试模式";
            temp++;
            */
            
            #endregion

            #region modified by zq
            int temp = 0;
            StateStrArray[temp].Name = Model_Data.Language.EaSolar.ACStatus;
            StateStrArray[temp].Normal = Model_Data.Language.EaSolar.ACNormal;
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.ACFault;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.PVLowVoltage;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.PVOverVoltage;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.PVReversed;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.BatteryLowVoltage;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.BatteryOverDisCharge;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.BatteryFault;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.OverLoad;
            temp++;
            StateStrArray[temp].Name = Model_Data.Language.EaSolar.ACChargingStatus;
            StateStrArray[temp].Normal = Model_Data.Language.EaSolar.ACChargingOff;
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.ACChargingOn;
            temp++;
            StateStrArray[temp].Name = Model_Data.Language.EaSolar.PVChargingStatus;
            StateStrArray[temp].Normal = Model_Data.Language.EaSolar.PVChargingOff;
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.PVChargingOn;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.ThermalProtection;//过问保护
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.MPPT_IGBTProtect;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.BUSFault;
            temp++;
            StateStrArray[temp].Name = Model_Data.Language.EaSolar.ON_OFFStatus;
            StateStrArray[temp].Normal = Model_Data.Language.EaSolar.OFFStatus;
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.ONStatus;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.ShutDownActive;//倒计时关机激活
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.PowerOnActive;//开机激活
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.BatteryOverChargeProtect;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.ActivateCountDownPVCharging;
            temp++;
            StateStrArray[temp].Name = Model_Data.Language.EaSolar.ACFrequencyMode ;
            StateStrArray[temp].Normal = Model_Data.Language.EaSolar.ACFrequencyPhaselockedMode;//锁相
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.ACFrequencySelfoscillationMode;//自振
            temp++;
            StateStrArray[temp].Name = Model_Data.Language.EaSolar.RectiferWorkMode;
            StateStrArray[temp].Normal = Model_Data.Language.EaSolar.RectiferWorkMode;
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.PVAndBatteryMode;
            temp++;
            StateStrArray[temp].Name = Model_Data.Language.EaSolar.PriorityMode;
            StateStrArray[temp].Normal = Model_Data.Language.EaSolar.ACPriorityMode;
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.PVPriorityMode;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.SPIFault;
            temp++;
            StateStrArray[temp].Name = "";
            StateStrArray[temp].Normal = "";
            StateStrArray[temp].Fault = Model_Data.Language.EaSolar.BatteryTestMode;
            temp++;
            #endregion
        }


        public EASolarStatePage()
        {
            InitializeComponent();
            CreatArray();
            StateStrArrayInt();
        }

        //更新状态的显示
        public void UpdateStateView()
        {
            string OneStateName = "oneStateUserControl";
            string FullStateName;
            int index;
            for (int i = 0; i < StateArray.Length; i++)
            {
                index = i + 1;
                FullStateName = OneStateName + index;
                foreach (var UserControl in layoutControl1.Controls)
                {
                    if (UserControl is OneStateUserControl)
                    {
                        OneStateUserControl stateUserControl = (OneStateUserControl)UserControl;
                        if (stateUserControl.Name == FullStateName)
                        {
                            stateUserControl.SetUserControlInfo(StateArray[i]);
                        }
                    }
                }
            }
        }
    }
}
