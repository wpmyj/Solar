using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using Model_Data;
using SolarMonitor.MainForm.Sform;
using SolarMonitor.TabPage;

namespace SolarMonitor.MainForm
{
    public partial class Smachine : DevExpress.XtraEditors.XtraForm
    {
        string culture = ConfigurationManager.AppSettings["Culture"];

        //加载语言类信息
        private void LoadLanguageInfo()
        {
            //工具栏
            btStart.Caption = Model_Data.Language.SmachineForm.StartCommunicating;//开始通讯
            btStop.Caption = Model_Data.Language.SmachineForm.StopCommunicating;//停止通讯
            btSetting.Caption = Model_Data.Language.SmachineForm.ParaSetting;//参数设置
            btQuery.Caption = Model_Data.Language.SmachineForm.AddrSearching;//地址查询
            btVersion.Caption = Model_Data.Language.SmachineForm.SystemRelated;//系统相关
            btDocument.Caption = Model_Data.Language.SmachineForm.OperateDocument;//操作文档
            btExist.Caption = Model_Data.Language.SmachineForm.Exit;//退出系统
            barLargeButtonItem1.Caption = Model_Data.Language.ScheduleStr.scheduleManager;//排程管理

            //状态栏
            lbPortTitle.Caption = Model_Data.Language.SmachineForm.Port;
            lbIntervalTitle.Caption = Model_Data.Language.SmachineForm.Interval;
            lbEventTitle.Caption = Model_Data.Language.SmachineForm.Event;

        }
        //构造函数
        public Smachine()
        {
            InitializeComponent();//初始化组件
            LoadLanguageInfo();
            this.Text = "iSmartOffGrid";
            //this.WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1024, 768);
        }
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            //1.初始化基本信息
            MainContent1.LoadData();

            //2.初始化 一些事件订阅(回调函数)
            DeviceObj.RegistEventCallback(ShowAlarm);

            WorkStart(false);//第一次载入的时候开始通讯
        }

        private void WorkStart(bool isReload)
        {
            btStart.Enabled = false;
            btStop.Enabled = false;

            if (isReload)
                DeviceObj.ReLoad();
            //开启轮询
            DeviceObj.StartPoll();

            ShowState();

            btSetting.Enabled = false;
            btStop.Enabled = true;//使能 停止通讯
            btQuery.Enabled = false;//否能 地址搜索
        }

        #region 工具栏

        private void btStart_ItemClick(object sender, ItemClickEventArgs e)
        {
            btStart.Enabled = false;
            btStop.Enabled = false;

            //开启轮询
            DeviceObj.StartPoll();

            btSetting.Enabled = false;
            btStop.Enabled = true;//使能 停止通讯
            btQuery.Enabled = false;//否能 地址搜索
        }

        private void btStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            btStop.Enabled = false;//否能 停止通讯

            //停止轮询
            DeviceObj.StopPoll();

            lbEvent.Caption = string.Empty;
            btSetting.Enabled = true;
            btStart.Enabled = true;//使能 开始通讯
            btQuery.Enabled = true;//使能 地址搜索
        }

        private void btSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainForm.Sform.SettingForm Sm = new MainForm.Sform.SettingForm();
            Sm.StartPosition = FormStartPosition.CenterParent;
            if (Sm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                WorkStart(true);//开始通讯   
        }

        private void btQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            AutoSearchAddr adf = new AutoSearchAddr();
            adf.ShowDialog();
        }

        private void btVersion_ItemClick(object sender, ItemClickEventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void btDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            string thisPath = string.Empty;
            if (culture == "CN")
                thisPath = System.Windows.Forms.Application.StartupPath + "\\" + "DocCN.chm";
            else
                thisPath = System.Windows.Forms.Application.StartupPath + "\\" + "DocEN.chm";
            try
            {
                System.Diagnostics.Process.Start(thisPath);
            }
            catch
            {
                string ErrorMsg = Model_Data.Language.Desc.HelpFile + thisPath + "\r\n" + Model_Data.Language.Desc.NotOpen + "\r\n" + Model_Data.Language.Desc.NotExistFile;//modified by zq
                DevExpress.XtraEditors.XtraMessageBox.Show(ErrorMsg, Model_Data.Language.Desc.Fault_MainForm);
            }
        }

        private void btExist_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 状态栏

        AlertControl MSB = new AlertControl();

        private void ShowAlarm(AlarmEntity alarm)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                string AlertStr = string.Format("{0}---{1}", DateTime.Now.ToString(), alarm.MessageStr);
                try
                {                    
                    MSB.Show(this.FindForm(), Model_Data.Language.AlarmClass.Warning, AlertStr);
                    lbEvent.Appearance.ForeColor = alarm.Success ? Color.Green : Color.Red;
                    lbEvent.Caption = AlertStr;
                }
                catch (Exception ee)
                {
                    string sr = ee.ToString();
                }
            }));
        }

        private void ShowState()
        {
            DeviceModel DE = DeviceObj.GetDeviceModel();
            lbPort.Caption = DE.Port.PortName;
            lbInterval.Caption = (DE.Port.ScanningTime / 1000).ToString() + "(s)";
        }

        #endregion

        #region 主显区

        //主窗体变化
        private void Smachine_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                //this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        //单击任务栏图标
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        private void Smachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
        }
        //排程设置
        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormScheduleTask().ShowDialog();
        }

    }
}
