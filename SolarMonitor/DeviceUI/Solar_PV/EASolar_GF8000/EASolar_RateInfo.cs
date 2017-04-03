using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Model_Data;

namespace SolarMonitor.Solar_PV.EASolar_GF8000
{
    public partial class EASolar_RateInfo : DevExpress.XtraEditors.XtraUserControl
    {
        //加载语言类信息
        private void LoadLanguageInfo()
        {
            layoutControlGroup2.Text = Model_Data.Language.EaSolar.RatedInfo;//额定信息
            layoutControlItem1.Text = Model_Data.Language.EaSolar.RatedVol;//额定电压
            layoutControlItem2.Text = Model_Data.Language.EaSolar.RatedBatteryVol;//额定电池电压

            layoutControlGroup3.Text = Model_Data.Language.EaSolar.ProductInfo;//产品信息
            layoutControlItem3.Text = Model_Data.Language.EaSolar.ProductType;//产品类型
            layoutControlItem4.Text = Model_Data.Language.EaSolar.ProductModel;//产品规格型号
            layoutControlItem5.Text = Model_Data.Language.EaSolar.ChargingCurrentLevel;//充电电流等级

            layoutControlItem6.Text = Model_Data.Language.EaSolar.CommuVersion;//通信板版本号
            layoutControlItem7.Text = Model_Data.Language.EaSolar.ControlVersion;//控制板版本号
        }

        public EASolar_RateInfo()
        {
            InitializeComponent();
            LoadLanguageInfo();
        }

        //更新数据接口
        public void RefreshData(List<AnalogModel> AnalogArray)
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
                textBox6.Text = "v0.9";
            else
                textBox6.Text = ((int)(vcount / 16)).ToString() + "." + (vcount % 16).ToString();

            //产品类型
            string preStr = AnalogArray[14].Value.ToString();
            string nextStr = AnalogArray[15].Value.ToString();
            string str = nextStr;//默认显示14个字符
            if (s2 == "V")
                str = preStr + nextStr;//新版本情况下显示16个字符 
            textBox3.Text = str;
  
            //产品规格型号
            textBox4.Text=AnalogArray[16].Value.ToString();

            //额定电池额定
            textBox2.Text = AnalogArray[17].Value.ToString()+"V";

            //额定电压
            textBox1.Text = AnalogArray[18].Value.ToString()+"V";

            //充电电流等级            
            textBox5.Text = getIstr(AnalogArray[19].Value.ToString());

            //显示 控制版本号
            textBox7.Text = AnalogArray[0].Value.ToString();
        }

        private string getIstr(string svalue)
        {            
            if (svalue == null)
                return string.Empty;
            int i;
            if (!Int32.TryParse(svalue,out i))
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
