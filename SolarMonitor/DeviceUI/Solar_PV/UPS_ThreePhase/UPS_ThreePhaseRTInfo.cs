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
    public partial class UPS_ThreePhaseRTInfo : DevExpress.XtraEditors.XtraUserControl
    {
        private const int UPSThreePhaseDataLen = 12;

        public OneCircularGaugeUserControl.SetInfo[] UPSThreePhaseInfoArray = new OneCircularGaugeUserControl.SetInfo[UPSThreePhaseDataLen];
        
        public UPS_ThreePhaseRTInfo()
        {
            InitializeComponent();
            CreatThreePhaseInfoArrayItem();
        }

        private void CreatThreePhaseInfoArrayItem()
        {
            for (int i = 0; i < UPSThreePhaseInfoArray.Length; i++)
            {
                UPSThreePhaseInfoArray[i] = new OneCircularGaugeUserControl.SetInfo();
            }
        }

        public void UpdateThreePhaseInfoView(Signal_Info.BasicInfo basic)
        {
            GrideUserControl1.SetUserControlInfo(UPSThreePhaseInfoArray[0], basic);
            GrideUserControl2.SetUserControlInfo(UPSThreePhaseInfoArray[1], basic);
            GrideUserControl3.SetUserControlInfo(UPSThreePhaseInfoArray[2], basic);
            GrideUserControl4.SetUserControlInfo(UPSThreePhaseInfoArray[3], basic);
            GrideUserControl5.SetUserControlInfo(UPSThreePhaseInfoArray[4], basic);
            GrideUserControl6.SetUserControlInfo(UPSThreePhaseInfoArray[5], basic);
            GrideUserControl7.SetUserControlInfo(UPSThreePhaseInfoArray[6], basic);
            GrideUserControl8.SetUserControlInfo(UPSThreePhaseInfoArray[7], basic);
            GrideUserControl9.SetUserControlInfo(UPSThreePhaseInfoArray[8], basic);
            GrideUserControl10.SetUserControlInfo(UPSThreePhaseInfoArray[9], basic);
            GrideUserControl11.SetUserControlInfo(UPSThreePhaseInfoArray[10], basic);
            GrideUserControl12.SetUserControlInfo(UPSThreePhaseInfoArray[11], basic);
        }
    }
}
