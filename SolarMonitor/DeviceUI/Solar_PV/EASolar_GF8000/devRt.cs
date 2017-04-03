using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Model_Data;

namespace SolarMonitor.DeviceUI.Solar_PV.EASolar_GF8000
{
    public partial class devRt : DevExpress.XtraEditors.XtraUserControl
    {
        public devRt()
        {
            InitializeComponent();

            groupControl1.Text = Model_Data.Language.EaSolar.ACInfo_Tab;
            groupControl2.Text = Model_Data.Language.EaSolar.PVInfo;//PV信息
        }

        //还原为最初状态
        public void Inition()
        {
            foreach (Control item in tableLayoutPanel2.Controls)
            {
                if (item is System.Windows.Forms.Button)
                {
                    ((Button)item).Text= "0";
                }                
            }
            foreach (Control item in tableLayoutPanel3.Controls)
            {
                if (item is System.Windows.Forms.Button)
                {
                    ((Button)item).Text = "0";
                }
            }

            DeviceModel dm= DeviceObj.GetDeviceModel();
            if (dm == null) return;

            List<AnalogModel> AnalogArray = dm.Analog;

            //AC输入电压            
            label2.Text = AnalogArray[1].SignalName;

            //逆变输出电压            
            label5.Text = AnalogArray[2].SignalName;


            //AC输入频率            
            label9.Text = AnalogArray[3].SignalName;

            //--------------------------------------------

            //PV输入电压
            label10.Text = AnalogArray[6].SignalName;

            //负载百分比
            label11.Text = AnalogArray[4].SignalName;

            //电池容量百分比
            label12.Text = AnalogArray[9].SignalName;

            //PV充电电流
            label13.Text = AnalogArray[7].SignalName;

            //额定电压
            label14.Text = AnalogArray[18].SignalName;

            //额定电池额定
            label15.Text = AnalogArray[17].SignalName;

            //--------------------------------------------

            //产品类型
            label16.Text = AnalogArray[15].SignalName;

            //产品规格型号
            label17.Text = AnalogArray[16].SignalName;

            //充电电流等级
            label18.Text = AnalogArray[19].SignalName;

            //通讯版本号
            label19.Text = AnalogArray[25].SignalName;

            //控制版本号
            label20.Text = AnalogArray[0].SignalName;

        }

        //更新数据接口
        public void RefreshData(List<AnalogModel> AnalogArray)
        {
            //
            refreshAC(AnalogArray);

            refreshPV(AnalogArray);

            refreshRated(AnalogArray);
        }

        private void refreshAC(List<AnalogModel> AnalogArray)
        {      
            //AC输入电压
            button2.Text = AnalogArray[1].Value.ToString() + " V";                   

            //逆变输出电压
            button5.Text = AnalogArray[2].Value.ToString() + " V";                    

            //AC输入频率
            button9.Text = AnalogArray[3].Value.ToString() + " Hz";            

        }

        private void refreshPV(List<AnalogModel> AnalogArray)
        {
            //PV输入电压
            button10.Text = AnalogArray[6].Value.ToString()+" V";            

            //负载百分比
            button11.Text = AnalogArray[4].Value.ToString() + "%";            

            //电池容量百分比
            button12.Text = AnalogArray[9].Value.ToString() + "%";            

            //PV充电电流
            button13.Text = AnalogArray[7].Value.ToString() + " A";            

            //额定电压
            button14.Text = AnalogArray[18].Value.ToString() + " V";            

            //额定电池额定
            button15.Text = AnalogArray[17].Value.ToString() + " V";
            
        }

        private void refreshRated(List<AnalogModel> AnalogArray)
        {
            //显示 通讯版本号
            object innerVersion = AnalogArray[25].Value;//获取 内部版本号
            UInt16 inner;
            string s2 = string.Empty;// 存放V    
            UInt16 vcount = 0;
            if (UInt16.TryParse(innerVersion.ToString(), out inner))
            {
                byte[] doubleBuff = BitConverter.GetBytes(inner);
                s2 = System.Text.Encoding.Default.GetString(doubleBuff, 1, 1);
                vcount = Convert.ToUInt16(doubleBuff[0]);
            }
            if (s2 != "V")
                textEdit4.Text = "v0.9";
            else
                textEdit4.Text = ((int)(vcount / 16)).ToString() + "." + (vcount % 16).ToString();

            //产品类型
            string preStr = AnalogArray[14].Value.ToString();
            string nextStr = AnalogArray[15].Value.ToString();
            string str = nextStr;//默认显示14个字符
            if (s2 == "V")
                str = preStr + nextStr;//新版本情况下显示16个字符 
            textEdit1.Text = str;

            //产品规格型号
            textEdit2.Text = AnalogArray[16].Value.ToString();

            //充电电流等级            
            textEdit3.Text = getIstr(AnalogArray[19].Value.ToString());

            //显示 控制版本号
            textEdit5.Text = AnalogArray[0].Value.ToString();
        }

        private string getIstr(string svalue)
        {
            if (svalue == null)
                return string.Empty;
            int i;
            if (!Int32.TryParse(svalue, out i))
                return string.Empty;
            string rvalue = string.Empty;
            switch (i)
            {
                case 1:
                    rvalue = "1 (00)";
                    break;
                case 2:
                    rvalue = "2 (01)";
                    break;
                case 3:
                    rvalue = "3 (10)";
                    break;
                case 4:
                    rvalue = "4 (11)";
                    break;
                default:
                    break;
            }
            return rvalue;
        }


    }
}
