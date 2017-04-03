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
    public partial class OneCircularGaugeUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        public class SetInfo
        {
            public float Value = 0;
            public float MinValue = 0;
            public float MaxValue = 100;
            public int MajorTickCount = 9;
            public string UnitName = "W";
            public string Name = "总输入功率";
            public string Text = "总输入功率";
        }

        public OneCircularGaugeUserControl()
        {
            InitializeComponent();
        }

        public void SetUserControlInfo(SetInfo Info)
        {
            if (Info != null)
            {
                arcScaleComponent1.MaxValue = Info.MaxValue;
                arcScaleComponent1.MinValue = Info.MinValue;
                label_Name.Text = Info.Name;
                arcScaleComponent1.Value = Info.Value;
                label_Value.Text = Info.Value.ToString() + Info.UnitName;
                arcScaleComponent1.MajorTickCount = Info.MajorTickCount;
            }
        }

        public void SetValue(float sValue,string unitName)
        {
            arcScaleComponent1.Value = sValue;
            label_Value.Text = sValue.ToString() + unitName;
        }

    }
}
