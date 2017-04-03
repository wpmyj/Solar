using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml;

namespace SolarMonitor.SolarSchedule
{
    /// <summary>
    /// 日程管理器
    /// </summary>     
    public class ScheduleManager
    {
        private static string path = System.Windows.Forms.Application.StartupPath + "\\scheduleTask.xml";
        public List<ScheduleTask> _tasks = new List<ScheduleTask>();
        private object locker = new object();//锁

        private static ScheduleManager manager = null;
        private ScheduleManager()
        {
            timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Interval = 10000;
            timer.Enabled = false;
        }

        public static ScheduleManager getInstance()
        {
            if (manager == null)
                manager = new ScheduleManager();
            return manager;
        }

        /*------------------- 管理器 ----------------------------------*/

        public void loadTask()
        {
            //初始化 任务列表
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                XmlDocument document = new XmlDocument();
                document.Load(fs);
                XmlNode root = document.LastChild;
                foreach (XmlNode item in root.ChildNodes)
                {

                    ScheduleFrequence freq = (ScheduleFrequence)Enum.Parse(typeof(ScheduleFrequence), item.Attributes["frequence"].Value, true);
                    ScheduleOffGrid type = (ScheduleOffGrid)Enum.Parse(typeof(ScheduleOffGrid), item.Attributes["type"].Value, true);
                    SolarSchedule.ScheduleTask st = new SolarSchedule.ScheduleTask(
                                    DateTime.Parse(item.Attributes["time"].Value),
                                    SolarSchedule.ScheduleFrequence.Single);
                    st.tag = (int)type;
                    st.handle += new TaskHandle(new OffGridTask(type).handle);
                    _tasks.Add(st);
                }
            }
        }

        public void addTask(ScheduleTask task)
        {
            try
            {
                Monitor.Enter(locker);
                _tasks.Add(task);
                System.Console.WriteLine(String.Format("添加任务---- 任务时间：{0}", task.time.ToString("yyyy-MM-dd HH:mm:ss:fff")));
                saveShedule();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        public void removeTask(ScheduleTask task)
        {
            try
            {
                Monitor.Enter(locker);
                if (_tasks.Remove(task))
                    System.Console.WriteLine(String.Format("移除任务---- 任务时间：{0}", task.time.ToString("yyyy-MM-dd HH:mm:ss:fff")));
                else
                    System.Console.WriteLine(String.Format("移除任务---- 失败，不存在 任务时间：{0}", task.time.ToString("yyyy-MM-dd HH:mm:ss:fff")));
                saveShedule();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        /*------------------- 文件IO操作 ----------------------------------*/

        private void saveShedule()
        {
            using (FileStream fs = File.Open(path, FileMode.Create))
            {
                XmlDocument doc = new XmlDocument();
                //声明
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(dec);
                XmlElement root = doc.CreateElement("root");
                //
                foreach (var item in _tasks)
                {
                    XmlElement element = doc.CreateElement("data");
                    element.SetAttribute("time", item.time.ToString("yyyy-MM-dd HH:mm:ss"));
                    element.SetAttribute("frequence",item.frequence.ToString());
                    element.SetAttribute("type", ((ScheduleOffGrid)item.tag).ToString());
                    root.AppendChild(element);
                }
                doc.AppendChild(root);
                doc.Save(fs);
            }
        }

        /*------------------- 执行器 ----------------------------------*/

        System.Timers.Timer timer;

        public void start()
        {
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            System.Console.WriteLine("timer start");
        }

        public void stop()
        {
            timer.Stop();
            timer.Elapsed -= new System.Timers.ElapsedEventHandler(timer_Elapsed);
            System.Console.WriteLine("timer stop");
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Console.WriteLine("timer elapsed:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            List<ScheduleTask> tempTasks = new List<ScheduleTask>();
            try
            {
                Monitor.Enter(locker);
                //先锁住进行快速拷贝
                foreach (var item in _tasks)
                {                             
                    //判断任务状态（时间，执行状态）
                    int second = Math.Abs((int)(item.time - DateTime.Now).TotalSeconds);
                    if (second < 15)
                        tempTasks.Add(item);
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                //释放任务锁定
                Monitor.Exit(locker);
            }
            //执行
            foreach (var item in tempTasks)
            {
                item.execute();//执行任务
            }
            tempTasks.Clear();
        }

    }

}
