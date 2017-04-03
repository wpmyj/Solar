using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SolarMonitor.DeviceUI.Solar_PV;

namespace SolarMonitor.Solar_PV.UPS_ThreePhase
{
    public partial class UPSThreePhaseStatePage : DevExpress.XtraEditors.XtraUserControl
    {
        public class StateClass
        {
            public string Name;
            public string Normal;
            public string Fault;
        }

        public OneStateUserControl.SetInfo[] ThreePhaseStateArray = new OneStateUserControl.SetInfo[20];
        public StateClass[] StateStrArray = new StateClass[20];


        private void CreatArray()
        {
            for (int i = 0; i < ThreePhaseStateArray.Length; i++)
            {
                ThreePhaseStateArray[i] = new OneStateUserControl.SetInfo();
            }

            for (int i = 0; i < StateStrArray.Length; i++)
            {
                StateStrArray[i] = new StateClass();
            }
        }

        private void StateStrArrayInt()
        {
            #region by 师姐
            //int Index=1;
            //StateStrArray[Index].Name = "整流器状态";
            //StateStrArray[Index].Normal = "整流器运行正常";
            //StateStrArray[Index].Fault = "整流器运行异常";
            //Index++;

            //StateStrArray[Index].Name = "电池充电状态";
            //StateStrArray[Index].Normal = "电池浮充";
            //StateStrArray[Index].Fault = "电池均充";
            //Index++;

            //StateStrArray[Index].Name = "UPS运行模式";
            //StateStrArray[Index].Normal = "AC模式";
            //StateStrArray[Index].Fault = "电池模式";
            //Index++;

            //StateStrArray[Index].Name = "输入输出类型";
            //StateStrArray[Index].Normal = "三进三出";
            //StateStrArray[Index].Fault = "三进单出";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "电池电压低";//5
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "电池低压关机";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "输入相序反";
            //Index++;

            //StateStrArray[Index].Name = "逆变器运行情况";
            //StateStrArray[Index].Normal = "逆变器运行正常";
            //StateStrArray[Index].Fault = "逆变器运行异常";
            //Index++;

            //StateStrArray[Index].Name = "静态开关模式";
            //StateStrArray[Index].Normal = "旁路模式";
            //StateStrArray[Index].Fault = "逆变模式";
            //Index++;

            //StateStrArray[Index].Name = "旁路AC状态";
            //StateStrArray[Index].Normal = "旁路AC正常";
            //StateStrArray[Index].Fault = "旁路AC异常";//10
            //Index++;

            //StateStrArray[Index].Name = "旁路空开状态";
            //StateStrArray[Index].Normal = "旁路空开闭合";
            //StateStrArray[Index].Fault = "旁路空开断开";
            //Index++;

            //StateStrArray[Index].Name = "旁路频率状态";
            //StateStrArray[Index].Normal = "旁路频率正常";
            //StateStrArray[Index].Fault = "旁路频率异常";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "输出短路";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "机器过温";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "逆变输出电压故障";//15
            //Index++;

            //StateStrArray[Index].Name = ""; 
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "机器过载";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "旁路空开闭合关机";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "直流母线电压高";
            //Index++;

            //StateStrArray[Index].Name = "";
            //StateStrArray[Index].Normal = "";
            //StateStrArray[Index].Fault = "EPO紧急关机";
            //Index++;
            #endregion
            #region modified by zq
            int Index = 1;
            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.RectifierStatus;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.RectifierNormal;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.RectifierAbnormal;
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BattChargingStatus;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.BattFloatCharge;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BattAverageCharge;
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.UPSRunningMode;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.ACMode;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BattMode;
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.InputAndOutputType;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.ThreeThree;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.ThreeSingle;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BattLow;//5
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BattLowToShutdown;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.ReversePhaseSequence;
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.InverterStatus;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.InverterNormal;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.InverterAbnormal;
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.StaticSwitch;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.BypassMode;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.InverterMode;
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BypassACStatus;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.BypassACNormal;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BypassACAbnormal;//10
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BypAirSwitchStatus;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.BypAirSwitchClose;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BypAirSwitchBreak;
            Index++;

            StateStrArray[Index].Name = Model_Data.Language.UPS_ThreePhase.BypFreStatus;
            StateStrArray[Index].Normal = Model_Data.Language.UPS_ThreePhase.BypFreNormal;
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BypFreAbnormal;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.OutputShort;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.MachineOverTemperature;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.InvertorOutputVolFault;//15
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.MachineOverLoad;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.BypAirSwitchCloseAndShundown;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.DCBusVolHigh;
            Index++;

            StateStrArray[Index].Name = "";
            StateStrArray[Index].Normal = "";
            StateStrArray[Index].Fault = Model_Data.Language.UPS_ThreePhase.EPOUrgentOff;
            Index++;
            #endregion
        }

        public UPSThreePhaseStatePage()
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
            for (int i = 0; i < ThreePhaseStateArray.Length; i++)
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
                            stateUserControl.SetUserControlInfo(ThreePhaseStateArray[i]);
                        }
                    }
                }
            }
        }
    }
}
