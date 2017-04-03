using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace SolarMonitor.MainForm.Sform
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            string str1 = string.Format("{0} {1} {2}", Model_Data.Language.Desc.CurrentVersion, 
                AssemblyProduct,
                AssemblyVersion);
            string str2 = Model_Data.Language.Desc.BelongsToEAST;
            label1.Text = str1;
            label2.Text = str2;
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
    }
}
