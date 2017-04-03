using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SolarMonitor.SolarSchedule;

namespace SolarMonitor.TabPage
{
    public partial class AddTask : Form
    {
        FormScheduleTask schedule;
        public AddTask(FormScheduleTask sched)
        {
            schedule = sched;
            InitializeComponent();
        }

        //dateTime最小值设置
        private void AddTask_Load(object sender, EventArgs e)
        {
            //dateTimePicker1.MinDate = DateTime.Now;//最小时间为当前时间
            radBtnOneDay.Checked = true;
            radioVoltage.Checked = true;
            this.Text = Model_Data.Language.ScheduleStr.addScheduleTask;//添加任务
            labTaskDate.Text = Model_Data.Language.ScheduleStr.taskDate;//任务时间
            groupFrequency.Text = Model_Data.Language.ScheduleStr.frequency;//频率
            radBtnOneDay.Text = Model_Data.Language.ScheduleStr.once;//一次
            radBtnEveDay.Text = Model_Data.Language.ScheduleStr.everyDay;//每天
            radWeekly.Text = Model_Data.Language.ScheduleStr.Weekly;//每周
            groupTask.Text = Model_Data.Language.ScheduleStr.task;//任务
            radioVoltage.Text = Model_Data.Language.ScheduleStr.BatteryTest;//电池测试
            radStartInverter.Text = Model_Data.Language.ScheduleStr.OpenTheInverter;//启动逆变器
            radCloseInverter.Text = Model_Data.Language.ScheduleStr.CloseTheInverter;//倒计时关闭逆变器
            AddOK.Text = Model_Data.Language.ScheduleStr.OK;//确定
            AddCancel.Text = Model_Data.Language.ScheduleStr.cancel;//取消

            //
        }
        DataTable pk = new DataTable();
        //添加任务
        private void AddOK_Click(object sender, EventArgs e)
        {
            ScheduleFrequence frequence = 0;
            ScheduleOffGrid schoffGrid = ScheduleOffGrid.On;
            RadioButton[] freqs = { radBtnOneDay, radBtnEveDay, radWeekly };//频率
            RadioButton[] Events = { radStartInverter, radCloseInverter, radioVoltage};//事件
            foreach (RadioButton freq in freqs) {
                if (freq.Checked == true) {
                    switch (Convert.ToInt16(freq.Tag)) {
                        case 0: frequence = ScheduleFrequence.Single; break;
                        case 1: frequence = ScheduleFrequence.EveryDay; break;
                        case 2: frequence = ScheduleFrequence.EveryWeek; break;
                    }
                }
            }
            foreach (RadioButton Event in Events)
            {
                if (Event.Checked == true)
                {
                    schoffGrid = (ScheduleOffGrid) Convert.ToInt16(Event.Tag);
                    break;
                }
            }
            //创建一个任务
            ScheduleTask schTask = new ScheduleTask(Convert.ToDateTime(dateTimePicker1.Text), frequence);
            schTask.tag = (int)schoffGrid;
            schTask.handle += new TaskHandle(new OffGridTask(schoffGrid).handle);
            SolarSchedule.ScheduleManager.getInstance().addTask(schTask);

            //schedule.listBox1.Items.Add(schTask);


            for (int i = 0; i < schedule.dataGridView1.Rows.Count; i++)
            {

                if (schedule.dataGridView1.Rows[i].Cells[0].Value.ToString() == null || schedule.dataGridView1.Rows[i].Cells[0].Value.ToString()=="")
                {

                    schedule.dataGridView1.Rows[i].Cells[0].Value = ScheduleTask.transTask(schTask.tag);
                    schedule.dataGridView1.Rows[i].Cells[1].Value = schTask.time.ToString("yyyy-MM-dd HH:mm:ss dddd");
                    schedule.dataGridView1.Rows[i].Cells[2].Value = ScheduleTask.transFreq(schTask.frequence);
                    schedule.dataGridView1.Rows[i].Cells[3].Value = ScheduleTask.transResult(schTask.result);
                    schedule.dataGridView1.Rows[i].Cells[4].Value = ScheduleTask.transPreResult(schTask.preExecuteTime);
                    schedule.dataGridView1.Rows[i].Cells[5].Value = schTask;
                    break;
                }
            }
            this.Close();
            
        }

        private void AddCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
    }
}