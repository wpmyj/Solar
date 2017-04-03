using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Model_Data;
using Communication.CommunicateToLowerMonitor;

namespace SolarMonitor.MainForm.Sform
{
    public partial class AdvancedOptionForm : DevExpress.XtraEditors.XtraForm
    {

        private DeviceModel DM;
        //加载语言显示信息类函数
        private void LoadLanguageFunction() //mark
        {
            this.Text = Model_Data.Language.Serial_Info_Set.BtnAdvancedOption;//Form 标题 “高级选项”
            this.groupControl1.Text = Model_Data.Language.Serial_Info_Set.Port;
            this.layoutControlItem8.Text = Model_Data.Language.Serial_Info_Set.PortName_Ad;
            this.layoutControlItem9.Text = Model_Data.Language.Serial_Info_Set.Description;
            this.layoutControlItem10.Text = Model_Data.Language.Serial_Info_Set.ScanningInterval;
            this.layoutControlItem11.Text = Model_Data.Language.Serial_Info_Set.OverTime;
            this.layoutControlItem12.Text = Model_Data.Language.Serial_Info_Set.ReconnectionTimes;
            this.layoutControlItem13.Text = Model_Data.Language.Serial_Info_Set.ResumeTime;
            this.layoutControlItem14.Text = Model_Data.Language.Serial_Info_Set.ReadOverTime;
            this.layoutControlItem15.Text = Model_Data.Language.Serial_Info_Set.WriteOverTime;

            this.groupControl2.Text = Model_Data.Language.Serial_Info_Set.Device;
            this.layoutControlItem7.Text = Model_Data.Language.Serial_Info_Set.DevName;
            this.layoutControlItem17.Text = Model_Data.Language.Serial_Info_Set.DevAddr;
            this.layoutControlItem16.Text = Model_Data.Language.Serial_Info_Set.WriteDataInterval;

            this.bt_Cancel.Text = Model_Data.Language.Serial_Info_Set.Cancel_Ad;
            this.bt_Confirm.Text = Model_Data.Language.Serial_Info_Set.Ok_Ad;
        }
        //构造函数
        public AdvancedOptionForm()
        {
            InitializeComponent();
            LoadLanguageFunction();
            InitionDeviceAddressBox();

            //绑定
            DM = DeviceObj.GetDeviceModel();
            if ( DM == null)
            {
                MessageBox.Show("Get Data Faild!");//这些代码应该永远不会被执行
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else
                LoadData();
        }

        //显示数据
        private void LoadData()
        {
            try
            {
                tb_PortName.Text = DM.Port.PortName;
                tb_Decribe.Text = DM.Port.Description;
                tb_PollTime.Text = DM.Port.ScanningTime.ToString();
                tb_Timeout.Text = DM.Port.OverTime.ToString();
                tb_ReconNum.Text = DM.Port.ReconnectNumber.ToString();
                tb_RecoverTime.Text = DM.Port.RecoveryTime.ToString();
                tb_ReadTimeout.Text = DM.Port.ReadOverTime.ToString();
                tb_WriteTimeout.Text = DM.Port.WriteOverTime.ToString();
            }
            catch (Exception er_port)
            {
                XtraMessageBox.Show(er_port.ToString());
            }

            try
            {
                tb_DeviceName.Text = DM.DeviceName;
                cb_DeviceAddr.Text = DM.UnitId.ToString();
                tb_WriteToDBtime.Text = DM.WriteDBTime.ToString();
            }
            catch (Exception er_device)
            {
                XtraMessageBox.Show(er_device.ToString());
            }

        }

        //初始化 设备地址下拉框
        private void InitionDeviceAddressBox()
        {
            cb_DeviceAddr.Properties.Items.Clear();
            for (int i = 1; i < 255; i++)
            {
                cb_DeviceAddr.Properties.Items.Add(i.ToString());
            }
        }

        //确定按键
        private void bt_Confirm_Click(object sender, EventArgs e)
        {
            if (!dxValidation_NoNull.Validate())
            {
                XtraMessageBox.Show(Model_Data.Language.Serial_Info_Set.NoEmptyStr);//modified by zq
                return;
            }
            //更新
            try
            {
                DM.Port.PortName = tb_PortName.Text;
                DM.Port.Description = tb_Decribe.Text;
                DM.Port.ScanningTime = Convert.ToInt32(tb_PollTime.Text);
                DM.Port.OverTime = Convert.ToInt32(tb_Timeout.Text);
                DM.Port.ReconnectNumber = Convert.ToInt32(tb_ReconNum.Text);
                DM.Port.RecoveryTime = Convert.ToInt32(tb_RecoverTime.Text);
                DM.Port.ReadOverTime = Convert.ToInt32(tb_ReadTimeout.Text);
                DM.Port.WriteOverTime = Convert.ToInt32(tb_WriteTimeout.Text);

                DM.DeviceName = tb_DeviceName.Text;
                DM.UnitId = (byte)Convert.ToInt32(cb_DeviceAddr.Text);
                DM.WriteDBTime = Convert.ToInt32(tb_WriteToDBtime.Text);
                DeviceObj.UpdateDevice(DM);
            }
            catch (Exception er_upDevice)
            {
                XtraMessageBox.Show(er_upDevice.ToString());
            }
            this.Close();
        }

        //取消按键
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}