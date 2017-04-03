namespace SolarMonitor.MainForm
{
    partial class Smachine
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Smachine));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.MainContent1 = new SolarMonitor.UserControl.MainContent();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btStart = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btStop = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btSetting = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btQuery = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btVersion = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btDocument = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btExist = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbPortTitle = new DevExpress.XtraBars.BarStaticItem();
            this.lbPort = new DevExpress.XtraBars.BarStaticItem();
            this.lbIntervalTitle = new DevExpress.XtraBars.BarStaticItem();
            this.lbInterval = new DevExpress.XtraBars.BarStaticItem();
            this.lbEventTitle = new DevExpress.XtraBars.BarStaticItem();
            this.lbEvent = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ribbonImageCollectionLarge1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.MainContent1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 26);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1008, 677);
            this.panelControl2.TabIndex = 4;
            // 
            // MainContent1
            // 
            this.MainContent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContent1.Location = new System.Drawing.Point(2, 2);
            this.MainContent1.Name = "MainContent1";
            this.MainContent1.Size = new System.Drawing.Size(1004, 673);
            this.MainContent1.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowItemAnimatedHighlighting = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btStart,
            this.btStop,
            this.btSetting,
            this.btQuery,
            this.btVersion,
            this.btDocument,
            this.btExist,
            this.lbPortTitle,
            this.lbPort,
            this.lbIntervalTitle,
            this.lbInterval,
            this.lbEventTitle,
            this.lbEvent,
            this.barLargeButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 19;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btStart, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btStop, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btSetting, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btQuery, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barLargeButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btVersion, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btDocument, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btExist, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btStart
            // 
            this.btStart.Caption = "开始通讯";
            this.btStart.Id = 0;
            this.btStart.ImageIndex = 20;
            this.btStart.Name = "btStart";
            this.btStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btStart_ItemClick);
            // 
            // btStop
            // 
            this.btStop.Caption = "停止通讯";
            this.btStop.Id = 1;
            this.btStop.ImageIndex = 21;
            this.btStop.Name = "btStop";
            this.btStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btStop_ItemClick);
            // 
            // btSetting
            // 
            this.btSetting.Caption = "参数设置";
            this.btSetting.Id = 2;
            this.btSetting.ImageIndex = 22;
            this.btSetting.Name = "btSetting";
            this.btSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btSetting_ItemClick);
            // 
            // btQuery
            // 
            this.btQuery.Caption = "地址查询";
            this.btQuery.Id = 4;
            this.btQuery.ImageIndex = 27;
            this.btQuery.Name = "btQuery";
            this.btQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btQuery_ItemClick);
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Caption = "排程管理";
            this.barLargeButtonItem1.Id = 18;
            this.barLargeButtonItem1.ImageIndex = 28;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            // 
            // btVersion
            // 
            this.btVersion.Caption = "系统版本";
            this.btVersion.Id = 6;
            this.btVersion.ImageIndex = 26;
            this.btVersion.Name = "btVersion";
            this.btVersion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btVersion_ItemClick);
            // 
            // btDocument
            // 
            this.btDocument.Caption = "操作文档";
            this.btDocument.Id = 7;
            this.btDocument.ImageIndex = 24;
            this.btDocument.Name = "btDocument";
            this.btDocument.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDocument_ItemClick);
            // 
            // btExist
            // 
            this.btExist.Caption = "退出系统";
            this.btExist.Id = 8;
            this.btExist.ImageIndex = 25;
            this.btExist.Name = "btExist";
            this.btExist.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btExist_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbPortTitle),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbPort),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbIntervalTitle),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbInterval),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbEventTitle),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbEvent)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // lbPortTitle
            // 
            this.lbPortTitle.Caption = "当前端口:";
            this.lbPortTitle.Id = 12;
            this.lbPortTitle.Name = "lbPortTitle";
            this.lbPortTitle.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lbPort
            // 
            this.lbPort.Caption = "TCP/IP";
            this.lbPort.Id = 13;
            this.lbPort.Name = "lbPort";
            this.lbPort.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lbIntervalTitle
            // 
            this.lbIntervalTitle.Caption = "刷新时间:";
            this.lbIntervalTitle.Id = 14;
            this.lbIntervalTitle.Name = "lbIntervalTitle";
            this.lbIntervalTitle.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lbInterval
            // 
            this.lbInterval.Caption = "2(s)";
            this.lbInterval.Id = 15;
            this.lbInterval.Name = "lbInterval";
            this.lbInterval.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lbEventTitle
            // 
            this.lbEventTitle.Caption = "最新事件:";
            this.lbEventTitle.Id = 16;
            this.lbEventTitle.Name = "lbEventTitle";
            this.lbEventTitle.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lbEvent
            // 
            this.lbEvent.Caption = ".......";
            this.lbEvent.Id = 17;
            this.lbEvent.Name = "lbEvent";
            this.lbEvent.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1008, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 703);
            this.barDockControlBottom.Size = new System.Drawing.Size(1008, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 677);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1008, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 677);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "iSmart OffGrid";
            this.notifyIcon1.BalloonTipTitle = "iSmart OffGrid";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "iSmart OffGrid";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // ribbonImageCollectionLarge1
            // 
            this.ribbonImageCollectionLarge1.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge1.ImageStream")));
            // 
            // Smachine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Smachine";
            this.Text = "ISmartOffGrid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Smachine_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Smachine_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarLargeButtonItem   btStart;
        private DevExpress.XtraBars.BarLargeButtonItem btStop;
        private DevExpress.XtraBars.BarLargeButtonItem btSetting;
        private DevExpress.XtraBars.BarLargeButtonItem btQuery;
        private DevExpress.XtraBars.BarLargeButtonItem btVersion;
        private DevExpress.XtraBars.BarLargeButtonItem btDocument;
        private DevExpress.XtraBars.BarLargeButtonItem btExist;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private UserControl.MainContent MainContent1;
        private DevExpress.XtraBars.BarStaticItem lbPortTitle;
        private DevExpress.XtraBars.BarStaticItem lbPort;
        private DevExpress.XtraBars.BarStaticItem lbIntervalTitle;
        private DevExpress.XtraBars.BarStaticItem lbInterval;
        private DevExpress.XtraBars.BarStaticItem lbEventTitle;
        private DevExpress.XtraBars.BarStaticItem lbEvent;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge1;
    }
}
