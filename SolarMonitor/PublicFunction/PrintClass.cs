using System;
using System.Data;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace SolarMonitor.PublicFunction
{
    class PrintClass
    {
        private static String[] titles = new String[0];
        private static String[] Titles
        {
            set
            {
                titles = value as String[];
                if (null == titles)
                {
                    titles = new String[0];
                }
            }
            get
            {
                return titles;
            }
        }
        #region 相关变量定义
        private static Int32 pindex;
        private static Int32 curdgi;
        private static Int32[] width;
        private static Int32 pheight;
        private static Int32 pWidth;
        private static String printName = String.Empty;
        private static Font prtTextFont = new Font("Verdana", 10);
        private static Font prtTitleFont = new Font("宋体", 10);
        private static DataTable printedTable = new DataTable();

        private static Int32 left = 20;
        private static Int32 top = 20;
        private static Int32 rowOfDownDistance = 3;
        private static Int32 rowOfUpDistance = 2;
        DataTable Table_Report = null;
        static Int32 startColumnControls = 0;
        static Int32 endColumnControls = 0;
        #endregion
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="table"></param>
        public static void PrintDataTable(DataTable table)
        {
            if (table != null)
            {
                PrintDocument prtDocument = new PrintDocument();
                try
                {
                    if (printName == String.Empty)
                        printName = DateTime.Now.ToShortDateString();
                    prtDocument.PrinterSettings.PrinterName = printName;
                    prtDocument.DefaultPageSettings.Landscape = true;
                    prtDocument.OriginAtMargins = false;
                    PrintDialog prtDialog = new PrintDialog();
                    prtDialog.AllowSomePages = true;
                    prtDialog.ShowHelp = false;
                    prtDialog.Document = prtDocument;
                    if (DialogResult.OK != prtDialog.ShowDialog())
                    {
                        return;
                    }
                    printedTable = table;
                    pindex = 0;
                    curdgi = 0;
                    width = new Int32[printedTable.Columns.Count];
                    pheight = prtDocument.PrinterSettings.DefaultPageSettings.Bounds.Bottom;
                    pWidth = prtDocument.PrinterSettings.DefaultPageSettings.Bounds.Right;
                    prtDocument.PrintPage += new PrintPageEventHandler(Document_PrintPage);
                    prtDocument.Print();
                }
                catch (InvalidPrinterException)
                {
                    MessageBox.Show("no printer");
                }
                catch (Exception)
                {
                    MessageBox.Show("print error");
                }
                prtDocument.Dispose();
            }
            else
                MessageBox.Show(Model_Data.Language.PublicInfo.NoDataFound, Model_Data.Language.PublicInfo.Info);            
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="prtTable"></param>
        public static void PrintPreviewDataTable(DataTable prtTable)
        {
            if (prtTable != null)
            {
                PrintDocument prtDocument = new PrintDocument();
                try
                {
                    if (printName != String.Empty)
                    {
                        prtDocument.PrinterSettings.PrinterName = printName;
                    }
                    prtDocument.DefaultPageSettings.Landscape = true;
                    prtDocument.OriginAtMargins = false;
                    printedTable = prtTable;
                    pindex = 0;
                    curdgi = 0;
                    width = new int[printedTable.Columns.Count];
                    pheight = prtDocument.PrinterSettings.DefaultPageSettings.Bounds.Bottom;
                    pWidth = prtDocument.PrinterSettings.DefaultPageSettings.Bounds.Right;
                    prtDocument.PrintPage += new PrintPageEventHandler(Document_PrintPage);
                    PrintPreviewDialog prtPreviewDialog = new PrintPreviewDialog();
                    prtPreviewDialog.Document = prtDocument;
                    prtPreviewDialog.ShowIcon = false;
                    prtPreviewDialog.WindowState = FormWindowState.Maximized;
                    prtPreviewDialog.ShowDialog();

                }
                catch (InvalidPrinterException)
                {
                    MessageBox.Show("没有安装打印机");
                }
                catch (Exception)
                {
                    MessageBox.Show("打印预览失败");
                }
            }
            else
            {
                //MessageBox.Show("数据信息为空", "提示");
                MessageBox.Show(Model_Data.Language.PublicInfo.NoDataFound, Model_Data.Language.PublicInfo.Info);
            }
        }
        /// <summary>
        /// 打印文件定制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private static void Document_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Int32 x = left;
            Int32 y = top;
            Int32 rowOfTop = top;
            Int32 i;
            Pen pen = new Pen(Brushes.Black, 1);
            if (0 == pindex)
            {
                for (i = 0; i < titles.Length; i++)
                {
                    ev.Graphics.DrawString(titles[i], prtTitleFont, Brushes.Black, left, y + rowOfUpDistance);
                    y += prtTextFont.Height + rowOfDownDistance;
                }
                rowOfTop = y;
                foreach (DataRow dr in printedTable.Rows)
                {
                    for (i = 0; i < printedTable.Columns.Count; i++)
                    {
                        Int32 colwidth = Convert.ToInt16(ev.Graphics.MeasureString(dr[i].ToString().Trim(), prtTextFont).Width);
                        if (colwidth > width[i])
                        {
                            width[i] = colwidth;
                        }
                    }
                }
            }
            for (i = endColumnControls; i < printedTable.Columns.Count; i++)
            {
                String headtext = printedTable.Columns[i].ColumnName.Trim();
                if (pindex == 0)
                {
                    int colwidth = Convert.ToInt16(ev.Graphics.MeasureString(headtext, prtTextFont).Width);
                    if (colwidth > width[i])
                    {
                        width[i] = colwidth;
                    }
                }
                if (x + width[i] > pheight)
                {
                    break;
                }
                ev.Graphics.DrawString(headtext, prtTextFont, Brushes.Black, x, y + rowOfUpDistance);
                x += width[i];
            }
            startColumnControls = endColumnControls;
            if (i < printedTable.Columns.Count)
            {
                endColumnControls = i;
                ev.HasMorePages = true;
            }
            else
            {
                endColumnControls = printedTable.Columns.Count;
            }
            ev.Graphics.DrawLine(pen, left, rowOfTop, x, rowOfTop);
            y += rowOfUpDistance + prtTextFont.Height + rowOfDownDistance;
            ev.Graphics.DrawLine(pen, left, y, x, y);
            for (i = curdgi; i < printedTable.Rows.Count; i++)
            {
                x = left;
                for (Int32 j = startColumnControls; j < endColumnControls; j++)
                {
                    ev.Graphics.DrawString(printedTable.Rows[i][j].ToString().Trim(), prtTextFont, Brushes.Black, x, y + rowOfUpDistance);
                    x += width[j];
                }
                y += rowOfUpDistance + prtTextFont.Height + rowOfDownDistance;
                ev.Graphics.DrawLine(pen, left, y, x, y);
                if (y > pWidth - prtTextFont.Height - 30)
                {
                    break;
                }
            }
            ev.Graphics.DrawLine(pen, left, rowOfTop, left, y);
            x = left;
            for (Int32 k = startColumnControls; k < endColumnControls; k++)
            {
                x += width[k];
                ev.Graphics.DrawLine(pen, x, rowOfTop, x, y);
            }
            if (y > pWidth - prtTextFont.Height - 30)
            {
                pindex++;
                if (0 != startColumnControls)
                {
                    curdgi = i + 1;
                }
                if (!ev.HasMorePages)
                {
                    endColumnControls = 0;
                }
                ev.HasMorePages = true;
            }
        }

    }
}
