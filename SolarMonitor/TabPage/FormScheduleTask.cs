using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Model_Data;
using SolarMonitor.SolarSchedule;

namespace SolarMonitor.TabPage
{
    public partial class FormScheduleTask : Form
    {
        public FormScheduleTask()
        {
            InitializeComponent();
        }

        DataTable pk = new DataTable();//创建表格
        DataRow dr;//
        //添加任务
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (SolarSchedule.ScheduleManager.getInstance()._tasks.Count == 7)
            {
                MessageBox.Show(Model_Data.Language.ScheduleStr.MaxTask, Model_Data.Language.PublicInfo.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddTask addTask = new AddTask(this);
            addTask.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //删除GridView显示

            foreach (DataGridViewRow dgvRow in dataGridView1.SelectedRows)
            {
                if (dgvRow.Cells[5].Value.ToString() != null && dgvRow.Cells[5].Value.ToString() != "")
                {
                    ScheduleTask task = (ScheduleTask)(dgvRow.Cells[5].Value);
                    ScheduleManager.getInstance().removeTask(task);
                    dataGridView1.Rows.Remove(dgvRow);
                    //int row = this.dataGridView1.CurrentCell.RowIndex;

                }

            }


        }
        //加载初始值
        private void Schedule_Load(object sender, EventArgs e)
        {

            this.Text = Model_Data.Language.ScheduleStr.scheduleManager;//日程管理
            btnAdd.Text = Model_Data.Language.ScheduleStr.addScheduleTask;//添加任务
            btnDelete.Text = Model_Data.Language.ScheduleStr.deleteScheduleTask;//删除任务

            SolarSchedule.ScheduleManager manager = SolarSchedule.ScheduleManager.getInstance();

            //===================dataGridView======================//

            if (pk.Rows.Count == 0)
            {
                pk.Columns.Add(Model_Data.Language.ScheduleStr.Event);
                pk.Columns.Add(Model_Data.Language.ScheduleStr.ExecutionTime);
                pk.Columns.Add(Model_Data.Language.ScheduleStr.frequency);
                pk.Columns.Add(Model_Data.Language.ScheduleStr.Result);
                pk.Columns.Add(Model_Data.Language.ScheduleStr.Lastexecution);
                pk.Columns.Add("obj", typeof(ScheduleTask));
                //col.ColumnMapping = MappingType.Hidden;

            }
            for (int i = 0; i < manager._tasks.Count; i++)
            {
                DataRow dr = pk.NewRow();
                dr[Model_Data.Language.ScheduleStr.Event] = ScheduleTask.transTask(manager._tasks[i].tag);
                dr[Model_Data.Language.ScheduleStr.ExecutionTime] = manager._tasks[i].time.ToString("yyyy-MM-dd HH:mm:ss");
                dr[Model_Data.Language.ScheduleStr.frequency] = ScheduleTask.transFreq(manager._tasks[i].frequence);
                dr[Model_Data.Language.ScheduleStr.Result] = ScheduleTask.transResult(manager._tasks[i].result);
                dr[Model_Data.Language.ScheduleStr.Lastexecution] = ScheduleTask.transPreResult(manager._tasks[i].preExecuteTime);
                dr["obj"] = manager._tasks[i];

                pk.Rows.Add(dr);

            }

            //数据不够5行，添加空白行
            int count = pk.Rows.Count;
            for (int i = 6 - count; i >= 0; i--)
            {
                dr = pk.NewRow();
                pk.Rows.Add(dr);

            }

            dataGridView1.DataSource = pk;
            this.dataGridView1.Columns[1].FillWeight = 130;//设置列宽
            this.dataGridView1.Columns[4].FillWeight = 130;
            dataGridView1.Columns[5].Visible = false;
            //取消列排序
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //定义行列头显示
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;//列颜?色?
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;//行头颜色
        }
        //添加行号
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                int linen = 0;
                linen = e.RowIndex + 1;
                string line = linen.ToString();
                e.Graphics.DrawString(line, e.InheritedRowStyle.Font, b, e.RowBounds.Location.X, e.RowBounds.Location.Y + 5);
                SolidBrush B = new SolidBrush(Color.Red);
            }
        }
        //移除行引发的事件
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            if (dataGridView1.Rows.Count != 0)
            {

                for (int i = 0; i <= 6 - count; i++)
                {
                    dr = pk.NewRow();
                    pk.Rows.Add(dr);

                }

            }
        }


    }
}