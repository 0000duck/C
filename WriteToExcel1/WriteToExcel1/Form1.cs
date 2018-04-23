using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace WriteToExcel1
{
    public partial class Form1 : Form
    {
        

        
        public Form1()
        {
            InitializeComponent();
            
          //  this.app.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            write();
        }
        public void write()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook xBook = app.Workbooks.Open(@"d:\xuejun\C#\电化学实验数据记录表.xlsx");
            Worksheet xSheet = xBook.Sheets[1];
            int row = xBook.Sheets.Count;
            //int rowsCount = xSheet.get_Range("A65536", "A65536").get_End(Microsoft.Office.Interop.Excel.XlDirection.xlUp).Row;
            //int rowsCount = (int)xSheet.get_Range("A65536", "A65536");
            MessageBox.Show(row.ToString());
            Range carAmount = xSheet.get_Range("J1", Missing.Value);
            carAmount.Value2 = "354dgs";
            carAmount.Interior.ColorIndex = 3; //设备Range的背景色

            Range invalid_license_plate = xSheet.get_Range("M1", Missing.Value);
            invalid_license_plate.Value2 = "gdfsgdsfg";
            invalid_license_plate.Interior.ColorIndex = 3; //设备Range的背景色

            Range chinese_character_wrong = xSheet.get_Range("N2", Missing.Value);
            chinese_character_wrong.Value2 = "DSFGDFGSF";
            chinese_character_wrong.Interior.ColorIndex = 3; //设备Range的背景色

            Range letter_wrong = xSheet.get_Range("O3", Missing.Value);
            letter_wrong.Value2 = "DSFGSFGSDFG";
            letter_wrong.Interior.ColorIndex = 3; //设备Range的背景色

            Range number_wrong = xSheet.get_Range("P6", Missing.Value);
            number_wrong.Value2 = "SDFGFGFGFGDSERTHFGD";
            number_wrong.Interior.ColorIndex = 3; //设备Range的背景色

            Range recognition_wrong = xSheet.get_Range("Q4", Missing.Value);
            recognition_wrong.Value2 = "GDSTRU$%#^TGH";
            recognition_wrong.Interior.ColorIndex = 3; //设备Range的背景色

            Range wrong_amount = xSheet.get_Range("T4", Missing.Value);
            wrong_amount.Value2 = "DFSGTR%#$%";
            wrong_amount.Interior.ColorIndex = 3; //设备Range的背景色

            Range right_amount = xSheet.get_Range("U4", Missing.Value);
            right_amount.Value2 = "GFDSF";
            right_amount.Interior.ColorIndex = 3; //设备Range的背景色

            xBook.Save();

            //6.从内存中关闭Excel对象
            xSheet = null;
            xBook = null;
            app.Quit(); //这一句非常重要，否则Excel对象不能从内存中退出
            app = null;
            MessageBox.Show("写入成功", "提示", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            FileStream fs = new FileStream(@"d:\xuejun\C#\text.csv",FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            long fl = fs.Length;
            fs.Seek(fl, SeekOrigin.End);
            sw.WriteLine(s);
            sw.Close();
            fs.Close();

        }
    }
}
