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

namespace TestExcel
{
    public partial class WriteToExcel : Form
    {
        Microsoft.Office.Interop.Excel.Application objApp;
        Microsoft.Office.Interop.Excel._Workbook objBook;
        public WriteToExcel()
        {
            InitializeComponent();
            objApp = new Microsoft.Office.Interop.Excel.Application();
            _Workbook wb = objApp.Workbooks.Add(@"d:\xuejun\C#\电化学实验数据记录表.xlsx");
            Sheets sh = wb.Sheets;
            _Worksheet worksheet = sh.get_Item(1);
            int row_ = 2;

            worksheet.Cells[row_, 1] = 1.ToString();  //J4 车辆数
            worksheet.Cells[row_, 2] = "fdsafsdfa2";  //M4 无效
            worksheet.Cells[row_, 3] = "fdsafsdf1a";  //N4  汉字错
            worksheet.Cells[row_, 4] = "fdsafsd45fa";  //O4  字符错
            worksheet.Cells[row_, 5] = "fdsafsd4fa";  //P4  数字错
            worksheet.Cells[row_, 6] = "fdsaf45sdfa";  //Q4  不识别
            worksheet.Cells[row_, 7] = "fdsafs12dfa";  //T4   错误
            worksheet.Cells[row_, 8] = "fdsafs3dfa";  //U4  正确
            string savaPath = @"E:\PassData\" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + ".xlsx";
            wb.SaveAs(savaPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);


            //4.关闭Excel对象
            wb.Close(Missing.Value, Missing.Value, Missing.Value);
            objApp.Quit();
        }

       
             
        
    }

        
}
