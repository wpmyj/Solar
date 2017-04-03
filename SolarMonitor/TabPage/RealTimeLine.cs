using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Communication;
using Communication.CommunicateToLowerMonitor;
using Model_Data;
using DevExpress.XtraCharts;
using Model_Data.CommunicateEntity;
using Model_Data.Language;

namespace SolarMonitor.ChildUser_TabPage
{
    public partial class RealTimeLine : DevExpress.XtraEditors.XtraUserControl
    {

        //
        public RealTimeLine()
        {
            InitializeComponent();
            LoadLanguageInfo();
        }
        //加载语言显示信息类
        private void LoadLanguageInfo()
        {
            lbState.Text = Model_Data.Language.PublicInfo.CommuState;
            lbSignal.Text = Model_Data.Language.PublicInfo.SeleSign;
            btnPauseResume.Text = Model_Data.Language.Desc.Suspend_ChildUserTab;

            lbPollInterval.Text = Model_Data.Language.ChildUser_TabPage.XTimeLimit;//X轴时间范围
        }
        //初始化
        public void LoadData()
        {
            //初始化 信号框
            LoadSignalNameCombobox();

            //将定时器刷新时间 设定为端口扫描时间
            int ScanTime = DeviceObj.GetDeviceModel().Port.ScanningTime;
            int pollInterval = ScanTime / 1000;//获取端口轮询时间（单位：秒）
            //设定X轴最小时间间隔
            //最大点数：1000点  最小点数：100点  增加间隔：1点
            spnTimeInterval.Properties.MinValue = pollInterval * 100;
            spnTimeInterval.Properties.MaxValue = pollInterval * 1000;
            spnTimeInterval.Properties.Increment = pollInterval;
            spnTimeInterval.EditValue = pollInterval * 200;//默认显示200个点

            timer.Interval = ScanTime;//将定时器 时间设定为 扫描时间
        }
        // 初始化 信号 下拉框 只显示变化的数字量，过滤掉常量和字符量
        private void LoadSignalNameCombobox()
        {
            cbSignalName.Properties.Items.Clear();
            DeviceBll dbll = DeviceObj.GetDevice();
            if (dbll == null) return;
            foreach (AnalogBll item in dbll.AnalogList)
            {
                if (item.AnalogInfo.AnalogReadFrequency!= AnalogReadFrequency.EveryTime)
                    continue;
                if (!item.AnalogInfo.SignalType.Contains("decimal") && item.AnalogInfo.SignalType != "long")
                    continue;
                string SignalName = item.AnalogInfo.SignalName;
                cbSignalName.Properties.Items.Add(SignalName);
            }
            cbSignalName.SelectedIndex = 0;
        }
        //属性:定时器刷新时间
        private int TimeInterval { get { return Convert.ToInt32(spnTimeInterval.EditValue); } }
        //按键显示文本 修改
        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            //btnPauseResume.Text = timer.Enabled ? "暂停" : "恢复";
            btnPauseResume.Text = timer.Enabled ? Model_Data.Language.Desc.Suspend_ChildUserTab : Model_Data.Language.Desc.Resume_ChildUserTab;//modified by zq
        }

        //定时器刷新
        private void timer_Tick_1(object sender, EventArgs e)
        {
            DeviceBll device = DeviceObj.GetDevice();
            //通讯状态实在
            if (device == null)
                return;
            

            if (device.Device.ComState == Model_Data.CommunicateEntity.DivCommStateEnum.Success)//通讯成功，则开始画图
            {
                lbComState.Text = Model_Data.Language.EaSolar.Connected;//2
                lbComState.ForeColor = Color.Green;
                btnPauseResume.Enabled = true;
                TimeDrawLine();
            }
            else if (device.Device.ComState == Model_Data.CommunicateEntity.DivCommStateEnum.Failed)
            {
                lbComState.Text = Model_Data.Language.EaSolar.Disconnected;//3 
                btnPauseResume.Enabled = false;
                lbComState.ForeColor = Color.Red;
            }
            else//通讯失败，突出显示
            {
                lbComState.Text = Model_Data.Language.EaSolar.UnConnect;//1
                btnPauseResume.Enabled = false;
                lbComState.ForeColor = Color.Gray;
            }
        }

        private DateTime PreTime;
        
        private void TimeDrawLine()
        {
            if (chartControl1.Series.Count < 1)
                return;
            //构建 表格，用于绑定
            AnalogBll al=  DeviceObj.GetDevice().AnalogList.Find(delegate(AnalogBll abll) { return abll.AnalogInfo.SignalName == cbSignalName.Text ? true : false; });
            object svalue = al.AnalogInfo.Value;
            DateTime dtime = DateTime.Now;

            //如果图中最后一个点 的时间 是最新一个点的时间，则直接返回
            if (chartControl1.Series[0].Points.Count > 0)            
                if (PreTime != null)
                    if (PreTime == dtime)                    
                        return;
            //否则，将最新点的时间 记录下来
            PreTime = dtime;

            DateTime argument = PreTime;

            DateTime minDate = argument.AddSeconds(-TimeInterval);
            //需要移除的点个数
            int pointsToRemoveCount = 0;
            //如果 某个点的时间小于坐标轴最小时间，则+1
            foreach (SeriesPoint point in chartControl1.Series[0].Points)
                if (point.DateTimeArgument < minDate)
                    pointsToRemoveCount++;
            //如果 ........？
            if (pointsToRemoveCount < chartControl1.Series[0].Points.Count)
                pointsToRemoveCount--;

            SeriesPoint pointsToUpdate = new SeriesPoint(argument, svalue);//Convert.ToDouble(String.Format("{0:F}", Dr[0]["信号值"]))
            //将最新点 添加到显示序列
            chartControl1.Series[0].Points.Add(pointsToUpdate);

            if (pointsToRemoveCount > 0)
            {
                chartControl1.Series[0].Points.RemoveRange(0, pointsToRemoveCount);
            }
            SwiftPlotDiagram diagram = chartControl1.Diagram as SwiftPlotDiagram;
            if (diagram != null && diagram.AxisX.DateTimeMeasureUnit == DateTimeMeasurementUnit.Millisecond)
                diagram.AxisX.Range.SetMinMaxValues(minDate, argument);

            diagram.EnableAxisYScrolling = true;
            diagram.EnableAxisYZooming = true;
        }

        //更改显示的信号
        private void cbSignalName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSignalName.SelectedIndex < 0)
                return;
            chartControl1.Series.Clear();
            Series S1 = new Series(cbSignalName.Text, ViewType.SwiftPlot);
            S1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            chartControl1.Series.Add(S1); 
        }

    }
}
