namespace SolarMonitor.DeviceUI.Solar_PV
{
    partial class OnelinearGauge1Control
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
            //DevExpress.XtraGauges.Core.Model.ScaleLabel scaleLabel1 = new DevExpress.XtraGauges.Core.Model.ScaleLabel();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.linearGauge1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.linearScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.linearScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.linearScaleStateIndicatorComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent2 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent3 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent4 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent5 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent6 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent7 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent8 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent9 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.linearScaleStateIndicatorComponent10 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent();
            this.labelComponent1 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).BeginInit();
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
            this.gaugeControl1.Size = new System.Drawing.Size(264, 267);
            this.gaugeControl1.TabIndex = 0;
            // 
            // linearGauge1
            // 
            this.linearGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.linearScaleBackgroundLayerComponent1});
            this.linearGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 252, 255);
            this.linearGauge1.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent[] {
            this.linearScaleStateIndicatorComponent1,
            this.linearScaleStateIndicatorComponent2,
            this.linearScaleStateIndicatorComponent3,
            this.linearScaleStateIndicatorComponent4,
            this.linearScaleStateIndicatorComponent5,
            this.linearScaleStateIndicatorComponent6,
            this.linearScaleStateIndicatorComponent7,
            this.linearScaleStateIndicatorComponent8,
            this.linearScaleStateIndicatorComponent9,
            this.linearScaleStateIndicatorComponent10});
            this.linearGauge1.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent1});
            this.linearGauge1.Name = "linearGauge1";
            this.linearGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.linearScaleComponent1});
            // 
            // linearScaleBackgroundLayerComponent1
            // 
            this.linearScaleBackgroundLayerComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleBackgroundLayerComponent1.Name = "bg1";
            this.linearScaleBackgroundLayerComponent1.ScaleEndPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.1F);
            this.linearScaleBackgroundLayerComponent1.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.9F);
            this.linearScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style13;
            this.linearScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // linearScaleComponent1
            // 
            this.linearScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.linearScaleComponent1.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 225F);
            /*scaleLabel1.AppearanceText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            scaleLabel1.FormatString = "{0} {2:P0}";
            scaleLabel1.Name = "Label0";
            scaleLabel1.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 125F);
            scaleLabel1.Size = new System.Drawing.SizeF(100F, 30F);
            scaleLabel1.Text = "";
            scaleLabel1.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;*/
           // this.linearScaleComponent1.Labels.AddRange(new DevExpress.XtraGauges.Core.Model.ILabel[] {
           // scaleLabel1});
            this.linearScaleComponent1.MajorTickCount = 2;
            this.linearScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent1.MajorTickmark.ShapeOffset = -20F;
            this.linearScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style1_1;
            this.linearScaleComponent1.MajorTickmark.ShowText = false;
            this.linearScaleComponent1.MajorTickmark.ShowTick = false;
            this.linearScaleComponent1.MajorTickmark.TextOffset = -32F;
            this.linearScaleComponent1.MaxValue = 100F;
            this.linearScaleComponent1.MinorTickCount = 0;
            this.linearScaleComponent1.MinorTickmark.ShapeOffset = -14F;
            this.linearScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style1_2;
            this.linearScaleComponent1.MinorTickmark.ShowTick = false;
            this.linearScaleComponent1.Name = "scale1";
            this.linearScaleComponent1.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 25F);
            this.linearScaleComponent1.Value = 40F;
            // 
            // linearScaleStateIndicatorComponent1
            // 
            this.linearScaleStateIndicatorComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 225F);
            this.linearScaleStateIndicatorComponent1.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent1.Name = "Indicator0";
            this.linearScaleStateIndicatorComponent1.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState1.IntervalLength = 100F;
            scaleIndicatorState1.Name = "Colored";
            scaleIndicatorState1.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState1.StartValue = 10F;
            scaleIndicatorState2.IntervalLength = 0F;
            scaleIndicatorState2.Name = "Empty";
            scaleIndicatorState2.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent1.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState1,
            scaleIndicatorState2});
            this.linearScaleStateIndicatorComponent1.ZOrder = 100;
            // 
            // linearScaleStateIndicatorComponent2
            // 
            this.linearScaleStateIndicatorComponent2.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 202.7778F);
            this.linearScaleStateIndicatorComponent2.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent2.Name = "Indicator1";
            this.linearScaleStateIndicatorComponent2.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState3.IntervalLength = 90F;
            scaleIndicatorState3.Name = "Colored";
            scaleIndicatorState3.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState3.StartValue = 10F;
            scaleIndicatorState4.IntervalLength = 10F;
            scaleIndicatorState4.Name = "Empty";
            scaleIndicatorState4.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent2.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState3,
            scaleIndicatorState4});
            this.linearScaleStateIndicatorComponent2.ZOrder = 99;
            // 
            // linearScaleStateIndicatorComponent3
            // 
            this.linearScaleStateIndicatorComponent3.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 180.5556F);
            this.linearScaleStateIndicatorComponent3.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent3.Name = "Indicator2";
            this.linearScaleStateIndicatorComponent3.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState5.IntervalLength = 80F;
            scaleIndicatorState5.Name = "Colored";
            scaleIndicatorState5.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState5.StartValue = 30F;
            scaleIndicatorState6.IntervalLength = 20F;
            scaleIndicatorState6.Name = "Empty";
            scaleIndicatorState6.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent3.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState5,
            scaleIndicatorState6});
            this.linearScaleStateIndicatorComponent3.ZOrder = 98;
            // 
            // linearScaleStateIndicatorComponent4
            // 
            this.linearScaleStateIndicatorComponent4.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 158.3333F);
            this.linearScaleStateIndicatorComponent4.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent4.Name = "Indicator3";
            this.linearScaleStateIndicatorComponent4.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState7.IntervalLength = 70F;
            scaleIndicatorState7.Name = "Colored";
            scaleIndicatorState7.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState7.StartValue = 30F;
            scaleIndicatorState8.IntervalLength = 30F;
            scaleIndicatorState8.Name = "Empty";
            scaleIndicatorState8.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent4.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState7,
            scaleIndicatorState8});
            this.linearScaleStateIndicatorComponent4.ZOrder = 97;
            // 
            // linearScaleStateIndicatorComponent5
            // 
            this.linearScaleStateIndicatorComponent5.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 136.1111F);
            this.linearScaleStateIndicatorComponent5.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent5.Name = "Indicator4";
            this.linearScaleStateIndicatorComponent5.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState9.IntervalLength = 60F;
            scaleIndicatorState9.Name = "Colored";
            scaleIndicatorState9.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState9.StartValue = 40F;
            scaleIndicatorState10.IntervalLength = 40F;
            scaleIndicatorState10.Name = "Empty";
            scaleIndicatorState10.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent5.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState9,
            scaleIndicatorState10});
            this.linearScaleStateIndicatorComponent5.ZOrder = 96;
            // 
            // linearScaleStateIndicatorComponent6
            // 
            this.linearScaleStateIndicatorComponent6.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 113.8889F);
            this.linearScaleStateIndicatorComponent6.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent6.Name = "Indicator5";
            this.linearScaleStateIndicatorComponent6.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState11.IntervalLength = 50F;
            scaleIndicatorState11.Name = "Colored";
            scaleIndicatorState11.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState11.StartValue = 50F;
            scaleIndicatorState12.IntervalLength = 50F;
            scaleIndicatorState12.Name = "Empty";
            scaleIndicatorState12.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent6.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState11,
            scaleIndicatorState12});
            this.linearScaleStateIndicatorComponent6.ZOrder = 95;
            // 
            // linearScaleStateIndicatorComponent7
            // 
            this.linearScaleStateIndicatorComponent7.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 91.66667F);
            this.linearScaleStateIndicatorComponent7.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent7.Name = "Indicator6";
            this.linearScaleStateIndicatorComponent7.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState13.IntervalLength = 40F;
            scaleIndicatorState13.Name = "Colored";
            scaleIndicatorState13.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState13.StartValue = 60F;
            scaleIndicatorState14.IntervalLength = 60F;
            scaleIndicatorState14.Name = "Empty";
            scaleIndicatorState14.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent7.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState13,
            scaleIndicatorState14});
            this.linearScaleStateIndicatorComponent7.ZOrder = 94;
            // 
            // linearScaleStateIndicatorComponent8
            // 
            this.linearScaleStateIndicatorComponent8.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 69.44444F);
            this.linearScaleStateIndicatorComponent8.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent8.Name = "Indicator7";
            this.linearScaleStateIndicatorComponent8.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState15.IntervalLength = 30F;
            scaleIndicatorState15.Name = "Colored";
            scaleIndicatorState15.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState15.StartValue = 70F;
            scaleIndicatorState16.IntervalLength = 70F;
            scaleIndicatorState16.Name = "Empty";
            scaleIndicatorState16.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent8.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState15,
            scaleIndicatorState16});
            this.linearScaleStateIndicatorComponent8.ZOrder = 93;
            // 
            // linearScaleStateIndicatorComponent9
            // 
            this.linearScaleStateIndicatorComponent9.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 47.22222F);
            this.linearScaleStateIndicatorComponent9.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent9.Name = "Indicator8";
            this.linearScaleStateIndicatorComponent9.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState17.IntervalLength = 20F;
            scaleIndicatorState17.Name = "Colored";
            scaleIndicatorState17.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            scaleIndicatorState17.StartValue = 80F;
            scaleIndicatorState18.IntervalLength = 80F;
            scaleIndicatorState18.Name = "Empty";
            scaleIndicatorState18.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent9.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState17,
            scaleIndicatorState18});
            this.linearScaleStateIndicatorComponent9.ZOrder = 92;
            // 
            // linearScaleStateIndicatorComponent10
            // 
            this.linearScaleStateIndicatorComponent10.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 25F);
            this.linearScaleStateIndicatorComponent10.IndicatorScale = this.linearScaleComponent1;
            this.linearScaleStateIndicatorComponent10.Name = "Indicator9";
            this.linearScaleStateIndicatorComponent10.Size = new System.Drawing.SizeF(58.5702F, 18.94918F);
            scaleIndicatorState19.IntervalLength = 10F;
            scaleIndicatorState19.Name = "Colored";
            scaleIndicatorState19.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer4;
            scaleIndicatorState19.StartValue = 90F;
            scaleIndicatorState20.IntervalLength = 90F;
            scaleIndicatorState20.Name = "Empty";
            scaleIndicatorState20.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer0;
            this.linearScaleStateIndicatorComponent10.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            scaleIndicatorState19,
            scaleIndicatorState20});
            this.linearScaleStateIndicatorComponent10.ZOrder = 91;
            // 
            // labelComponent1
            // 
            this.labelComponent1.AppearanceText.Font = new System.Drawing.Font("楷体_GB2312", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelComponent1.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkViolet");
            this.labelComponent1.Name = "linearGauge1_Label1";
            this.labelComponent1.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(150F, 150F);
            this.labelComponent1.Size = new System.Drawing.SizeF(25F, 150F);
            this.labelComponent1.Text = "电池电量";
            this.labelComponent1.ZOrder = -1001;
            // 
            // OnelinearGauge1Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gaugeControl1);
            this.Name = "OnelinearGauge1Control";
            this.Size = new System.Drawing.Size(264, 267);
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleStateIndicatorComponent10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge linearGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent linearScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent linearScaleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent2;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent3;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent4;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent5;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent6;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent7;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent8;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent9;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleStateIndicatorComponent linearScaleStateIndicatorComponent10;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent1;
    }
}
