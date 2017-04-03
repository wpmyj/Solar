using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Model_Data;
using SolarMonitor.PublicFunction;

namespace SolarMonitor.ChildUser_TabPage
{
    public partial class AlertEvent : DevExpress.XtraEditors.XtraUserControl
    {
        //
        DataTable Table_Report = new DataTable();
        //加载语言信息类
        private void LaodLanguageInfo()
        {
            lbStart.Text = Model_Data.Language.PublicInfo.StartTime;//起始时间
            lbEnd.Text = Model_Data.Language.PublicInfo.EndTime;//结束时间
            //按键文本初始值
            btOK.Text = Model_Data.Language.PublicInfo.OK;
            btPrint.Text = Model_Data.Language.PublicInfo.Print;
            btExport.Text = Model_Data.Language.PublicInfo.Export;
        }      
        //构造函数
        public AlertEvent()
        {
            InitializeComponent();
            LaodLanguageInfo();
            DtBegin.EditValue = DateTime.Now;
            deEnd.EditValue = DateTime.Now.AddDays(1);

            //设置更新面板信息
            tableDisplay1.SetColumnDateTimeFormat(0);
            //tableDisplay1.SetColumnWidth(130, 0);//设置时间宽度
            //tableDisplay1.SetColumnWidth(250, 3);//设置事件消息宽度
        }     
        //
        private void btOK_Click(object sender, EventArgs e)
        {
            DateTime BeginDate = DtBegin.DateTime.Date + teBegin.Time.TimeOfDay;
            DateTime EndDate = deEnd.DateTime.Date + teEnd.Time.TimeOfDay;

            if (EndDate > BeginDate)
            {
                try
                {
                    DataTable AlertEventTable = ACCESSDBDAL.AccessServer.GetAlermHistoricEvent(BeginDate, EndDate);
                    tableDisplay1.DataSource = AlertEventTable;
                    Table_Report = AlertEventTable;
                    tableDisplay1.DataSource = Table_Report;
                    tableDisplay1.SetColumnDateTimeFormat(0);
                    tableDisplay1.SetColumnAutoWidth();
                    tableDisplay1.SetColumnWidth(130, 0);
                }
                catch (Exception str)
                {
                    throw;
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.Desc.TimeLimit, Model_Data.Language.AlarmClass.Warning);
            }
        }
        //
        private void btExport_Click(object sender, EventArgs e)
        {
            if (Table_Report == null)
            {
                MessageBox.Show(Model_Data.Language.PublicInfo.NoDataFound, Model_Data.Language.PublicInfo.Info);
                return;
            }
            else
            {
                ExportClass.ExportToSvc(Table_Report, "EventLog");
            }
        }
        //
        private void btPrint_Click(object sender, EventArgs e)
        {
            if (Table_Report == null)
            {
                MessageBox.Show(Model_Data.Language.PublicInfo.NoDataFound, Model_Data.Language.PublicInfo.Info);
                return;
            }
            else
            {
                PrintClass.PrintDataTable(Table_Report);
            }
        }

    }
}
