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
            //1.��ֹ����ظ����� 
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

            //����ǵ�һ�����У����ȡ����������Ϣ�����޸�����
            //��������Ժ����õ�һ�����б�־λ
            string Inition = ConfigurationManager.AppSettings["Inition"];
            if (Inition == "No")
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string cnfile = Application.StartupPath + "\\DeviceCN.xml";//���������ļ�
                string enfile = Application.StartupPath + "\\DeviceEN.xml";//Ӣ�������ļ�
                if (!System.IO.File.Exists(cnfile) && !System.IO.File.Exists(enfile))//��������
                {
                    MessageBox.Show("cannot find configfile!");
                    return;
                }
                if (System.IO.File.Exists(cnfile) && System.IO.File.Exists(enfile))//������
                {
                    //���԰汾����ΪӢ��                    
                    //config.AppSettings.Settings["Culture"].Value = "EN";
                    config.AppSettings.Settings["Culture"].Value = "CN";
                }
                else if (System.IO.File.Exists(enfile))//ֻ����Ӣ��
                {
                    //���԰汾����ΪӢ��
                    config.AppSettings.Settings["Culture"].Value = "EN";
                }
                else if (System.IO.File.Exists(cnfile))//ֻ��������
                {
                    //���԰汾����Ϊ����
                    config.AppSettings.Settings["Culture"].Value = "CN";
                }
                //���³�ʼ��״̬
                config.AppSettings.Settings["Inition"].Value = "Yes";
                //��������
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
            string lanPathName = Application.StartupPath + "\\" + culture + ".xml";//·��
            Model_Data.Language.LoadLanguageEntity.LoadLanguageInfo(culture, lanPathName);//mark_zq

            //�������ݣ�������ɹ���ֱ���˳�����
            if (!DeviceObj.Inition())
            {
                MessageBox.Show("Get Data Faild!");
                return;
            }
            
            Application.Run(new SolarMonitor.MainForm.Smachine());

            manager.stop();
            ACCESSDBDAL.AccessDbHelper.DisposeConn();//�Ͽ����ݿ�����
            
        }

    }
}
