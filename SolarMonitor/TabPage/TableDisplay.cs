using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SolarMonitor.ChildUser_TabPage
{
    public partial class TableDisplay : DevExpress.XtraEditors.XtraUserControl
    {      
        public TableDisplay()
        {
            InitializeComponent();
            GridView_Table.DataSource = BS;
            gridView1.OptionsView.ColumnAutoWidth = false;
        }
         
        private BindingSource BS = new BindingSource();
        /// <summary>
        /// 填充表格的数据源
        /// </summary>
        public DataTable DataSource
        {
            set
            {
                BS.DataSource = null;// Clear();
                BS.DataSource = value;
            }
        }
        /// <summary>
        /// 设置面板显示数据
        /// </summary>
        public string SetPanelText
        {
            set
            {
                gridView1.GroupPanelText = value;
            }
        }

        /// <summary>
        /// 修改ListForm的列标题：只改Caption不改Name //mark zq
        /// </summary>
        public void ModifyColumnCaption()
        {
            SetPanelText = Model_Data.Language.PublicInfo.DevRealtimeData_ListForm;
            gridView1.Columns[0].Caption = Model_Data.Language. PublicInfo.ID_ListForm;
            gridView1.Columns[1].Caption = Model_Data.Language.PublicInfo.SignalName_ListForm;
            gridView1.Columns[2].Caption = Model_Data.Language.PublicInfo.SignalValue_ListForm;
            gridView1.Columns[3].Caption = Model_Data.Language.PublicInfo.Unit_ListForm;
        }

        /// <summary>
        /// 设置面板显示数据
        /// </summary>
        public string PanelText
        {
            set
            {
                gridView1.GroupPanelText = value;
            }
        }

        /// <summary>
        /// 设置具体一列的 显示格式为 日期时间显示格式
        /// </summary>
        /// <param name="ColIndex"></param>
        public void SetColumnDateTimeFormat(int ColIndex)
        {
            if (gridView1.Columns.Count <= ColIndex)
                return;
            gridView1.Columns[ColIndex].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss ";
        }

        /// <summary>
        /// 设置某一列的 列宽度
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="colIndex">第几列</param>
        public void SetColumnWidth(int width, int colIndex)
        {
            if (gridView1.Columns.Count <= colIndex)
                return;
            gridView1.Columns[colIndex].Width = width;
        }

        /// <summary>
        /// 清理列;如果你需要更改数据源，需要调用本函数
        /// </summary>
        public void ClearColumns()
        {
            if (gridView1.Columns.Count < 1)
                return;
            gridView1.Columns.Clear();
        }

        /// <summary>
        /// 根据数据源列数调整其显示模式 modify by cheny
        /// </summary>
        public void SetColumnAutoWidth()
        {
            if (gridView1.Columns.Count < 10)
            {
                this.gridView1.OptionsCustomization.AllowColumnResizing = true;
                gridView1.OptionsView.ColumnAutoWidth = true;
            }
            else
            {
                gridView1.OptionsView.ColumnAutoWidth = false;
                this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            }
        }

    }
}
