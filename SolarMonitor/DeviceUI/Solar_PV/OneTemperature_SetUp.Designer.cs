namespace SolarMonitor.DeviceUI.Solar_PV
{
    partial class OneTemperature_SetUp
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
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.linearGauge1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.linearScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.linearScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.linearScaleLevelComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.linearScaleComponent2 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent2)).BeginInit();
            this.SuspendLayout();
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.linearGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(0, 0);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(100, 330);
            this.gaugeControl1.TabIndex = 0;
            // 
            // linearGauge1
            // 
            this.linearGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.linearScaleBackgroundLayerComponent1});
            this.linearGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 88, 318);
            this.linearGauge1.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.linearScaleLevelComponent1});
            this.linearGauge1.Name = "linearGauge1";
            this.linearGauge1.OptionsToolTip.TooltipTitleFormat = "{0}";
            this.linearGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.linearScaleComponent1,
            this.linearScaleComponent2});
            // 
            // linearScaleBackgroundLayerComponent1
            // 
            this.linearScaleBackgroundLayerComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleBackgroundLayerComponent1.Name = "bg1";
            this.linearScaleBackgroundLayerComponent1.ScaleEndPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.505F, 0.14F);
            this.linearScaleBackgroundLayerComponent1.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.505F, 0.85F);
            this.linearScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style14;
            this.linearScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // linearScaleComponent1
            // 
            this.linearScaleComponent1.AppearanceTickmarkText.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linearScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:BlueViolet");
            this.linearScaleComponent1.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 38F);
            this.linearScaleComponent1.MajorTickCount = 6;
            this.linearScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent1.MajorTickmark.ShapeOffset = 6F;
            this.linearScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_2;
            this.linearScaleComponent1.MajorTickmark.TextOffset = 35F;
            this.linearScaleComponent1.MaxValue = 120F;
            this.linearScaleComponent1.MinorTickCount = 4;
            this.linearScaleComponent1.MinorTickmark.ShapeOffset = 6F;
            this.linearScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_1;
            this.linearScaleComponent1.MinValue = -30F;
            this.linearScaleComponent1.Name = "scale1";
            this.linearScaleComponent1.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            // 
            // linearScaleLevelComponent1
            // 
            this.linearScaleLevelComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleLevelComponent1.Name = "level1";
            this.linearScaleLevelComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style14;
            this.linearScaleLevelComponent1.ZOrder = -50;
            // 
            // linearScaleComponent2
            // 
            this.linearScaleComponent2.AppearanceTickmarkText.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linearScaleComponent2.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:BlueViolet");
            this.linearScaleComponent2.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 38F);
            this.linearScaleComponent2.MajorTickCount = 6;
            this.linearScaleComponent2.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent2.MajorTickmark.ShapeOffset = -18F;
            this.linearScaleComponent2.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_2;
            this.linearScaleComponent2.MajorTickmark.TextOffset = -32F;
            this.linearScaleComponent2.MaxValue = 120F;
            this.linearScaleComponent2.MinorTickCount = 4;
            this.linearScaleComponent2.MinorTickmark.ShapeOffset = -12F;
            this.linearScaleComponent2.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_1;
            this.linearScaleComponent2.MinValue = -30F;
            this.linearScaleComponent2.Name = "scale2";
            this.linearScaleComponent2.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            // 
            // OneTemperature_SetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gaugeControl1);
            this.Name = "OneTemperature_SetUp";
            this.Size = new System.Drawing.Size(100, 330);
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge linearGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent linearScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent linearScaleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent linearScaleLevelComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent linearScaleComponent2;
    }
}
