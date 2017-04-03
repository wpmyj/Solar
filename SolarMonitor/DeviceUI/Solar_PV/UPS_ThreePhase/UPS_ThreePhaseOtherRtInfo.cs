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
    public partial class UPS_ThreePhaseOtherRtInfo : DevExpress.XtraEditors.XtraUserControl
    {
        public OneCircularGaugeUserControl.SetInfo[] CircularArray = new OneCircularGaugeUserControl.SetInfo[6];
        public OneTemperature_SetUp.SetInfo[] TemperatureArray = new OneTemperature_SetUp.SetInfo[1];
        public OnelinearGauge1Control.SetInfo[] LineArray = new OnelinearGauge1Control.SetInfo[1];

        private void CreatArrayItem()
        {
            for (int i = 0; i < CircularArray.Length; i++)
            {
                CircularArray[i] = new OneCircularGaugeUserControl.SetInfo();
            }

            for (int i = 0; i < TemperatureArray.Length; i++)
            {
                TemperatureArray[i] = new OneTemperature_SetUp.SetInfo();
            }

            for (int i = 0; i < LineArray.Length; i++)
            {
                LineArray[i] = new OnelinearGauge1Control.SetInfo();
            }
        }


        public UPS_ThreePhaseOtherRtInfo()
        {
            InitializeComponent();
            CreatArrayItem();
        }

        //更新其他实时数据的显示
        public void UpdateThreePhaseOtherRtInfoView(Signal_Info.BasicInfo basic)
        {
            CircularUserControl1.SetUserControlInfo(CircularArray[0], basic);
            CircularUserControl2.SetUserControlInfo(CircularArray[1], basic);
            CircularUserControl3.SetUserControlInfo(CircularArray[2], basic);
            CircularUserControl4.SetUserControlInfo(CircularArray[3], basic);
            CircularUserControl5.SetUserControlInfo(CircularArray[4], basic);
            CircularUserControl6.SetUserControlInfo(CircularArray[5], basic);

            label_Name1.Text = LineArray[0].Name;
            LineArray[0].Name = "";
            label_Value1.Text = LineArray[0].Value.ToString() + LineArray[0].UnitName;
            LineArray[0].UnitName = "";
            ShowCurrentCapacity(Convert.ToSingle(LineArray[0].Value));
            linearControl1.SetUserControlInfo(LineArray[0],basic);

            label_Name2.Text = TemperatureArray[0].Name;
            TemperatureArray[0].Name = "";
            label_Value2.Text = TemperatureArray[0].Value.ToString() + TemperatureArray[0].UnitName;
            TemperatureArray[0].UnitName = "";
            Temperature_SetUp2.SetUserControlInfo(TemperatureArray[0],basic);

        }
        //电池容量
        private void ShowCurrentCapacity(float value)
        {
            if (0 < value && value <= 20)
                linearControl1.CreatLinearGaugeShow(Color.Red);
            else if (20 < value && value <= 50)
                linearControl1.CreatLinearGaugeShow(Color.Yellow);
            else
                linearControl1.CreatLinearGaugeShow(Color.Green);
        }

    }
}
