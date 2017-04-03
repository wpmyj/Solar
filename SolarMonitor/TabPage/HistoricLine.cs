using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using Model_Data;
using Model_Data.CommunicateEntity;
using Communication.CommunicateToLowerMonitor;

namespace SolarMonitor.ChildUser_TabPage
{
    public partial class HistoricLine : DevExpress.XtraEditors.XtraUserControl
    {
        //传递到本界面的 端口 设备 信息 ----实体字段
        Series hSeries { get { return chartControl_HistoricData.Series.Count > 0 ? chartControl_HistoricData.Series[0] : null; } }
        SwiftPlotDiagram Diagram { get { return chartControl_HistoricData.Diagram as SwiftPlotDiagram; } }
        AxisRange AxisXRange { get { return Diagram != null ? Diagram.AxisX.Range : null; } }
        AxisRange AxisYRange { get { return Diagram != null ? Diagram.AxisY.Range : null; } }

        //加载语言类信息
        private void LoadLanguageInfo()
        {
            lbSignal.Text = Model_Data.Language.PublicInfo.SeleSign;
            lbStart.Text = Model_Data.Language.PublicInfo.StartTime;
            lbEnd.Text = Model_Data.Language.PublicInfo.EndTime;
            btOK.Text = Model_Data.Language.PublicInfo.ViewCurve;
        }
        //
        public HistoricLine()
        {
            InitializeComponent();
            LoadLanguageInfo();

            //初始化 结束日期---清理初始日期
            DtBegin.EditValue = DateTime.Now;
            deEnd.EditValue = DateTime.Now.AddDays(1);
        }
        //初始化 信号 下拉框
        public void LoadData()
        {
            cbSignalName.Properties.Items.Clear();
            DeviceModel dbll = DeviceObj.GetDeviceModel();
            if (dbll == null) return;
            foreach (AnalogModel item in dbll.Analog)
            {
                if (item.AnalogReadFrequency != AnalogReadFrequency.EveryTime)
                    continue;
                if (!item.SignalType.Contains("decimal") && item.SignalType != "long")
                    continue;
                if (!item.ISRecord)
                    continue;
                cbSignalName.Properties.Items.Add(item.SignalName);                     
            }
            cbSignalName.SelectedIndex = 0;
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            DevExpress.XtraCharts.LineSeriesView lineSeriesView = new DevExpress.XtraCharts.LineSeriesView();

            DateTime BeginDate = DtBegin.DateTime.Date + teBegin.Time.TimeOfDay;
            DateTime EndDate = deEnd.DateTime.Date + teEnd.Time.TimeOfDay;

            if (BeginDate > EndDate)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.Desc.SelStartTime, Model_Data.Language.Desc.Warning_ChildUserTab);//modified by zq
                return;
            }
            DeviceModel dm = DeviceObj.GetDeviceModel();
            if (dm == null) return;
            string Value = "sid"+(dm.Analog.Find(delegate(AnalogModel ab) { return ab.SignalName ==cbSignalName.Text; })).SignalId.ToString();
            try
            {
                DataTable DT = ACCESSDBDAL.AccessServer.GetHistoricData(BeginDate, EndDate,dm.TableName);
                if (DT==null||DT.Rows.Count < 1)
                {
                    //DevExpress.XtraEditors.XtraMessageBox.Show("该时间段内不存在数据记录！", "提示");
                    DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.Desc.TimeNotData, Model_Data.Language.Desc.Prompting_ChildUserTab);//modified by zq
                    return;
                }
                BeginDate = Convert.ToDateTime(DT.Rows[0]["dtime"].ToString());
                EndDate = Convert.ToDateTime(DT.Rows[DT.Rows.Count - 1]["dtime"].ToString());
                TimeSpan TimeSpan = EndDate - BeginDate;
                //开始调配 曲线资源
                //清理以前的数据
                hSeries.DataSource = null;
                //1.为 序列绑定信号值名称
                hSeries.Name = cbSignalName.Text;
                //2.X轴的数据字段
                hSeries.ArgumentDataMember = "dtime";
                //3.Y轴的数据字段
                hSeries.ValueDataMembers[0] = Value;
                //4.标签可视化设置
                //hSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.Default;
                //5.参数刻度类型
                hSeries.ArgumentScaleType = ScaleType.DateTime;

