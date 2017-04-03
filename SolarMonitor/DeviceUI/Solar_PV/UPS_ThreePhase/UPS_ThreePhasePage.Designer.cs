using SolarMonitor.Solar_PV.UPS_ThreePhase;
namespace SolarMonitor.Solar_PV
{
    partial class UPS_ThreePhasePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatePage = new SolarMonitor.Solar_PV.UPS_ThreePhase.UPSThreePhaseStatePage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.ThreePhaseRTInfo = new SolarMonitor.Solar_PV.UPS_ThreePhase.UPS_ThreePhaseRTInfo();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.OtherRtInfoPage = new SolarMonitor.Solar_PV.UPS_ThreePhase.UPS_ThreePhaseOtherRtInfo();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.ThreePhaseRateInfoPage = new SolarMonitor.Solar_PV.UPS_ThreePhase.UPS_ThreePhaseRateInfoPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.upsControlPage1 = new SolarMonitor.Solar_PV.UPSControlPage();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // StatePage
            // 
            this.StatePage.Location = new System.Drawing.Point(671, 44);
            this.StatePage.Name = "StatePage";
            this.StatePage.Size = new System.Drawing.Size(337, 560);
            this.StatePage.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.StatePage);
            this.layoutControl1.Controls.Add(this.xtraTabControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(927, 619, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1032, 628);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(643, 604);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.ThreePhaseRTInfo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(637, 575);
            //this.xtraTabPage1.Text = "三相信息";
            this.xtraTabPage1.Text = Model_Data.Language.UPS_ThreePhase.ThreePhaseInfo;
            // 
            // ThreePhaseRTInfo
            // 
            this.ThreePhaseRTInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThreePhaseRTInfo.Location = new System.Drawing.Point(0, 0);
            this.ThreePhaseRTInfo.Name = "ThreePhaseRTInfo";
            this.ThreePhaseRTInfo.Size = new System.Drawing.Size(637, 575);
            this.ThreePhaseRTInfo.TabIndex = 2;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.OtherRtInfoPage);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(637, 575);
            //this.xtraTabPage3.Text = "实时数据";
            this.xtraTabPage3.Text = Model_Data.Language.UPS_ThreePhase.RealTimeData;
            // 
            // OtherRtInfoPage
            // 
            this.OtherRtInfoPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OtherRtInfoPage.Location = new System.Drawing.Point(0, 0);
            this.OtherRtInfoPage.Name = "OtherRtInfoPage";
            this.OtherRtInfoPage.Size = new System.Drawing.Size(637, 575);
            this.OtherRtInfoPage.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.ThreePhaseRateInfoPage);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(637, 575);
            //this.xtraTabPage4.Text = "额定及厂商信息";
            this.xtraTabPage4.Text = Model_Data.Language.UPS_ThreePhase.RatedInfo;
            // 
            // ThreePhaseRateInfoPage
            // 
            this.ThreePhaseRateInfoPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThreePhaseRateInfoPage.Location = new System.Drawing.Point(0, 0);
            this.ThreePhaseRateInfoPage.Name = "ThreePhaseRateInfoPage";
            this.ThreePhaseRateInfoPage.Size = new System.Drawing.Size(637, 575);
            this.ThreePhaseRateInfoPage.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.upsControlPage1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(637, 575);
            //this.xtraTabPage2.Text = "设置信息";
            this.xtraTabPage2.Text = Model_Data.Language.UPS_ThreePhase.SettingInfo;
            // 
            // upsControlPage1
            // 
            this.upsControlPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upsControlPage1.Location = new System.Drawing.Point(0, 0);
            this.upsControlPage1.Name = "upsControlPage1";
            this.upsControlPage1.Size = new System.Drawing.Size(637, 575);
            this.upsControlPage1.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1032, 628);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "状态信息";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(647, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(365, 608);
            //this.layoutControlGroup2.Text = "状态信息";
            this.layoutControlGroup2.Text = Model_Data.Language.UPS_ThreePhase.StatusInfo;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.StatePage;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(341, 564);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xtraTabControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(647, 608);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // UPS_ThreePhasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UPS_ThreePhasePage";
            this.Size = new System.Drawing.Size(1032, 628);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UPSThreePhaseStatePage StatePage;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private UPS_ThreePhaseRTInfo ThreePhaseRTInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private UPS_ThreePhaseRateInfoPage ThreePhaseRateInfoPage;
        private UPS_ThreePhaseOtherRtInfo OtherRtInfoPage;
        private UPSControlPage upsControlPage1;
    }
}
