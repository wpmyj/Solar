using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Text;
using System.IO;
using System.Diagnostics;
using DevExpress.LookAndFeel;
using SolarMonitor;

namespace WindowsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //1.防止软件重复启动 
            bool result;
            var mutex = new System.Threading.Mutex(true, "7CC5E20A-8572-4D6E-919A-FDAB6331D0BB", out result);
            if (!result)
            {
                MessageBox.Show("program has opened!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");          

            //如果是第一次运行，则读取语言配置信息，并修改配置
            //配置完成以后，设置第一次运行标志位
            string Inition = ConfigurationManager.AppSettings["Inition"];
            if (Inition == "No")
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string cnfile = Application.StartupPath + "\\DeviceCN.xml";//中文配置文件
                string enfile = Application.StartupPath + "\\DeviceEN.xml";//英文配置文件
                if (!System.IO.File.Exists(cnfile) && !System.IO.File.Exists(enfile))//都不存在
                {
                    MessageBox.Show("cannot find configfile!");
                    return;
                }
                if (System.IO.File.Exists(cnfile) && System.IO.File.Exists(enfile))//都存在
                {
                    //语言版本设置为英文                    
                    //config.AppSettings.Settings["Culture"].Value = "EN";
                    config.AppSettings.Settings["Culture"].Value = "CN";
                }
                else if (System.IO.File.Exists(enfile))//只存在英文
                {
                    //语言版本设置为英文
                    config.AppSettings.Settings["Culture"].Value = "EN";
                }
                else if (System.IO.File.Exists(cnfile))//只存在中文
                {
                    //语言版本设置为中文
                    config.AppSettings.Settings["Culture"].Value = "CN";
                }
                //更新初始化状态
                config.AppSettings.Settings["Inition"].Value = "Yes";
                //重新载入
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }


            //convert
            SolarMonitor.SolarSchedule.ScheduleManager manager = SolarMonitor.SolarSchedule.ScheduleManager.getInstance();
            manager.loadTask();
            manager.start();

            //
            string culture=ConfigurationManager.AppSettings["Culture"];
            if (string.IsNullOrEmpty(culture))
                culture = "CN";
            string lanPathName = Application.StartupPath + "\\" + culture + ".xml";//路径
            Model_Data.Language.LoadLanguageEntity.LoadLanguageInfo(culture, lanPathName);//mark_zq

            //载入数据，如果不成功则直接退出程序
            if (!DeviceObj.Inition())
            {
                MessageBox.Show("Get Data Faild!");
                return;
            }
            
            Application.Run(new SolarMonitor.MainForm.Smachine());

            manager.stop();
            ACCESSDBDAL.AccessDbHelper.DisposeConn();//断开数据库连接
            
        }

    }
}
