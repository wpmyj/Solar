namespace SolarMonitor.UserControl
{
    partial class MainContent
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
            this.components = new System.ComponentModel.Container();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.alertEvent1 = new SolarMonitor.ChildUser_TabPage.AlertEvent();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.historicTable1 = new SolarMonitor.ChildUser_TabPage.HistoricTable();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.historicLine1 = new SolarMonitor.ChildUser_TabPage.HistoricLine();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.realTimeLine1 = new SolarMonitor.ChildUser_TabPage.RealTimeLine();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.timer_RTValue = new System.Windows.Forms.Timer(this.components);
            this.xtraTabPage6.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
           
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.alertEvent1);
            this.xtraTabPage6.Margin = new System.Windows.Forms.Padding(0);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(808, 551);
            this.xtraTabPage6.Text = "历史事件";
            // 
            // alertEvent1
            // 
            this.alertEvent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertEvent1.Location = new System.Drawing.Point(0, 0);
            this.alertEvent1.Margin = new System.Windows.Forms.Padding(0);
            this.alertEvent1.Name = "alertEvent1";
            this.alertEvent1.Size = new System.Drawing.Size(808, 551);
            this.alertEvent1.TabIndex = 0;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.historicTable1);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(808, 551);
            this.xtraTabPage5.Text = "历史数据";
            // 
            // historicTable1
            // 
            this.historicTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historicTable1.Location = new System.Drawing.Point(0, 0);
            this.historicTable1.Margin = new System.Windows.Forms.Padding(0);
            this.historicTable1.Name = "historicTable1";
            this.historicTable1.Size = new System.Drawing.Size(808, 551);
            this.historicTable1.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.historicLine1);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(808, 551);
            this.xtraTabPage4.Text = "历史曲线";
            // 
            // historicLine1
            // 
            this.historicLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historicLine1.Location = new System.Drawing.Point(0, 0);
            this.historicLine1.Margin = new System.Windows.Forms.Padding(0);
            this.historicLine1.Name = "historicLine1";
            this.historicLine1.Size = new System.Drawing.Size(808, 551);
            this.historicLine1.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.realTimeLine1);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(808, 551);
            this.xtraTabPage3.Text = "实时曲线";
            // 
            // realTimeLine1
            // 
            this.realTimeLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.realTimeLine1.Location = new System.Drawing.Point(0, 0);
            this.realTimeLine1.Margin = new System.Windows.Forms.Padding(0);
            this.realTimeLine1.Name = "realTimeLine1";
            this.realTimeLine1.Size = new System.Drawing.Size(808, 551);
            this.realTimeLine1.TabIndex = 0;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(808, 551);
            this.xtraTabPage1.Text = "实时数据";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(814, 578);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6});
            // 
            // timer_RTValue
            // 
            this.timer_RTValue.Tick += new System.EventHandler(this.timer_RTValue_Tick);
            // 
            // MainContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "MainContent";
            this.Size = new System.Drawing.Size(814, 578);           
            this.xtraTabPage6.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion       
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private System.Windows.Forms.Timer timer_RTValue;
        private ChildUser_TabPage.AlertEvent alertEvent1;
        private ChildUser_TabPage.HistoricTable historicTable1;
        private ChildUser_TabPage.HistoricLine historicLine1;
        private ChildUser_TabPage.RealTimeLine realTimeLine1;

    }
}
