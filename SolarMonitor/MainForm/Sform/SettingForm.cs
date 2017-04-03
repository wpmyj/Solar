using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Model_Data;
using Model_Data.CommunicateEntity;
using Communication.CommunicateToLowerMonitor;

namespace SolarMonitor.MainForm.Sform
{
    public partial class SettingForm : DevExpress.XtraEditors.XtraForm
    {
        //加载语言显示信息类函数
        private void LoadLanguageFunction() //mark
        {
            this.Text = Model_Data.Language.ChildForm.ParaSetting;//参数设置
            this.group_Connect.Text = Model_Data.Language.ChildForm.ConnectSetting;//连接设置
            this.layoutControlItem12.Text = Model_Data.Language.ChildForm.PortSelect;//端口选择
            //this.layoutControlItem14.Text = Model_Data.Language.ChildForm.CommProtocol;//通讯协议
            //this.layoutControlItem13.Text = Model_Data.Language.ChildForm.DevSelection;//设备选择
            this.group_tcp.Text = Model_Data.Language.ChildForm.TCPIPSetting;//TCP/IP设置
            this.layoutControlItem4.Text = Model_Data.Language.ChildForm.IPAddr;//IP地址
            this.layoutControlItem5.Text = Model_Data.Language.ChildForm.PortNum;//端口号

            this.layoutControlItem6.Text = Model_Data.Language.Serial_Info_Set.BaudRate;//波特率
            this.layoutControlItem7.Text = Model_Data.Language.Serial_Info_Set.DataBit;//数据位
            this.layoutControlItem8.Text = Model_Data.Language.Serial_Info_Set.Parity;//校验位
            this.layoutControlItem9.Text = Model_Data.Language.Serial_Info_Set.StopBit;//停止位
            this.layoutControlItem16.Text = Model_Data.Language.Serial_Info_Set.ReTime;//回收等待时间
            this.group_serial.Text = Model_Data.Language.Serial_Info_Set.SerialInfo;//串口参数设置.

            this.bt_AdvanceOption.Text = Model_Data.Language.Serial_Info_Set.BtnAdvancedOption;//高级选项
            this.bt_Cancel.Text = Model_Data.Language.Serial_Info_Set.BtnCancel;//取消
            this.bt_Confirm.Text = Model_Data.Language.Serial_Info_Set.BtnOK;//确定
        }
        //构造函数
        public SettingForm()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            InitionSource();//初始化各个组件数据源
            //根据条件显示数据，并重新填充 实体
            InitionPortDevice();
            LoadLanguageFunction();//加载语言类函数 //mark
        }
        //初始化 各组件数据源
        private void InitionSource()
        {
            //添加通讯埠
            string[] PortsList = System.IO.Ports.SerialPort.GetPortNames();
            cb_Port.Properties.Items.Clear();
            cb_Port.Properties.Items.Add("USB");
            foreach (var item in PortsList)
            {
                cb_Port.Properties.Items.Add(item);
            }
            cb_Port.Properties.Items.Add("TCP/IP");
            cb_Port.SelectedIndex = 0;//默认选择第一个(USB)

            //端口号
            tb_TCPport.Text = "502";

            //波特率
            cb_BaudRate.Properties.Items.Add("1200");
            cb_BaudRate.Properties.Items.Add("2400");
            cb_BaudRate.Properties.Items.Add("4800");
            cb_BaudRate.Properties.Items.Add("9600");
            cb_BaudRate.Properties.Items.Add("14400");
            cb_BaudRate.SelectedIndex = 1;//默认选择2400
            //数据位
            cb_Word.Properties.Items.Add("7");
            cb_Word.Properties.Items.Add("8");
            cb_Word.SelectedIndex = 1;//默认选择8
            //校验位
            cb_Parit.Properties.DataSource = Table_ParityBit();
            cb_Parit.Properties.DisplayMember = "Text";
            cb_Parit.Properties.ValueMember = "Value";
            cb_Parit.EditValue = "0";//默认选择 校验位无
            //停止位
            cb_stop.Properties.DataSource = Table_StopBit();
            cb_stop.Properties.DisplayMember = "Text";
            cb_stop.Properties.ValueMember = "Value";
            cb_stop.EditValue = "1";//默认选择 停止位1    
            //回收等待时间
            tb_WaitTime.Text = "1000";
        }
        //根据条件填充实体，并显示
        private void InitionPortDevice()
        {
            DeviceModel dobj = DeviceObj.GetDeviceModel();
            TcpModel TCPE = dobj.Port.TCP;
            SerialModel SE = dobj.Port.Serial;
            if (dobj == null || TCPE == null || SE == null) return;
            //显示 端口值
            switch (dobj.Port.PortType)
            {
                case Protocol.Modbus_TCPIPPort: cb_Port.Text = "TCP/IP"; break;
                case Protocol.Modbus_SerialPort: cb_Port.Text = SE.PortName; break;
                case Protocol.Modbus_USBPort: cb_Port.Text = "USB"; break;
                default: break;
            }
            tb_IPadr.Text = TCPE.IP;
            tb_TCPport.Text = TCPE.Port.ToString();

            cb_BaudRate.Text = SE.BaudRate.ToString();
            cb_Word.Text = SE.DataBit.ToString();
            cb_Parit.EditValue = ((int)SE.Parity).ToString();
            cb_stop.EditValue = ((int)SE.StopBit).ToString();
            tb_WaitTime.Text = SE.RecoveryWaitTime.ToString();
        }
        //按键：取消
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //按键：确认
        private void bt_Confirm_Click(object sender, EventArgs e)
        {
            DeviceModel dm=DeviceObj.GetDeviceModel();
            if (dm == null) return;
            PortModel PE = dm.Port;
            PE.PortName = cb_Port.Text;

            if (group_tcp.Enabled) PE.PortType = Protocol.Modbus_TCPIPPort;
            else if (group_serial.Enabled) PE.PortType = Protocol.Modbus_SerialPort;
            else PE.PortType = Protocol.Modbus_USBPort;

            if (tb_IPadr.Text == string.Empty || tb_TCPport.Text == string.Empty)
            {
                XtraMessageBox.Show(Model_Data.Language.Serial_Info_Set.NoEmptyStr);
                return;
            }
            PE.TCP.IP = tb_IPadr.Text;
            PE.TCP.Port = Convert.ToInt32(tb_TCPport.Text);

            if (tb_WaitTime.Text == string.Empty)
            {
                XtraMessageBox.Show(Model_Data.Language.Serial_Info_Set.NoEmptyStr);
                return;
            }
            if (Convert.ToInt32(tb_WaitTime.Text) > PE.ScanningTime)
            {
                string er_scan_wait = string.Format(Model_Data.Language.Serial_Info_Set.WaitAndScanningTimeInfo1 + "{0}ms\r\n" + Model_Data.Language.Serial_Info_Set.WaitAndScanningTimeInfo2 + "{1}ms\r\n" + Model_Data.Language.Serial_Info_Set.WaitAndScanningTimeInfo3, PE.ScanningTime, tb_WaitTime.Text);
                XtraMessageBox.Show(er_scan_wait, Model_Data.Language.Serial_Info_Set.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PE.Serial.PortName = cb_Port.Text;
            PE.Serial.Parity = (System.IO.Ports.Parity)Convert.ToInt32(cb_Parit.EditValue);
            PE.Serial.StopBit = (System.IO.Ports.StopBits)Convert.ToInt32(cb_stop.EditValue);
            PE.Serial.DataBit = Convert.ToInt32(cb_Word.Text);
            PE.Serial.BaudRate = Convert.ToInt32(cb_BaudRate.Text);
            PE.Serial.RecoveryWaitTime = Convert.ToInt32(tb_WaitTime.Text);

            if (DeviceObj.UpdateDevice(dm))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.Serial_Info_Set.FailSelection);
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                this.Close();
            }
        }
        //通讯端口选择
        private void cb_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Port.Text == "TCP/IP")
            {
                group_tcp.Enabled = true;
                group_serial.Enabled = false;
            }
            else if (cb_Port.Text.Contains("COM"))
            {
                group_serial.Enabled = true;
                group_tcp.Enabled = false;
            }
            else if (cb_Port.Text.Contains("USB"))
            {
                group_serial.Enabled = false;
                group_tcp.Enabled = false;
            }
        }
        //高级选项----设置端口和设备 的具体参数
        private void bt_AdvanceOption_Click(object sender, EventArgs e)
        {
            Sform.AdvancedOptionForm AOF = new AdvancedOptionForm();
            AOF.ShowDialog();
        }


        // 停止位 数据源
        public static DataTable Table_StopBit()
        {
            DataTable T1 = new DataTable();
            DataColumn c0 = new DataColumn();
            c0.ColumnName = "Text";
            T1.Columns.Add(c0);
            DataColumn c1 = new DataColumn();
            c1.ColumnName = "Value";
            T1.Columns.Add(c1);
            DataRow r0 = T1.NewRow();
            r0["Text"] = "None";
            r0["Value"] = "0";
            T1.Rows.Add(r0);
            DataRow r1 = T1.NewRow();
            r1["Text"] = "One";
            r1["Value"] = "1";
            T1.Rows.Add(r1);
            DataRow r2 = T1.NewRow();
            r2["Text"] = "Two";
            r2["Value"] = "2";
            T1.Rows.Add(r2);
            DataRow r3 = T1.NewRow();
            r3["Text"] = "OnePointFive";
            r3["Value"] = "3";
            T1.Rows.Add(r3);
            T1.Columns[1].ColumnMapping = MappingType.Hidden;
            return T1;
        }

        //校验位 数据源
        public static DataTable Table_ParityBit()
        {
            DataTable T2 = new DataTable();
            DataColumn c0 = new DataColumn();
            c0.ColumnName = "Text";
            T2.Columns.Add(c0);
            DataColumn c1 = new DataColumn();
            c1.ColumnName = "Value";
            T2.Columns.Add(c1);
            DataRow r0 = T2.NewRow();
            r0["Text"] = "None";
            r0["Value"] = "0";
            T2.Rows.Add(r0);
            DataRow r1 = T2.NewRow();
            r1["Text"] = "Odd";
            r1["Value"] = "1";
            T2.Rows.Add(r1);
            DataRow r2 = T2.NewRow();
            r2["Text"] = "Even";
            r2["Value"] = "2";
            T2.Rows.Add(r2);
            DataRow r3 = T2.NewRow();
            r3["Text"] = "Mark";
            r3["Value"] = "3";
            T2.Rows.Add(r3);
            DataRow r4 = T2.NewRow();
            r4["Text"] = "Space";
            r4["Value"] = "4";
            T2.Rows.Add(r4);
            T2.Columns[1].ColumnMapping = MappingType.Hidden;
            return T2;
        }
    }
}
