namespace SolarMonitor.TabPage
{
    partial class AddTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labTaskDate = new System.Windows.Forms.Label();
            this.groupFrequency = new System.Windows.Forms.GroupBox();
            this.radWeekly = new System.Windows.Forms.RadioButton();
            this.radBtnEveDay = new System.Windows.Forms.RadioButton();
            this.radBtnOneDay = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupTask = new System.Windows.Forms.GroupBox();
            this.radStartInverter = new System.Windows.Forms.RadioButton();
            this.radCloseInverter = new System.Windows.Forms.RadioButton();
            this.radioVoltage = new System.Windows.Forms.RadioButton();
            this.AddOK = new System.Windows.Forms.Button();
            this.AddCancel = new System.Windows.Forms.Button();
            this.groupFrequency.SuspendLayout();
            this.groupTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTaskDate
            // 
            this.labTaskDate.AutoSize = true;
            this.labTaskDate.Location = new System.Drawing.Point(19, 12);
            this.labTaskDate.Name = "labTaskDate";
            this.labTaskDate.Size = new System.Drawing.Size(65, 12);
            this.labTaskDate.TabIndex = 0;
            this.labTaskDate.Text = "任务日期：";
            // 
            // groupFrequency
            // 
            this.groupFrequency.Controls.Add(this.radWeekly);
            this.groupFrequency.Controls.Add(this.radBtnEveDay);
            this.groupFrequency.Controls.Add(this.radBtnOneDay);
            this.groupFrequency.Location = new System.Drawing.Point(13, 43);
            this.groupFrequency.Name = "groupFrequency";
            this.groupFrequency.Size = new System.Drawing.Size(285, 59);
            this.groupFrequency.TabIndex = 1;
            this.groupFrequency.TabStop = false;
            this.groupFrequency.Text = "频率";
            // 
            // radWeekly
            // 
            this.radWeekly.AutoSize = true;
            this.radWeekly.Location = new System.Drawing.Point(208, 26);
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Size = new System.Drawing.Size(47, 16);
            this.radWeekly.TabIndex = 1;
            this.radWeekly.TabStop = true;
            this.radWeekly.Tag = "2";
            this.radWeekly.Text = "每周";
            this.radWeekly.UseVisualStyleBackColor = true;
            // 
            // radBtnEveDay
            // 
            this.radBtnEveDay.AutoSize = true;
            this.radBtnEveDay.Location = new System.Drawing.Point(116, 26);
            this.radBtnEveDay.Name = "radBtnEveDay";
            this.radBtnEveDay.Size = new System.Drawing.Size(47, 16);
            this.radBtnEveDay.TabIndex = 0;
            this.radBtnEveDay.TabStop = true;
            this.radBtnEveDay.Tag = "1";
            this.radBtnEveDay.Text = "每天";
            this.radBtnEveDay.UseVisualStyleBackColor = true;
            // 
            // radBtnOneDay
            // 
            this.radBtnOneDay.AutoSize = true;
            this.radBtnOneDay.Location = new System.Drawing.Point(24, 26);
            this.radBtnOneDay.Name = "radBtnOneDay";
            this.radBtnOneDay.Size = new System.Drawing.Size(47, 16);
            this.radBtnOneDay.TabIndex = 0;
            this.radBtnOneDay.TabStop = true;
            this.radBtnOneDay.Tag = "0";
            this.radBtnOneDay.Text = "一次";
            this.radBtnOneDay.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss dddd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(114, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(184, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // groupTask
            // 
            this.groupTask.Controls.Add(this.radStartInverter);
            this.groupTask.Controls.Add(this.radCloseInverter);
            this.groupTask.Controls.Add(this.radioVoltage);
            this.groupTask.Location = new System.Drawing.Point(12, 108);
            this.groupTask.Name = "groupTask";
            this.groupTask.Size = new System.Drawing.Size(286, 155);
            this.groupTask.TabIndex = 3;
            this.groupTask.TabStop = false;
            this.groupTask.Text = "任务";
            // 
            // radStartInverter
            // 
            this.radStartInverter.AutoSize = true;
            this.radStartInverter.Location = new System.Drawing.Point(25, 72);
            this.radStartInverter.Name = "radStartInverter";
            this.radStartInverter.Size = new System.Drawing.Size(83, 16);
            this.radStartInverter.TabIndex = 1;
            this.radStartInverter.TabStop = true;
            this.radStartInverter.Tag = "1";
            this.radStartInverter.Text = "启动逆变器";
            this.radStartInverter.UseVisualStyleBackColor = true;
            // 
            // radCloseInverter
            // 
            this.radCloseInverter.AutoSize = true;
            this.radCloseInverter.Location = new System.Drawing.Point(25, 120);
            this.radCloseInverter.Name = "radCloseInverter";
            this.radCloseInverter.Size = new System.Drawing.Size(83, 16);
            this.radCloseInverter.TabIndex = 0;
            this.radCloseInverter.TabStop = true;
            this.radCloseInverter.Tag = "2";
            this.radCloseInverter.Text = "关闭逆变器";
            this.radCloseInverter.UseVisualStyleBackColor = true;
            // 
            // radioVoltage
            // 
            this.radioVoltage.AutoSize = true;
            this.radioVoltage.Location = new System.Drawing.Point(25, 20);
            this.radioVoltage.Name = "radioVoltage";
            this.radioVoltage.Size = new System.Drawing.Size(71, 16);
            this.radioVoltage.TabIndex = 0;
            this.radioVoltage.TabStop = true;
            this.radioVoltage.Tag = "3";
            this.radioVoltage.Text = "电池测试";
            this.radioVoltage.UseVisualStyleBackColor = true;
            // 
            // AddOK
            // 
            this.AddOK.Location = new System.Drawing.Point(57, 281);
            this.AddOK.Name = "AddOK";
            this.AddOK.Size = new System.Drawing.Size(75, 25);
            this.AddOK.TabIndex = 4;
            this.AddOK.Text = "确定";
            this.AddOK.UseVisualStyleBackColor = true;
            this.AddOK.Click += new System.EventHandler(this.AddOK_Click);
            // 
            // AddCancel
            // 
            this.AddCancel.Location = new System.Drawing.Point(181, 281);
            this.AddCancel.Name = "AddCancel";
            this.AddCancel.Size = new System.Drawing.Size(75, 25);
            this.AddCancel.TabIndex = 4;
            this.AddCancel.Text = "取消";
            this.AddCancel.UseVisualStyleBackColor = true;
            this.AddCancel.Click += new System.EventHandler(this.AddCancel_Click);
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 324);
            this.Controls.Add(this.AddCancel);
            this.Controls.Add(this.AddOK);
            this.Controls.Add(this.groupTask);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.groupFrequency);
            this.Controls.Add(this.labTaskDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加任务";
            this.Load += new System.EventHandler(this.AddTask_Load);
            this.groupFrequency.ResumeLayout(false);
            this.groupFrequency.PerformLayout();
            this.groupTask.ResumeLayout(false);
            this.groupTask.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTaskDate;
        private System.Windows.Forms.GroupBox groupFrequency;
        private System.Windows.Forms.RadioButton radBtnEveDay;
        private System.Windows.Forms.RadioButton radBtnOneDay;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupTask;
        private System.Windows.Forms.RadioButton radCloseInverter;
        private System.Windows.Forms.RadioButton radioVoltage;
        private System.Windows.Forms.Button AddOK;
        private System.Windows.Forms.Button AddCancel;
        private System.Windows.Forms.RadioButton radWeekly;
        private System.Windows.Forms.RadioButton radStartInverter;
    }
}