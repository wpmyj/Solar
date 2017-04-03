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
    public partial class OneTemperature : DevExpress.XtraEditors.XtraUserControl
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

        public OneTemperature()
        {
            InitializeComponent();
        }

        public SetInfo GetUserControlInfo()
        {
            return UserControlSetInfo;
        }

        public bool SetUserControlInfo(SetInfo Info)
        {
            if (Info != null)
            {
                UserControlSetInfo.Value = Info.Value;
                UserControlSetInfo.Name = Info.Name;                
                label_Name.Text = UserControlSetInfo.Name;
                linearScaleComponent1.Value = UserControlSetInfo.Value;
                linearScaleComponent1.MaxValue = Info.MaxValue;
                linearScaleComponent1.MinValue = Info.MinValue;
                linearScaleComponent2.MaxValue = Info.MaxValue;
                linearScaleComponent2.MinValue = Info.MinValue;
                label_Value.Text = UserControlSetInfo.Value.ToString() + UserControlSetInfo.UnitName;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetUserControlName(string name)
        {
            UserControlSetInfo.Name = name;
            label_Name.Text = UserControlSetInfo.Name;
            return true;
        }

        public bool SetUserControlValue(float value)
        {
            UserControlSetInfo.Value = value;
            linearScaleComponent1.Value = UserControlSetInfo.Value;
            label_Value.Text = UserControlSetInfo.Value.ToString() + "℃";
            return true;
        }

    }
}
