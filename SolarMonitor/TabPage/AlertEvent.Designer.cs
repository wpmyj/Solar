namespace SolarMonitor.ChildUser_TabPage
{
    partial class AlertEvent
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbEnd = new System.Windows.Forms.Label();
            this.btOK = new DevExpress.XtraEditors.SimpleButton();
            this.teEnd = new DevExpress.XtraEditors.TimeEdit();
            this.deEnd = new DevExpress.XtraEditors.DateEdit();
            this.teBegin = new DevExpress.XtraEditors.TimeEdit();
            this.DtBegin = new DevExpress.XtraEditors.DateEdit();
            this.lbStart = new System.Windows.Forms.Label();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.btPrint = new DevExpress.XtraEditors.SimpleButton();
            this.tableDisplay1 = new SolarMonitor.ChildUser_TabPage.TableDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBegin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainer1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1024, 476);
            this.panelControl1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableDisplay1);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 472);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbEnd, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btOK, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.teEnd, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.deEnd, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.teBegin, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.DtBegin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btExport, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btPrint, 8, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbEnd
            // 
            this.lbEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbEnd.AutoSize = true;
            this.lbEnd.Location = new System.Drawing.Point(265, 13);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(59, 14);
            this.lbEnd.TabIndex = 63;
            this.lbEnd.Text = "结束时间:";
            // 
            // btOK
            // 
            this.btOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btOK.Location = new System.Drawing.Point(527, 9);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 22);
            this.btOK.TabIndex = 54;
            this.btOK.Text = "查看";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // teEnd
            // 
            this.teEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.teEnd.EditValue = new System.DateTime(2013, 1, 30, 0, 0, 0, 0);
            this.teEnd.Location = new System.Drawing.Point(446, 9);
            this.teEnd.Name = "teEnd";
            this.teEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEnd.Size = new System.Drawing.Size(75, 20);
            this.teEnd.TabIndex = 58;
            // 
            // deEnd
            // 
            this.deEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deEnd.EditValue = null;
            this.deEnd.Location = new System.Drawing.Point(330, 10);
            this.deEnd.Name = "deEnd";
            this.deEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEnd.Properties.Mask.EditMask = "";
            this.deEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.deEnd.Size = new System.Drawing.Size(110, 20);
            this.deEnd.TabIndex = 59;
            // 
            // teBegin
            // 
            this.teBegin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.teBegin.EditValue = new System.DateTime(2012, 2, 22, 0, 0, 0, 0);
            this.teBegin.Location = new System.Drawing.Point(184, 9);
            this.teBegin.Name = "teBegin";
            this.teBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teBegin.Size = new System.Drawing.Size(75, 20);
            this.teBegin.TabIndex = 60;
            // 
            // DtBegin
            // 
            this.DtBegin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtBegin.EditValue = null;
            this.DtBegin.Location = new System.Drawing.Point(68, 10);
            this.DtBegin.Name = "DtBegin";
            this.DtBegin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DtBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtBegin.Size = new System.Drawing.Size(110, 20);
            this.DtBegin.TabIndex = 61;
            // 
            // lbStart
            // 
            this.lbStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbStart.AutoSize = true;
            this.lbStart.Location = new System.Drawing.Point(3, 13);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(59, 14);
            this.lbStart.TabIndex = 62;
            this.lbStart.Text = "开始时间:";
            // 
            // btExport
            // 
            this.btExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExport.Location = new System.Drawing.Point(608, 8);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 64;
            this.btExport.Text = "导出";
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btPrint.Location = new System.Drawing.Point(689, 8);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 65;
            this.btPrint.Text = "打印";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // tableDisplay1
            // 
            this.tableDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDisplay1.Location = new System.Drawing.Point(0, 0);
            this.tableDisplay1.Name = "tableDisplay1";
            this.tableDisplay1.Size = new System.Drawing.Size(1020, 428);
            this.tableDisplay1.TabIndex = 0;
            // 
            // AlertEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AlertEvent";
            this.Size = new System.Drawing.Size(1024, 476);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBegin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbEnd;
        private DevExpress.XtraEditors.SimpleButton btOK;
        private DevExpress.XtraEditors.TimeEdit teEnd;
        private DevExpress.XtraEditors.DateEdit deEnd;
        private DevExpress.XtraEditors.TimeEdit teBegin;
        private DevExpress.XtraEditors.DateEdit DtBegin;
        private System.Windows.Forms.Label lbStart;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.SimpleButton btPrint;
        private TableDisplay tableDisplay1;




    }
}
