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
    public partial class OnelinearGauge1Control : DevExpress.XtraEditors.XtraUserControl
    {
        #region 自定义
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState1 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState2 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState3 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState4 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState5 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState6 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState7 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState8 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState9 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState10 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState11 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState12 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState13 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState14 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState15 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState16 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState17 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState18 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState19 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        DevExpress.XtraGauges.Core.Model.ScaleIndicatorState scaleIndicatorState20 = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState();
        #endregion
        
        public class SetInfo
        {
            public double Value = 0;
            public string Name = "负载百分比";
            public string UnitName = "";
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
                if (Info.Value >0 &&Info.Value < 10)
                    Info.Value = 10;
                UserControlSetInfo.Value = Info.Value;
                UserControlSetInfo.Name = Info.Name;
                linearScaleComponent1.Value = Convert.ToSingle(UserControlSetInfo.Value);
                labelComponent1.Text = "";
                return true;
            }
            else
            {
                return false;
            }
        }

        public OnelinearGauge1Control()
        {
            InitializeComponent();
        }

        public void CreatLinearGaugeShow(Color color)
        {
            #region 初始化定义
            DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType[] type = new DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType[3];
            DevExpress.XtraGauges.Core.Model.ScaleIndicatorState[] state = new DevExpress.XtraGauges.Core.Model.ScaleIndicatorState[10];
            Color[] colorName = new Color[3];
            colorName[0] = color;
            colorName[1] = color;
            colorName[2] = color;

            for (int i = 0; i < 3; i++)
            {
                switch (colorName[i].Name)
                {
                    case "Red": type[i] = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2; break;
                    case "Yellow": type[i] = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer3; break;
                    case "Green": type[i] = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer4; break;
                }
            }
            #endregion
            #region 映射对应的格子
            state[0] = scaleIndicatorState1;
            state[1] = scaleIndicatorState3;
            state[2] = scaleIndicatorState5;
            state[3] = scaleIndicatorState7;
            state[4] = scaleIndicatorState9;
            state[5] = scaleIndicatorState11;
            state[6] = scaleIndicatorState13;
            state[7] = scaleIndicatorState15;
            state[8] = scaleIndicatorState17;
            state[9] = scaleIndicatorState19;
            #endregion

            for (int i = 0; i < 3; i++)
            {
                state[i].ShapeType = type[0];
            }
            for (int i = 3; i < 6; i++)
            {
                state[i].ShapeType = type[1];
            }
            for (int i = 6; i < 10; i++)
            {
                state[i].ShapeType = type[2];
            }

        }
    }
}
