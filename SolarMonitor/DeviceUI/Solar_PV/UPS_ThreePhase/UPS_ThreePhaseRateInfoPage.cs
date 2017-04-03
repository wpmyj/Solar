using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
namespace SolarMonitor.Solar_PV.UPS_ThreePhase
{
    public partial class UPS_ThreePhaseRateInfoPage : DevExpress.XtraEditors.XtraUserControl
    {
        public class SetInfo
        {
            public string Name;
            public string Value;
        }

        public SetInfo[] UPSRateInfoArray=new SetInfo[13];

        private void CreatArray()
        {
            for (int i = 0; i < UPSRateInfoArray.Length; i++)
            {
                UPSRateInfoArray[i] = new SetInfo();
            }
        }

        public UPS_ThreePhaseRateInfoPage()
        {
            InitializeComponent();
            CreatArray();
        }

        //更新其他实时数据的显示
        public void UpdateThreePhaseRateInfoView(Signal_Info.BasicInfo basic)
        {
            string TextBoxName = "textBox";
            string FullTextBoxName;

            string ControlItemName = "layoutControlItem";
            string FullControlItemName;

            int index;
            bool flage = false;
            for (int i = 0; i < UPSRateInfoArray.Length; i++)
            {
                index = i + 1;
                flage = false;
                FullTextBoxName = TextBoxName + index;
                FullControlItemName = ControlItemName + index;
                foreach (var UserControl in layoutControl1.Controls) 
                {
                    if (UserControl is TextBox)
                    {
                        TextBox textBox = (TextBox)UserControl;
                        if (textBox.Name == FullTextBoxName)
                        {
                            textBox.Text = UPSRateInfoArray[i].Value;
                            break;
                        }
                    }
                }
                foreach (var LayoutControlItem in layoutControlGroup2.Items)
                {
                    if (LayoutControlItem is LayoutItem)
                    {
                        LayoutItem layoutItem = (LayoutItem)LayoutControlItem;
                        if (layoutItem.Name == FullControlItemName)
                        {
                            layoutItem.Text = UPSRateInfoArray[i].Name;
                            flage = true;
                            break;
                        }
                    }
                }
                if (!flage)
                {
                    foreach (var LayoutControlItem in layoutControlGroup3.Items)
                    {
                        if (LayoutControlItem is LayoutItem)
                        {
                            LayoutItem layoutItem = (LayoutItem)LayoutControlItem;
                            if (layoutItem.Name == FullControlItemName)
                            {
                                layoutItem.Text = UPSRateInfoArray[i].Name;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
