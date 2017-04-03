namespace SolarMonitor.DeviceUI.Solar_PV
{
    partial class OneTemperature
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
            this.label_Name = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.label_Value = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.linearScaleLevelComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.linearScaleComponent2 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_Value)).BeginInit();
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
            this.gaugeControl1.Size = new System.Drawing.Size(422, 110);
            this.gaugeControl1.TabIndex = 0;
            // 
            // linearGauge1
            // 
            this.linearGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.linearScaleBackgroundLayerComponent1});
            this.linearGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 410, 98);
            this.linearGauge1.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.label_Name,
            this.label_Value});
            this.linearGauge1.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.linearScaleLevelComponent1});
            this.linearGauge1.Name = "linearGauge1";
            this.linearGauge1.OptionsToolTip.TooltipTitleFormat = "{0}";
            this.linearGauge1.Orientation = DevExpress.XtraGauges.Core.Model.ScaleOrientation.Horizontal;
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
            this.linearScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style9;
            this.linearScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // linearScaleComponent1
            // 
            this.linearScaleComponent1.AppearanceTickmarkText.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linearScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:BlueViolet");
            this.linearScaleComponent1.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 37F);
            this.linearScaleComponent1.MajorTickCount = 6;
            this.linearScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent1.MajorTickmark.ShapeOffset = 6F;
            this.linearScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_2;
            this.linearScaleComponent1.MajorTickmark.TextOffset = 35F;
            this.linearScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.BottomToTop;
            this.linearScaleComponent1.MaxValue = 120F;
            this.linearScaleComponent1.MinorTickCount = 4;
            this.linearScaleComponent1.MinorTickmark.ShapeOffset = 6F;
            this.linearScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_1;
            this.linearScaleComponent1.MinValue = -20F;
            this.linearScaleComponent1.Name = "scale1";
            this.linearScaleComponent1.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            this.linearScaleComponent1.Value = 80F;
            // 
            // label_Name
            // 
            this.label_Name.AppearanceText.Font = new System.Drawing.Font("楷体_GB2312", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Name.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:BlueViolet");
            this.label_Name.Name = "linearGauge1_Label1";
            this.label_Name.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(-20F, 65F);
            this.label_Name.Size = new System.Drawing.SizeF(50F, 200F);
            this.label_Name.Text = "环境温度";
            this.label_Name.ZOrder = -1001;
            // 
            // label_Value
            // 
            this.label_Value.AppearanceText.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label_Value.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:BlueViolet");
            this.label_Value.Name = "linearGauge1_Label2";
            this.label_Value.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(300F, 61.9F);
            this.label_Value.Size = new System.Drawing.SizeF(100F, 40F);
            this.label_Value.Text = "80℃";
            this.label_Value.ZOrder = -1001;
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
            this.linearScaleComponent2.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 37F);
            this.linearScaleComponent2.MajorTickCount = 6;
            this.linearScaleComponent2.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent2.MajorTickmark.ShapeOffset = -18F;
            this.linearScaleComponent2.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_2;
            this.linearScaleComponent2.MajorTickmark.TextOffset = -32F;
            this.linearScaleComponent2.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.BottomToTop;
            this.linearScaleComponent2.MaxValue = 120F;
            this.linearScaleComponent2.MinorTickCount = 4;
            this.linearScaleComponent2.MinorTickmark.ShapeOffset = -12F;
            this.linearScaleComponent2.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style14_1;
            this.linearScaleComponent2.MinValue = -20F;
            this.linearScaleComponent2.Name = "scale2";
            this.linearScaleComponent2.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            this.linearScaleComponent2.Value = 20F;
            // 
            // OneTemperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gaugeControl1);
            this.Name = "OneTemperature";
            this.Size = new System.Drawing.Size(422, 110);
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_Value)).EndInit();
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
        private DevExpress.XtraGauges.Win.Base.LabelComponent label_Name;
        private DevExpress.XtraGauges.Win.Base.LabelComponent label_Value;
    }
}
