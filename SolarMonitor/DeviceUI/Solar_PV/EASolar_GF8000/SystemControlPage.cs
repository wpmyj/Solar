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
    public partial class SystemControlPage : DevExpress.XtraEditors.XtraUserControl
    {
        public DelegateEntity.SetInfoMethod SetInfoDelegate;
        #region 加载语言类信息
        private void LoadLanguageInfo()
        {
            Root.Text = Model_Data.Language.EaSolar.SystemInfoSetting;//系统信息设置
            rBtn_DeviceUnitId.Text = Model_Data.Language.EaSolar.DevCommAddr;//设备通讯地址
            rBtn_DeviceBaud.Text = Model_Data.Language.EaSolar.DevCommBaud;//设备通讯波特率
            rBtn_ModbusTransMode.Text = Model_Data.Language.EaSolar.ModbusProtocolMode;//Modbus协议模式
            rBtn_CheckChoose.Text = Model_Data.Language.EaSolar.ParityBitCheck;//校验位选择
            rBtn_StopBitChoose.Text = Model_Data.Language.EaSolar.StopBitCheck;//停止位选择

            layoutControlGroup2.Text = Model_Data.Language.EaSolar.DateSettings;//日期设置
            layoutControlItem4.Text = Model_Data.Language.EaSolar.DevCurrentTime;//设备当前时间
            rBtn_DateSet.Text = Model_Data.Language.EaSolar.DaySetting_Radio;//日期设置
            layoutControlItem12.Text = Model_Data.Language.EaSolar.DaySetting;//日期设置
            rBtn_RecordDataClear.Text = Model_Data.Language.EaSolar.ClearRecords;//清空记录数据
            bt_Confirm.Text = Model_Data.Language.EaSolar.OK_SystemSetting;//确定
        }
        #endregion
        public SystemControlPage()
        {
            InitializeComponent();
            LoadLanguageInfo();
            numericUpDownDeviceId.Enabled = false;

            comboBoxBaud.Enabled = false;
            comboBoxProtocolMode.Enabled = false;
            comboBoxCheckBit.Enabled = false;
            comboBoxStopBit.Enabled = false;
            dateEdit_Date.Enabled = false;
            timeEdit_Time.Enabled = false;
            dateEdit_Date.EditValue = DateTime.Now;
            timeEdit_Time.EditValue = DateTime.Now;
        }
        public void LoadShowInfo(bool commState)
        {
            if (commState)
            {
                bt_Confirm.Enabled = true;

                rBtn_DateSet.Enabled = true;
                rBtn_DeviceUnitId.Enabled = true;
                rBtn_DeviceBaud.Enabled = true;
                rBtn_ModbusTransMode.Enabled = true;
                rBtn_CheckChoose.Enabled = true;
                rBtn_StopBitChoose.Enabled = true;
                //rBtn_PowerClear.Enabled= 1;
                rBtn_RecordDataClear.Enabled = true;
            }
            else
            {
                bt_Confirm.Enabled = false;

                rBtn_DateSet.Enabled = false;
                rBtn_DeviceUnitId.Enabled = false;
                rBtn_DeviceBaud.Enabled = false;
                rBtn_ModbusTransMode.Enabled = false;
                rBtn_CheckChoose.Enabled = false;
                rBtn_StopBitChoose.Enabled = false;
                //rBtn_PowerClear.Enabled = false;
                rBtn_RecordDataClear.Enabled = false;
            }
        }
        public void ShowMachineTime(DateTime dt)
        {
            dateEdit_Machine.EditValue = dt;
            timeEdit1.EditValue = dt;
        }
        //设置按钮
        private void bt_Confirm_Click(object sender, EventArgs e)
        {
            //设备通讯地址
            if (rBtn_DeviceUnitId.Checked)
            {
                List<byte> Data = new List<byte>();
                short tempdata = (short)numericUpDownDeviceId.Value;
                Data.AddRange(MathConvertHelper.BitConverter.GetBytesRevecse(tempdata));
                SetInfoFunction(UPS_SetInfo_enum.UPSAdr, Data.ToArray(), FunctionCode.WriteSingleRegister);

            }

            //通讯波特率
            if (rBtn_DeviceBaud.Checked)
            {
                byte[] Data = { 0x00, 0x00 };
                switch (comboBoxBaud.SelectedIndex)
                {
                    case 0:
                        Data[1] = 1;
                        break;
                    case 1:
                        Data[1] = 2;
                        break;
                    case 2:
                        Data[1] = 3;
                        break;
                    case 3:
                        Data[1] = 4;
                        break;
                    default:
                        //弹出警告窗
                        //DevExpress.XtraEditors.XtraMessageBox.Show("请选择正确的选项");
                        DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.EaSolar.SelectTheRightItem);
                        return;
                }
                SetInfoFunction(UPS_SetInfo_enum.UPSBaund, Data, FunctionCode.WriteSingleRegister);
            }
            //modbus通讯协议设置
            if (rBtn_ModbusTransMode.Checked)
            {
                byte[] Data = { 0x00, 0x00 };
                switch (comboBoxProtocolMode.SelectedIndex)
                {
                    case 0:
                        Data[0] = 0x00;
                        Data[1] = 0x00;
                        break;
                    case 1:
                        Data[0] = 0xff;
                        Data[1] = 0xff;
                        break;
                    default:
                        //弹出警告窗
                        //DevExpress.XtraEditors.XtraMessageBox.Show("请选择正确的选项");
                        DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.EaSolar.SelectTheRightItem);
                        return;
                }
                SetInfoFunction(UPS_SetInfo_enum.ModbusProtocolMode, Data, FunctionCode.WriteSingleRegister);
            }
            //校验位选择
            if (rBtn_CheckChoose.Checked)
            {
                byte[] Data = { 0x00, 0x00 };
                switch (comboBoxCheckBit.SelectedIndex)
                {
                    case 0:
                        Data[0] = 0x00;
                        Data[1] = 0x00;
                        break;
                    case 1:
                        Data[0] = 0x00;
                        Data[1] = 0x01;
                        break;
                    case 2:
                        Data[0] = 0x00;
                        Data[1] = 0x02;
                        break;
                    default:
                        //DevExpress.XtraEditors.XtraMessageBox.Show("请选择正确的选项");
                        DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.EaSolar.SelectTheRightItem);
                        return;
                }
                SetInfoFunction(UPS_SetInfo_enum.UPSCheckbit, Data, FunctionCode.WriteSingleRegister);
            }
            //停止位选择
            if (rBtn_StopBitChoose.Checked)
            {
                byte[] Data = { 0x00, 0x00 };
                switch (comboBoxStopBit.SelectedIndex)
                {
                    case 0:
                        Data[0] = 0x00;
                        Data[1] = 0x00;
                        break;
                    case 1:
                        Data[0] = 0x00;
                        Data[1] = 0x01;
                        break;
                    default:
                        //DevExpress.XtraEditors.XtraMessageBox.Show("请选择正确的选项");
                        DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.EaSolar.SelectTheRightItem);
                        return;

                }
                SetInfoFunction(UPS_SetInfo_enum.USPStopbit, Data, FunctionCode.WriteSingleRegister);
            }
            if (rBtn_DateSet.Checked)
            {
                //设置年份
                List<byte> TempList = new List<byte>();
                if (dateEdit_Date.EditValue != null && timeEdit_Time.EditValue != null)
                {
                    DateTime Date = Convert.ToDateTime(dateEdit_Date.EditValue);
                    DateTime Date_Time = Convert.ToDateTime(timeEdit_Time.EditValue);
                    AddIntToList(Date.Year, ref TempList);
                    AddIntToList(Date.Month, ref TempList);
                    AddIntToList(Date.Day, ref TempList);
                    AddIntToList(Date_Time.Hour, ref TempList);
                    AddIntToList(Date_Time.Minute, ref TempList);
                    AddIntToList(Date_Time.Second, ref TempList);
                    SetInfoFunction(UPS_SetInfo_enum.YearSet, TempList.ToArray(), FunctionCode.WriteMultipleRegisters, 6);
                }
            }
            //清空发电量数据
            //if (rBtn_PowerClear.Checked)
            //{
            //    byte[] Data = { 0xff, 0xff };
            //    SetInfoFunction(UPS_SetInfo_enum.ClearPowerRecord, Data , FunctionCode.WriteSingleRegister);
            //}
            //清空历史数据
            if (rBtn_RecordDataClear.Checked)
            {
                byte[] Data = { 0xff, 0xff };
                SetInfoFunction(UPS_SetInfo_enum.ClearDataRecodr, Data, FunctionCode.WriteSingleRegister);
            }
        }
        private void AddIntToList(int data, ref List<byte> List)
        {
            Int16 tempdata = (Int16)data;
            byte[] Data = MathConvertHelper.BitConverter.GetBytesRevecse(tempdata);
            List.AddRange(Data);
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
                    SetInfoDelegate.Invoke(SetDeviceInfo);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.EaSolar.SetFailure + "(BaseSetInfoPanel.SetInfoDelegate=null）");
            }
        }

        #region 单选框选择变化处理函数

        private void rBtn_DeviceUnitId_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_DeviceUnitId.Checked)
            {
                numericUpDownDeviceId.Enabled = true;
            }
            else
            {
                numericUpDownDeviceId.Enabled = false;
            }
        }

        private void rBtn_DeviceBaud_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_DeviceBaud.Checked)
            {
                comboBoxBaud.Enabled = true;
            }
            else
            {
                comboBoxBaud.Enabled = false;
            }
        }

        private void rBtn_ModbusTransMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_ModbusTransMode.Checked)
            {
                comboBoxProtocolMode.Enabled = true;
            }
            else
            {
                comboBoxProtocolMode.Enabled = false;
            }
        }

        private void rBtn_CheckChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_CheckChoose.Checked)
            {
                comboBoxCheckBit.Enabled = true;
            }
            else
            {
                comboBoxCheckBit.Enabled = false;
            }
        }

        private void rBtn_StopBitChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_StopBitChoose.Checked)
            {
                comboBoxStopBit.Enabled = true;
            }
            else
            {
                comboBoxStopBit.Enabled = false;
            }
        }

        #endregion
        #region 日期设置
        private void rBtn_DateSet_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_DateSet.Checked)
            {
                dateEdit_Date.Enabled = true;
                timeEdit_Time.Enabled = true;
            }
            else
            {
                dateEdit_Date.Enabled = false;
                timeEdit_Time.Enabled = false;
            }

        }
        #endregion
    }
}
