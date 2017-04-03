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

        //������������Ϣ
        private void LoadLanguageInfo()
        {
            //������
            btStart.Caption = Model_Data.Language.SmachineForm.StartCommunicating;//��ʼͨѶ
            btStop.Caption = Model_Data.Language.SmachineForm.StopCommunicating;//ֹͣͨѶ
            btSetting.Caption = Model_Data.Language.SmachineForm.ParaSetting;//��������
            btQuery.Caption = Model_Data.Language.SmachineForm.AddrSearching;//��ַ��ѯ
            btVersion.Caption = Model_Data.Language.SmachineForm.SystemRelated;//ϵͳ���
            btDocument.Caption = Model_Data.Language.SmachineForm.OperateDocument;//�����ĵ�
            btExist.Caption = Model_Data.Language.SmachineForm.Exit;//�˳�ϵͳ
            barLargeButtonItem1.Caption = Model_Data.Language.ScheduleStr.scheduleManager;//�ų̹���

            //״̬��
            lbPortTitle.Caption = Model_Data.Language.SmachineForm.Port;
            lbIntervalTitle.Caption = Model_Data.Language.SmachineForm.Interval;
            lbEventTitle.Caption = Model_Data.Language.SmachineForm.Event;

        }
        //���캯��
        public Smachine()
        {
            InitializeComponent();//��ʼ�����
            LoadLanguageInfo();
            this.Text = "iSmartOffGrid";
            //this.WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1024, 768);
        }
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            //1.��ʼ��������Ϣ
            MainContent1.LoadData();

            //2.��ʼ�� һЩ�¼�����(�ص�����)
            DeviceObj.RegistEventCallback(ShowAlarm);

            WorkStart(false);//��һ�������ʱ��ʼͨѶ
        }

        private void WorkStart(bool isReload)
        {
            btStart.Enabled = false;
            btStop.Enabled = false;

            if (isReload)
                DeviceObj.ReLoad();
            //������ѯ
            DeviceObj.StartPoll();

            ShowState();

            btSetting.Enabled = false;
            btStop.Enabled = true;//ʹ�� ֹͣͨѶ
            btQuery.Enabled = false;//���� ��ַ����
        }

        #region ������

        private void btStart_ItemClick(object sender, ItemClickEventArgs e)
        {
            btStart.Enabled = false;
            btStop.Enabled = false;

            //������ѯ
            DeviceObj.StartPoll();

            btSetting.Enabled = false;
            btStop.Enabled = true;//ʹ�� ֹͣͨѶ
            btQuery.Enabled = false;//���� ��ַ����
        }

        private void btStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            btStop.Enabled = false;//���� ֹͣͨѶ

            //ֹͣ��ѯ
            DeviceObj.StopPoll();

            lbEvent.Caption = string.Empty;
            btSetting.Enabled = true;
            btStart.Enabled = true;//ʹ�� ��ʼͨѶ
            btQuery.Enabled = true;//ʹ�� ��ַ����
        }

        private void btSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainForm.Sform.SettingForm Sm = new MainForm.Sform.SettingForm();
            Sm.StartPosition = FormStartPosition.CenterParent;
            if (Sm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                WorkStart(true);//��ʼͨѶ   
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

        #region ״̬��

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

        #region ������

        //������仯
        private void Smachine_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                //this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        //����������ͼ��
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
        //�ų�����
        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormScheduleTask().ShowDialog();
        }

    }
}
