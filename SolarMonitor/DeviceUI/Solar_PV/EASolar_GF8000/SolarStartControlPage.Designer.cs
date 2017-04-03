namespace SolarMonitor.Solar_PV.EASolar_GF8000
{
    partial class SolarStartControlPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">1 if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.rBtn_TimerSleep = new System.Windows.Forms.RadioButton();
            this.rBtn_TurnOn = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNMinu = new System.Windows.Forms.NumericUpDown();
            this.rBtn_TimerNSend = new System.Windows.Forms.RadioButton();
            this.rBtn_CancelTest = new System.Windows.Forms.RadioButton();
            this.bt_Confirm = new DevExpress.XtraEditors.SimpleButton();
            this.rBtn_TestTen = new System.Windows.Forms.RadioButton();
            this.rBtn_LowPressureTest = new System.Windows.Forms.RadioButton();
            this.rBtn_CancelTurnOff = new System.Windows.Forms.RadioButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNMinu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.layoutControl2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(398, 752);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.rBtn_TimerSleep);
            this.layoutControl2.Controls.Add(this.rBtn_TurnOn);
            this.layoutControl2.Controls.Add(this.numericUpDown2);
            this.layoutControl2.Controls.Add(this.numericUpDownNMinu);
            this.layoutControl2.Controls.Add(this.rBtn_TimerNSend);
            this.layoutControl2.Controls.Add(this.rBtn_CancelTest);
            this.layoutControl2.Controls.Add(this.bt_Confirm);
            this.layoutControl2.Controls.Add(this.rBtn_TestTen);
            this.layoutControl2.Controls.Add(this.rBtn_LowPressureTest);
            this.layoutControl2.Controls.Add(this.rBtn_CancelTurnOff);
            this.layoutControl2.Location = new System.Drawing.Point(2, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.Root;
            this.layoutControl2.Size = new System.Drawing.Size(394, 748);
            this.layoutControl2.TabIndex = 4;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // rBtn_TimerSleep
            // 
            this.rBtn_TimerSleep.Location = new System.Drawing.Point(12, 207);
            this.rBtn_TimerSleep.Name = "rBtn_TimerSleep";
            this.rBtn_TimerSleep.Size = new System.Drawing.Size(182, 25);
            this.rBtn_TimerSleep.TabIndex = 19;
            this.rBtn_TimerSleep.TabStop = true;
            this.rBtn_TimerSleep.Text = "睡眠多少分钟";
            this.rBtn_TimerSleep.UseVisualStyleBackColor = true;
            this.rBtn_TimerSleep.CheckedChanged += new System.EventHandler(this.rBtn_TimerSleep_CheckedChanged);
            // 
            // rBtn_TurnOn
            // 
            this.rBtn_TurnOn.Location = new System.Drawing.Point(12, 149);
            this.rBtn_TurnOn.Name = "rBtn_TurnOn";
            this.rBtn_TurnOn.Size = new System.Drawing.Size(370, 25);
            this.rBtn_TurnOn.TabIndex = 18;
            this.rBtn_TurnOn.TabStop = true;
            this.rBtn_TurnOn.Text = "开机";
            this.rBtn_TurnOn.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(198, 178);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(184, 22);
            this.numericUpDown2.TabIndex = 14;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownNMinu
            // 
            this.numericUpDownNMinu.Location = new System.Drawing.Point(198, 207);
            this.numericUpDownNMinu.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownNMinu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNMinu.Name = "numericUpDownNMinu";
            this.numericUpDownNMinu.Size = new System.Drawing.Size(184, 22);
            this.numericUpDownNMinu.TabIndex = 5;
            this.numericUpDownNMinu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rBtn_TimerNSend
            // 
            this.rBtn_TimerNSend.Location = new System.Drawing.Point(12, 178);
            this.rBtn_TimerNSend.Name = "rBtn_TimerNSend";
            this.rBtn_TimerNSend.Size = new System.Drawing.Size(182, 25);
            this.rBtn_TimerNSend.TabIndex = 10;
            this.rBtn_TimerNSend.TabStop = true;
            this.rBtn_TimerNSend.Text = "定时N(0-99)分钟后关机";
            this.rBtn_TimerNSend.UseVisualStyleBackColor = true;
            this.rBtn_TimerNSend.CheckedChanged += new System.EventHandler(this.rBtn_TimerNSend_CheckedChanged);
            // 
            // rBtn_CancelTest
            // 
            this.rBtn_CancelTest.Location = new System.Drawing.Point(12, 91);
            this.rBtn_CancelTest.Name = "rBtn_CancelTest";
            this.rBtn_CancelTest.Size = new System.Drawing.Size(370, 25);
            this.rBtn_CancelTest.TabIndex = 7;
            this.rBtn_CancelTest.TabStop = true;
            this.rBtn_CancelTest.Text = "取消测试命令";
            this.rBtn_CancelTest.UseVisualStyleBackColor = true;
            // 
            // bt_Confirm
            // 
            this.bt_Confirm.Location = new System.Drawing.Point(277, 236);
            this.bt_Confirm.Name = "bt_Confirm";
            this.bt_Confirm.Size = new System.Drawing.Size(77, 22);
            this.bt_Confirm.StyleController = this.layoutControl2;
            this.bt_Confirm.TabIndex = 16;
            this.bt_Confirm.Text = "确定";
            this.bt_Confirm.Click += new System.EventHandler(this.bt_Confirm_Click);
            // 
            // rBtn_TestTen
            // 
            this.rBtn_TestTen.Location = new System.Drawing.Point(12, 33);
            this.rBtn_TestTen.Name = "rBtn_TestTen";
            this.rBtn_TestTen.Size = new System.Drawing.Size(370, 25);
            this.rBtn_TestTen.TabIndex = 4;
            this.rBtn_TestTen.TabStop = true;
            this.rBtn_TestTen.Text = "电池测试1分钟";
            this.rBtn_TestTen.UseVisualStyleBackColor = true;
            // 
            // rBtn_LowPressureTest
            // 
            this.rBtn_LowPressureTest.Location = new System.Drawing.Point(12, 62);
            this.rBtn_LowPressureTest.Name = "rBtn_LowPressureTest";
            this.rBtn_LowPressureTest.Size = new System.Drawing.Size(370, 25);
            this.rBtn_LowPressureTest.TabIndex = 5;
            this.rBtn_LowPressureTest.TabStop = true;
            this.rBtn_LowPressureTest.Text = "电池低压测试";
            this.rBtn_LowPressureTest.UseVisualStyleBackColor = true;
            // 
            // rBtn_CancelTurnOff
            // 
            this.rBtn_CancelTurnOff.Location = new System.Drawing.Point(12, 120);
            this.rBtn_CancelTurnOff.Name = "rBtn_CancelTurnOff";
            this.rBtn_CancelTurnOff.Size = new System.Drawing.Size(370, 25);
            this.rBtn_CancelTurnOff.TabIndex = 8;
            this.rBtn_CancelTurnOff.TabStop = true;
            this.rBtn_CancelTurnOff.Text = "清除倒计时关机";
            this.rBtn_CancelTurnOff.UseVisualStyleBackColor = true;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "设备控制信息";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem15,
            this.layoutControlItem17,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem9});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(394, 748);
            this.Root.Text = "设备控制信息";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rBtn_TestTen;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(374, 29);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.rBtn_LowPressureTest;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(374, 29);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.rBtn_CancelTest;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 58);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(374, 29);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.rBtn_CancelTurnOff;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 87);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(374, 29);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.rBtn_TimerNSend;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 145);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(186, 29);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.numericUpDown2;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(186, 145);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(188, 29);
            this.layoutControlItem15.Text = "layoutControlItem15";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextToControlDistance = 0;
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.bt_Confirm;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new System.Drawing.Point(265, 203);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(81, 26);
            this.layoutControlItem17.Text = "layoutControlItem17";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextToControlDistance = 0;
            this.layoutControlItem17.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(346, 203);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(28, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 203);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(265, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 229);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(374, 478);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rBtn_TurnOn;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(374, 29);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.rBtn_TimerSleep;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 174);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(186, 29);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.numericUpDownNMinu;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(186, 174);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(188, 29);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(398, 752);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.layoutControl2;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(398, 752);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // SolarStartControlPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "SolarStartControlPage";
            this.Size = new System.Drawing.Size(398, 752);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNMinu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton bt_Confirm;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.RadioButton rBtn_TimerNSend;
        private System.Windows.Forms.RadioButton rBtn_CancelTurnOff;
        private System.Windows.Forms.RadioButton rBtn_CancelTest;
        private System.Windows.Forms.RadioButton rBtn_LowPressureTest;
        private System.Windows.Forms.RadioButton rBtn_TestTen;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.NumericUpDown numericUpDownNMinu;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.RadioButton rBtn_TurnOn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.RadioButton rBtn_TimerSleep;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
