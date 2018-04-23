using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace NPOIExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,

                FileShare.None);

                inUse = false;
            }
            catch
            {

            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用  
        }
        public void ReadFromExcelFile(String filePath)
        {
            if (IsFileInUse(filePath))
            {
                MessageBox.Show("qingguanbixiangguanwenjian");
            }
            else
            {
                IWorkbook wk = null;
                String extension = System.IO.Path.GetExtension(filePath);
                FileStream fs = File.OpenRead(filePath);
                wk = new XSSFWorkbook(fs);
                fs.Close();
                ISheet sheet = wk.GetSheetAt(0);
                IRow row = sheet.GetRow(0);
                int count = sheet.LastRowNum;
                MessageBox.Show(count.ToString());
            }
            //int offset = 0;
            //for (int i = 0; i <= sheet.LastRowNum; i++)
            //{
            //    row = sheet.GetRow(i);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadFromExcelFile(@"d:\xuejun\test.xlsx");
        }
    }
}
