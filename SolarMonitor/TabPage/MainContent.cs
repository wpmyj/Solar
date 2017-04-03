using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraBars.Alerter;
using Model_Data;
using Communication.CommunicateToLowerMonitor;

namespace SolarMonitor.UserControl
{
    public partial class MainContent : DevExpress.XtraEditors.XtraUserControl
    {
        AlertControl MSB = new AlertControl();//用于弹出窗体

        //定义 实时显示界面     
        SolarMonitor.Solar_PV.EASolar UIOffGrid = new Solar_PV.EASolar();

        //加载语言类信息
        private void LoadLanguageInfo()
        {
            //tabPage
            this.xtraTabPage1.Text = Model_Data.Language.UserControl.RealData;//实时数据
            this.xtraTabPage3.Text = Model_Data.Language.UserControl.RealView;//实时曲线
            this.xtraTabPage4.Text = Model_Data.Language.UserControl.HisyView;//历史曲线
            this.xtraTabPage5.Text = Model_Data.Language.UserControl.HisyData;//历史数据
            this.xtraTabPage6.Text = Model_Data.Language.UserControl.HisEvent;//历史事件

            //Other
            //this.layoutControlItem1.Text = Model_Data.Language.UserControl.PortName;//端口名称
            //lbState.Text = Model_Data.Language.UserControl.CommunicateState;//通讯状态
            //lbInterval.Text = Model_Data.Language.UserControl.RefreshInvert;//刷新时间
            //this.btnPauseResume.Text = Model_Data.Language.UserControl.Suspend;//暂停刷新
            //this.bt_UIconvert.Text = Model_Data.Language.UserControl.FormView;//表格显示
        }

        public MainContent()
        {
            InitializeComponent();
            LoadLanguageInfo();//mark

            xtraTabPage1.Controls.Add(UIOffGrid);
            UIOffGrid.Dock = DockStyle.Fill;
        }

        public void LoadData()
        {
            realTimeLine1.LoadData();
            historicLine1.LoadData();
            Tab1Initional();
        }

        #region Tab1  实时数据显示

        private void Tab1Initional()
        {
            timer_RTValue.Interval =1000;
            timer_RTValue.Start();
        }
        //定时器刷新
        private void timer_RTValue_Tick(object sender, EventArgs e)
        {
            DeviceBll device = DeviceObj.GetDevice();
            DeviceModel dm = DeviceObj.GetDeviceModel();
            if (device == null)
                return;
            //视图界面更新
            UIOffGrid.SetParaMeter(device,dm);      
        }
      
        #endregion

    }
}
