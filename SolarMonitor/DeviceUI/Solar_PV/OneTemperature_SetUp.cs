using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SolarMonitor.DeviceUI.Solar_PV
{
    public partial class OneTemperature_SetUp : DevExpress.XtraEditors.XtraUserControl
    {

        public class SetInfo
        {
            public float Value = 0;
            public string Name = "环境温度";
            public string UnitName = "℃";
            public float MaxValue = 100;
            public float MinValue = 0;
        }
        private SetInfo UserControlSetInfo = new SetInfo();

        public OneTemperature_SetUp()
        {
            InitializeComponent();
        }

        public bool SetUserControlInfo(SetInfo Info)
        {
            if (Info != null)
            {
                UserControlSetInfo.Value = Info.Value;
                UserControlSetInfo.Name = Info.Name;
                linearScaleComponent1.Value = UserControlSetInfo.Value;
                linearScaleComponent1.MaxValue = Info.MaxValue;
                linearScaleComponent1.MinValue = Info.MinValue;
                linearScaleComponent2.MaxValue = Info.MaxValue;
                linearScaleComponent2.MinValue = Info.MinValue;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
