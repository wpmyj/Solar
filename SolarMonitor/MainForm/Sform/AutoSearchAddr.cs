using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Communication;
using Model_Data;
using Model_Data.CommunicateEntity;

namespace SolarMonitor.MainForm.Sform
{
    public partial class AutoSearchAddr : DevExpress.XtraEditors.XtraForm
    {
        //
        private Thread SearcheThread;
        //
        private int adr_variable;
        //
        public AutoSearchAddr()
        {
            InitializeComponent();
            LoadLanguageInfo();
            adr_variable = DeviceObj.GetWrapper().DeviceList[0].Device.UnitId;//记录原先的设备地址
            bt_Finish.Enabled = false;
        }
        //加载语言类信息
        private void LoadLanguageInfo()
        {
            Text = Model_Data.Language.ChildForm.SearchText;
            layoutControlItem2.Text = Model_Data.Language.ChildForm.Addr;
            bt_Finish.Text = Model_Data.Language.ChildForm.AppAddr;
            bt_SearchDevice.Text = Model_Data.Language.ChildForm.SearchDev;
            marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.InPrepare;
        }
        //搜索/停止
        private void bt_SearchDevice_Click(object sender, EventArgs e)
        {
            if (bt_SearchDevice.Text == Model_Data.Language.ChildForm.SearchDev)
            {
                bt_SearchDevice.Text = Model_Data.Language.ChildForm.Termination;
                bt_Finish.Enabled = false;
                cb_adr.Properties.Items.Clear();

                SearcheThread = new Thread(ThreadWork);
                SearcheThread.Start(adr_variable);
            }
            else
            {
                //终止线程
                SearcheThread.Abort();
                SearcheThread.Join();
                DeviceObj.GetWrapper().ReCommunication();
                //恢复内存现场
                DeviceObj.GetWrapper().DeviceList[0].Device.UnitId = (byte)adr_variable;
                Communication.CommandCreat.CreatDeviceCommandList(DeviceObj.GetWrapper().Port.PortType, DeviceObj.GetWrapper().DeviceList[0]);

                marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.SearchEnd;
                list_Info.Items.Add(Model_Data.Language.ChildForm.SearchEnd);
                list_Info.SelectedIndex = list_Info.ItemCount - 1;

                //改变文字
                bt_SearchDevice.Text = Model_Data.Language.ChildForm.SearchDev;

                //是否可以应用地址
                if (cb_adr.Properties.Items.Count > 0)
                    bt_Finish.Enabled = true;
            }
        }
        //搜索执行
        private void ThreadWork(object adrr)
        {
            //如果有数据 则轮询所有设备
            for (int i = 1; i < 256; i++)
            {
                DeviceObj.GetWrapper().DeviceList[0].Device.UnitId = (byte)i;
                Communication.CommandCreat.CreatDeviceCommandList(DeviceObj.GetWrapper().Port.PortType, DeviceObj.GetWrapper().DeviceList[0]);
                int result = DeviceObj.GetWrapper().PollTest();
                //Thread.Sleep(10);
                if (result == -1)//如果端口无法打开，则直接退出
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.PortOpenFail;
                        list_Info.Items.Add(Model_Data.Language.ChildForm.PortOpenFail);
                        list_Info.SelectedIndex = list_Info.ItemCount - 1;
                    });
                    break;
                }
                else if (result == 0)//通讯失败
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.Addr + i.ToString() + Model_Data.Language.ChildForm.ConnFail;
                    });
                }
                else if (result > 0)//通讯成功
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.Addr + i.ToString() + " " + Model_Data.Language.ChildForm.ConnSucc;
                        list_Info.Items.Add(Model_Data.Language.ChildForm.Addr + i.ToString() + Model_Data.Language.ChildForm.ConnSucc);
                        list_Info.SelectedIndex = list_Info.ItemCount - 1;
                        cb_adr.Properties.Items.Add(i);
                        cb_adr.Text = i.ToString();
                    });
                }
            }
            //还原以前的状态
            DeviceObj.GetWrapper().DeviceList[0].Device.UnitId = (byte)adr_variable;
            Communication.CommandCreat.CreatDeviceCommandList(DeviceObj.GetWrapper().Port.PortType, DeviceObj.GetWrapper().DeviceList[0]);
            //搜索完成
            Invoke((MethodInvoker)delegate()
            {
                marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.TestComplete;
                list_Info.Items.Add(Model_Data.Language.ChildForm.TestComplete);
                list_Info.SelectedIndex = list_Info.ItemCount - 1;

                bt_SearchDevice.Text = Model_Data.Language.ChildForm.SearchDev;
                bt_Finish.Enabled = true;
                if (cb_adr.Properties.Items.Count > 0)
                    cb_adr.SelectedIndex = 0;
                else
                {
                    cb_adr.SelectedIndex = -1;
                    bt_Finish.Enabled = false;
                }
            });
        }
        //应用 新的设备地址
        private void bt_Finish_Click(object sender, EventArgs e)
        {
            //更新 地址到数据库
            marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.RenewDB;
            int address = Convert.ToInt32(cb_adr.Text);
            DeviceModel de = DeviceObj.GetDeviceModel();
            de.UnitId = (byte)address;
            DeviceObj.UpdateDevice(de);

            //更新内存：重新创建查询命令
            DeviceObj.GetWrapper().DeviceList[0].Device.UnitId = (byte)address;
            Communication.CommandCreat.CreatDeviceCommandList(DeviceObj.GetWrapper().Port.PortType, DeviceObj.GetWrapper().DeviceList[0]);

            //更新显示
            marqueeProgressBarControl1.Text = Model_Data.Language.ChildForm.StartNewAddr;
            list_Info.Items.Add(Model_Data.Language.ChildForm.StartNewAddr);
            list_Info.SelectedIndex = list_Info.ItemCount - 1;

        }
        //关闭前判断
        private void AutoSearchAddr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SearcheThread == null)
                return;
            if (SearcheThread.IsAlive)
            {
                e.Cancel = true;
                XtraMessageBox.Show(Model_Data.Language.ChildForm.SearchEndFirst);
            }
        }

    }
}