                AxisBase axis = Diagram.AxisX;
                AxisBase ayis = Diagram.AxisY;
                axis.DateTimeOptions.Format = DateTimeFormat.Custom;
                //根据 实际数据的时间跨度 来设定 X轴的时间跨度      
                DateTimeAlignment(TimeSpan, axis);
                //X轴刻度 范围                      
                axis.GridLines.Visible = true;
                axis.Range.SideMarginsEnabled = false;//设定X轴从0开始
                axis.GridSpacingAuto = false;

                //Y轴的相关设定
                ayis.Range.Auto = true;
                ayis.GridSpacingAuto = true;
                //ayis.Range.AlwaysShowZeroLevel = false;
                //绑定数据
                try
                {
                    hSeries.DataSource = DT;
                }
                catch (Exception)
                {
                    MessageBox.Show("Faild to DataBinding!");
                }
                //设置 Y轴 可自行收缩
                Diagram.EnableAxisYScrolling = true;
                Diagram.EnableAxisYZooming = true;

            }
            catch (Exception str)
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show("获取数据失败!原因如下：/r/n" + str, "错误");
                DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.Desc.ObtainFailure + "/r/n" + str, Model_Data.Language.Desc.Fault_ChildUserTab);//modified by zq
            }

        }
        //根据数据起止时间 设置X轴时间刻度
        public static void DateTimeAlignment(TimeSpan TimeSpan, AxisBase axis)
        {
            if (TimeSpan.TotalDays > 730)
            {
                axis.DateTimeGridAlignment = DateTimeMeasurementUnit.Year;
                axis.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month;
                axis.DateTimeOptions.FormatString = "%y-%M-%d HH:mm:ss";
                axis.GridSpacing = 1;
            }
            else if ((730 >= TimeSpan.TotalDays) && (TimeSpan.TotalDays > 310))
            {
                axis.DateTimeGridAlignment = DateTimeMeasurementUnit.Month; 
                axis.DateTimeMeasureUnit = DateTimeMeasurementUnit.Day;
                axis.DateTimeOptions.FormatString = "%y-%M-%d HH:mm:ss";
                axis.GridSpacing = TimeSpan.TotalDays/30/10;
            }
            else if ((310 >= TimeSpan.TotalDays) && (TimeSpan.TotalDays > 10))
            {
                axis.DateTimeGridAlignment = DateTimeMeasurementUnit.Day;
                axis.DateTimeMeasureUnit = DateTimeMeasurementUnit.Hour;
                axis.DateTimeOptions.FormatString = "%y-%M-%d HH:mm:ss";
                axis.GridSpacing = TimeSpan.TotalDays/10;
            }
            else if ((10 >= TimeSpan.TotalDays) && (TimeSpan.TotalHours > 10))
            {
                axis.DateTimeGridAlignment = DateTimeMeasurementUnit.Hour;
                axis.DateTimeMeasureUnit = DateTimeMeasurementUnit.Minute;
                axis.DateTimeOptions.FormatString = "%y-%M-%d HH:mm:ss";
                axis.GridSpacing = TimeSpan.TotalHours/10;
            }
            else if ((TimeSpan.TotalHours <= 10)&&TimeSpan.TotalMinutes>10)
            {
                axis.DateTimeGridAlignment = DateTimeMeasurementUnit.Minute; 
                axis.DateTimeMeasureUnit = DateTimeMeasurementUnit.Second;
                axis.DateTimeOptions.FormatString = "HH:mm:ss";
                axis.GridSpacing = TimeSpan.TotalMinutes/10;
            }
            else if (TimeSpan.TotalMinutes<=10)
            {
                axis.DateTimeGridAlignment = DateTimeMeasurementUnit.Second;
                axis.DateTimeMeasureUnit = DateTimeMeasurementUnit.Second;
                axis.DateTimeOptions.FormatString = "HH:mm:ss";
                axis.GridSpacing = TimeSpan.TotalSeconds > 0 ? TimeSpan.TotalSeconds / 10 : 1;
            }
        }

    }

}
