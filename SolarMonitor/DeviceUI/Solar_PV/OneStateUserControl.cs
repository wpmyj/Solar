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
    public partial class OneStateUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public class SetInfo
        {
            public int Value = 0;//0表示正常，1表示异常，3为灰掉无通信,4为没有背景色
            public string Name = "系统状态";
        }

        private SetInfo UserControlSetInfo = new SetInfo();

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
                switch (UserControlSetInfo.Value)
                {
                    case 0:
                        stateIndicatorComponent1.StateIndex = 1;
                        this.label_Name.AppearanceText.TextBrush.Dispose();
                        this.label_Name.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkViolet");//BlueViolet
                        break;
                    case 1:
                        stateIndicatorComponent1.StateIndex = 2;
                        this.label_Name.AppearanceText.TextBrush.Dispose();
                        this.label_Name.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Snow");
                        break;
                    case 4:
                        stateIndicatorComponent1.StateIndex = 0;
                        this.label_Name.AppearanceText.TextBrush.Dispose();
                        this.label_Name.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Snow");
                        break;
                    case 3:
                    default:
                        stateIndicatorComponent1.StateIndex = 3;
                        this.label_Name.AppearanceText.TextBrush.Dispose();
                        this.label_Name.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkViolet");
                        break;

                }
                label_Name.Text = UserControlSetInfo.Name;
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

        public bool SetUserControlValue(int value)
        {
            UserControlSetInfo.Value = value;
            switch (UserControlSetInfo.Value)
            {
                case 0:
                    stateIndicatorComponent1.StateIndex = 1;
                    break;
                case 1:
                    stateIndicatorComponent1.StateIndex = 2;
                    break;
                case 2:
                    stateIndicatorComponent1.StateIndex = 3;
                    break;
                default:
                    stateIndicatorComponent1.StateIndex = 2;
                    break;
            }
            return true;
        }

        public OneStateUserControl()
        {
            InitializeComponent();
        }

    }
}
