using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;


namespace SolarMonitor.PublicFunction
{
    class ExportClass
    {

        /// <summary>
        /// 导出为CSV文件
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        /// <param name="strName"></param>
        public static void ExportToSvc(DataTable dt, string strName)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //设置文件类型
            //书写规则例如：txt files(*.txt)|*.txt
            saveFileDialog1.Filter = "CSV files(*.csv)|*.csv";
            //设置默认文件名（可以不设置）
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + strName;
            saveFileDialog1.AddExtension = true;
            //保存对话框是否记忆上次打开的目录
            saveFileDialog1.RestoreDirectory = true;
            DialogResult result = saveFileDialog1.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                string localFilePath = saveFileDialog1.FileName.ToString();
                //保持文件
                CSV(dt, localFilePath);
            }
        }
        private static void CSV(DataTable TB, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            //先打印标头
            StringBuilder strColu = new StringBuilder();
            StringBuilder strValue = new StringBuilder();
            int i = 0;
            try
            {
                StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.CreateNew), Encoding.GetEncoding("GB2312"));
                for (i = 0; i <= TB.Columns.Count - 1; i++)
                {
                    strColu.Append(TB.Columns[i].ColumnName);
                    strColu.Append(",");
                }
                strColu.Remove(strColu.Length - 1, 1);//移出掉最后一个,字符
                sw.WriteLine(strColu);
                foreach (DataRow dr in TB.Rows)
                {
                    strValue.Remove(0, strValue.Length);//移出
                    for (i = 0; i <= TB.Columns.Count - 1; i++)
                    {
                        strValue.Append(dr[i].ToString());
                        strValue.Append(",");
                    }
                    strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符
                    sw.WriteLine(strValue);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
