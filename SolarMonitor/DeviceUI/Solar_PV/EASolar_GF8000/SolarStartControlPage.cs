using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Model_Data;
using Model_Data.CommunicateEntity;
using MathConvertHelper;
namespace SolarMonitor.Solar_PV.EASolar_GF8000
{
    public partial class SolarStartControlPage : DevExpress.XtraEditors.XtraUserControl
    {
        public DelegateEntity.SetInfoMethod SetInfoDelegate;

        #region 加载语言类信息
        private void LoadLanguageInfo()
        {
            Root.Text = Model_Data.Language.EaSolar.DevControlInfo;//设备控制信息
            rBtn_TestTen.Text = Model_Data.Language.EaSolar.BatteryTest1Min;//电池测试1分钟
            rBtn_LowPressureTest.Text = Model_Data.Language.EaSolar.BatteryLowVolTest;//电池低压测试
            rBtn_CancelTest.Text = Model_Data.Language.EaSolar.BatteryTestCancel;//取消测试
            rBtn_CancelTurnOff.Text = Model_Data.Language.EaSolar.ShutDownCanceling;//取消关机
            rBtn_TurnOn.Text = Model_Data.Language.EaSolar.SwitchOn;//开机
            rBtn_TimerNSend.Text = Model_Data.Language.EaSolar.ShutDown;//定时N分钟后关机
            rBtn_TimerSleep.Text = Model_Data.Language.EaSolar.Sleep;//睡眠N分钟
            bt_Confirm.Text = Model_Data.Language.EaSolar.OK_DevControl;//确定
        }
        #endregion
        public SolarStartControlPage()
        {
            InitializeComponent();
            LoadLanguageInfo();
            //checkEdit_TurnOn.Enabled = false;
            numericUpDownNMinu.Enabled = false;
            numericUpDown2.Enabled = false;
            rBtn_TestTen.Checked = true;
        }
        public void LoadShowInfo(bool commState)
        {
            if (commState)
            {
                rBtn_CancelTest.Enabled = true;
                rBtn_CancelTurnOff.Enabled = true;
                rBtn_LowPressureTest.Enabled = true;
                rBtn_TestTen.Enabled = true;
                rBtn_TimerNSend.Enabled = true;
                bt_Confirm.Enabled = true;

                rBtn_TurnOn.Enabled = true;
            }
            else
            {
                rBtn_CancelTest.Enabled = false;
                rBtn_CancelTurnOff.Enabled = false;
                rBtn_LowPressureTest.Enabled = false;
                rBtn_TestTen.Enabled = false;
                rBtn_TimerNSend.Enabled = false;
                bt_Confirm.Enabled = false;

                rBtn_TurnOn.Enabled = false;
            }
        }
        private void rBtn_TimerNSend_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_TimerNSend.Checked)
            {
                //checkEdit_TurnOn.Enabled = 1;
                numericUpDownNMinu.Enabled = true;
                numericUpDown2.Enabled = true;

            }
            else
            {
                //checkEdit_TurnOn.Enabled = false;
                numericUpDownNMinu.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }
        private void rBtn_TimerSleep_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_TimerSleep.Checked)
            {
                numericUpDownNMinu.Enabled = true;
            }
            else
            {
                numericUpDownNMinu.Enabled = false;
            }
        }

        //设置按钮
        private void bt_Confirm_Click(object sender, EventArgs e)
        {
            //电池测试10秒
            if (rBtn_TestTen.Checked)
            {
                byte[] Data = { 0xff, 0xff };
                SetInfoFunction(UPS_SetInfo_enum.ButteryTest10s, Data, FunctionCode.WriteSingleRegister);
                return;
            }

            //电池低压测试
            if (rBtn_LowPressureTest.Checked)
            {
                byte[] Data = { 0xff, 0xff };
                SetInfoFunction(UPS_SetInfo_enum.ButteryTestToLow, Data, FunctionCode.WriteSingleRegister);
                return;
            }

            //取消测试命令
            if (rBtn_CancelTest.Checked)
            {
                byte[] Data = { 0xff, 0xff };
                SetInfoFunction(UPS_SetInfo_enum.CancelTest, Data, FunctionCode.WriteSingleRegister);
                return;
            }

            //取消关机命令
            if (rBtn_CancelTurnOff.Checked)
            {
                byte[] Data = { 0xff, 0xff };
                SetInfoFunction(UPS_SetInfo_enum.CancelClose, Data, FunctionCode.WriteSingleRegister);
                return;
            }

            //定时N秒后关机
            if (rBtn_TimerNSend.Checked)
            {
                List<byte> Data = new List<byte>();
                short tempdata = (short)numericUpDown2.Value;
                Data.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(tempdata));
                SetInfoFunction(UPS_SetInfo_enum.ShutDownnsLater, Data.ToArray(), FunctionCode.WriteSingleRegister);
                return;
            }
            //睡眠多少分钟
            if (rBtn_TimerSleep.Checked)
            {
                List<byte> Data = new List<byte>();
                short tempdata = (short)numericUpDownNMinu.Value;
                Data.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(tempdata));
                SetInfoFunction(UPS_SetInfo_enum.RestartnsLater, Data.ToArray(), FunctionCode.WriteSingleRegister);

            }
            //开机命令
            if (rBtn_TurnOn.Checked)
            {
                byte[] Data = { 0xff, 0xff };
                SetInfoFunction(UPS_SetInfo_enum.TurnOnCommand, Data, FunctionCode.WriteSingleRegister);
            }
        }

        private void SetInfoFunction(UPS_SetInfo_enum SetInfoEnum, byte[] Data, FunctionCode functioncode, short RegisterLen = 1)
        {
            CommDeviceModbuseControlEntity SetDeviceInfo = new CommDeviceModbuseControlEntity();
            SetDeviceInfo.SetData = Data;
            SetDeviceInfo.SetInfoStartAdr = (short)SetInfoEnum;
            SetDeviceInfo.functioncode = functioncode;
            SetDeviceInfo.RegisterLen = RegisterLen;
            if (SetInfoDelegate != null)
            {
                //你确定要设置当前选择命令吗？
                if (XtraMessageBox.Show(Model_Data.Language.EaSolar.AreYouSureConfig, Model_Data.Language.EaSolar.Prompt, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //启用一个异步方法去发送命令，防止发送命令的等待（等待解锁或者发生死锁）
                    SetInfoDelegate.Invoke(SetDeviceInfo);
                    //AsyncCallback acl=new AsyncCallback(callback);
                    //SetInfoDelegate.BeginInvoke(SetDeviceInfo, acl, null);
                }
            }
            else
            {
                MessageBox.Show("no bind function--idbk");
            }
        }

        //异步调用的回调函数
        private void callback(IAsyncResult ar)
        { 
            //DelegateEntity.SetInfoMethod mySet=(DelegateEntity.SetInfoMethod)ar.AsyncState;
            //mySet.EndInvoke(ar);
        }

    }
}
