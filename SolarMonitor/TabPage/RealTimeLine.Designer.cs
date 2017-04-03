namespace SolarMonitor.ChildUser_TabPage
{
    partial class RealTimeLine
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
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView2 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPauseResume = new DevExpress.XtraEditors.SimpleButton();
            this.cbSignalName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spnTimeInterval = new DevExpress.XtraEditors.SpinEdit();
            this.lbState = new System.Windows.Forms.Label();
            this.lbPollInterval = new System.Windows.Forms.Label();
            this.lbSignal = new System.Windows.Forms.Label();
            this.lbComState = new System.Windows.Forms.Label();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSignalName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTimeInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
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
            this.splitContainer1.Panel2.Controls.Add(this.chartControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 596);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnPauseResume, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSignalName, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.spnTimeInterval, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbState, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPollInterval, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSignal, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbComState, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPauseResume.Location = new System.Drawing.Point(471, 9);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(83, 22);
            this.btnPauseResume.TabIndex = 35;
            this.btnPauseResume.Text = "暂停";
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // cbSignalName
            // 
            this.cbSignalName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSignalName.Location = new System.Drawing.Point(345, 9);
            this.cbSignalName.Name = "cbSignalName";
            this.cbSignalName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSignalName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSignalName.Size = new System.Drawing.Size(120, 20);
            this.cbSignalName.TabIndex = 34;
            this.cbSignalName.SelectedIndexChanged += new System.EventHandler(this.cbSignalName_SelectedIndexChanged);
            // 
            // spnTimeInterval
            // 
            this.spnTimeInterval.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spnTimeInterval.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spnTimeInterval.Location = new System.Drawing.Point(194, 9);
            this.spnTimeInterval.Name = "spnTimeInterval";
            this.spnTimeInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnTimeInterval.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spnTimeInterval.Properties.IsFloatValue = false;
            this.spnTimeInterval.Properties.Mask.EditMask = "N00";
            this.spnTimeInterval.Properties.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.spnTimeInterval.Properties.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spnTimeInterval.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.spnTimeInterval.Size = new System.Drawing.Size(80, 20);
            this.spnTimeInterval.TabIndex = 32;
            // 
            // lbState
            // 
            this.lbState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(3, 13);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(59, 14);
            this.lbState.TabIndex = 0;
            this.lbState.Text = "通讯状态:";
            // 
            // lbPollInterval
            // 
            this.lbPollInterval.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPollInterval.AutoSize = true;
            this.lbPollInterval.Location = new System.Drawing.Point(129, 13);
            this.lbPollInterval.Name = "lbPollInterval";
            this.lbPollInterval.Size = new System.Drawing.Size(59, 14);
            this.lbPollInterval.TabIndex = 31;
            this.lbPollInterval.Text = "刷新时间:";
            // 
            // lbSignal
            // 
            this.lbSignal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSignal.AutoSize = true;
            this.lbSignal.Location = new System.Drawing.Point(280, 13);
            this.lbSignal.Name = "lbSignal";
            this.lbSignal.Size = new System.Drawing.Size(59, 14);
            this.lbSignal.TabIndex = 33;
            this.lbSignal.Text = "选择信号:";
            // 
            // lbComState
            // 
            this.lbComState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbComState.AutoSize = true;
            this.lbComState.Location = new System.Drawing.Point(68, 13);
            this.lbComState.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.lbComState.Name = "lbComState";
            this.lbComState.Size = new System.Drawing.Size(38, 14);
            this.lbComState.TabIndex = 36;
            this.lbComState.Text = "label1";
            // 
            // chartControl1
            // 
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.AutoGrid = false;
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Millisecond;
            swiftPlotDiagram1.AxisX.GridLines.Visible = true;
            swiftPlotDiagram1.AxisX.Label.TextPattern = "{A:G}";
            swiftPlotDiagram1.AxisX.Title.Text = "Time";
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisX.WholeRange.AutoSideMargins = true;
            swiftPlotDiagram1.AxisY.Interlaced = true;
            swiftPlotDiagram1.AxisY.Title.Text = "Values";
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.WholeRange.AutoSideMargins = true;
            swiftPlotDiagram1.Margins.Right = 15;
            this.chartControl1.Diagram = swiftPlotDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.View = swiftPlotSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.SeriesTemplate.View = swiftPlotSeriesView2;
            this.chartControl1.Size = new System.Drawing.Size(1020, 552);
            this.chartControl1.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainer1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1024, 600);
            this.panelControl1.TabIndex = 1;
            // 
            // RealTimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RealTimeLine";
            this.Size = new System.Drawing.Size(1024, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSignalName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTimeInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label lbPollInterval;
        private DevExpress.XtraEditors.SpinEdit spnTimeInterval;
        private System.Windows.Forms.Label lbSignal;
        private DevExpress.XtraEditors.ComboBoxEdit cbSignalName;
        private DevExpress.XtraEditors.SimpleButton btnPauseResume;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Label lbComState;
    }
}
