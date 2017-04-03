using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SolarMonitor.PublicFunction;
using Model_Data;

namespace SolarMonitor.ChildUser_TabPage
{
    //历史曲线
    public partial class HistoricTable : DevExpress.XtraEditors.XtraUserControl
    {
        //传递到本界面的 端口 设备 信息 ----实体字段
        DataTable Table_Report = null;
        //加载语言显示信息类函数
        private void LoadLanguageInfo()
        {
            lbStart.Text = Model_Data.Language.PublicInfo.StartTime;
            lbEnd.Text = Model_Data.Language.PublicInfo.EndTime;
            btOK.Text = Model_Data.Language.PublicInfo.View;

            btPrint.Text = Model_Data.Language.PublicInfo.Print;
            btExport.Text = Model_Data.Language.PublicInfo.Export;
        }
        //构造函数
        public HistoricTable()
        {
            InitializeComponent();
            LoadLanguageInfo();
            //初始化时间结束时间---清空开始时间
            DtBegin.EditValue = DateTime.Now;
            deEnd.EditValue = DateTime.Now.AddDays(1);
            gridView1.OptionsView.ColumnAutoWidth = false;
        }
        //
        private void btOK_Click(object sender, EventArgs e)
        {
            DateTime BeginDate = DtBegin.DateTime.Date + teBegin.Time.TimeOfDay;
            DateTime EndDate = deEnd.DateTime.Date + teEnd.Time.TimeOfDay;

            if (BeginDate > EndDate)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.Desc.SelStartTime, Model_Data.Language.Desc.Warning_ChildUserTab);//modified by zq
            }
            else
            {
                try
                {
                    DeviceModel dm = DeviceObj.GetDeviceModel();
                    DataTable dataTable = ACCESSDBDAL.AccessServer.GetHistoricData(BeginDate, EndDate,dm.TableName);
                    ReplaceColumnName(dataTable);
                    GridView_HistoricTable.DataSource = dataTable;
                    Table_Report = dataTable;
                    gridView1.Columns[Model_Data.Language.PublicInfo.DateTime].Width = 130;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.Columns[Model_Data.Language.PublicInfo.DateTime].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss ";
                }
                catch (Exception str)
                {
                    //DevExpress.XtraEditors.XtraMessageBox.Show("获取数据失败！原因如下：\r\n"+str, "警告");
                    DevExpress.XtraEditors.XtraMessageBox.Show(Model_Data.Language.Desc.ObtainFailure + "\r\n" + str, Model_Data.Language.Desc.Warning_ChildUserTab);//modified by zq
                }
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
                ExportClass.ExportToSvc(Table_Report, "DataLog");
            }
        }

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

        private void ReplaceColumnName(DataTable valueTable)
        {
            valueTable.Columns.Remove("KeyId");
            valueTable.Columns[0].ColumnName = (Model_Data.Language.PublicInfo.DateTime);
            DeviceModel dm = DeviceObj.GetDeviceModel();
            if (dm == null) return;
            int i = 1;
            foreach (AnalogModel item in dm.Analog)
            {
                if (!item.ISRecord) continue;
                valueTable.Columns[i].ColumnName = string.Format("{0}({1})",item.SignalName,item.SignalUnit);
                i++;
            }
        }

    }
}
