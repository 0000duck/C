using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Micro_ECM_V2._0
{
    public partial class SaveData : Form
    {
        public static string backDirectory=@"d:\MicroECM\backup";
        public static string ECMFile=@"d:\MicroECM\ExperimentData.xls";
        public int Count = 0;
        public SaveData()
        {
            InitializeComponent();
            readOrCreate();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            //dateTimePicker.CustomFormat = "yyyy.M.d-H:m:s";
            dateTimePicker.CustomFormat = "yyyy.M.d";
            
            string time = dateTimePicker.Value.ToString();                //时间
            string speed = watermarkTextBox6.Text;            //转速值
            string gap = watermarkTextBox5.Text;              //加工间隙
            string resistance = comboBox2.Text;               //电阻值
            string lowVoltage = watermarkTextBox1.Text;       //最低电压
            string highVoltage = watermarkTextBox2.Text;      //最高电压
            string solutionConcentration = comboBox1.Text;    //溶液浓度
            string gapVoltage = watermarkTextBox3.Text;       //间隙电压 
            string workSpeed = textBox1.Text;                 //加工速度
            string NaClO3 = watermarkTextBox4.Text;           //氯酸钠浓度
            string complexation = watermarkTextBox7.Text;     //络合剂质量
            string pulseWidth = watermarkTextBox8.Text;       //脉冲宽度
            string diameter = watermarkTextBox9.Text;            //点击直径
            string remarks = richTextBox1.Text;               //备注
            string lowCurrent="null";                         //申明最低电流变量
            string highCurrent = "null";                         //申明最高电流变量
            if (resistance == null||resistance=="")
                MessageBox.Show("请输入电阻值");
            else if (lowVoltage == null || lowVoltage == "")
                MessageBox.Show("请输入最低电压");
            else
            {
                lowCurrent = (float.Parse(lowVoltage) / float.Parse(resistance)).ToString("f2");
                if (highVoltage == null || highVoltage == "")
                    MessageBox.Show("请输入最高电压");
                else
                {
                    highCurrent = (float.Parse(highVoltage) / float.Parse(resistance)).ToString("f2");
                    string[] data = new string[] { time, speed, gap, resistance, lowCurrent + "-" + highCurrent, lowVoltage + "-" + highVoltage, solutionConcentration, gapVoltage, workSpeed,diameter, "氯酸钠" + NaClO3 + "g" + "+" + "络合剂" + complexation + "g",remarks,pulseWidth };
                    if (SaveToExcel(ECMFile, data) > 0)
                        MessageBox.Show("文件保存成功！");
                    else
                        MessageBox.Show("保存失败，请再试！");
                    
                }
            }
            
        }

        

        //判断文件是否被占用
        public static bool IsFileInUse(string fileName,out FileStream fs)
        {
            bool inUse = true;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,
                FileShare.None);
                inUse = false;
            }
            catch
            {
                fs = null;
                MessageBox.Show("检查占用出错");
            }          
            return inUse;//true表示正在使用,false没有使用  
        }
        //判断备份文件夹是否存在
        public void readOrCreate()
        {
            try
            {
                if (!Directory.Exists(backDirectory))
                {
                    Directory.CreateDirectory(backDirectory);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //备份文件
        //public void backup()
        //{
        //    dateTimePicker1.Format = DateTimePickerFormat.Custom;
        //    dateTimePicker1.CustomFormat = "yyyy_M_d H_m_s";
        //    string time = dateTimePicker1.Text;
        //    dateTimePicker1.Visible = false;
        //    FileStream fs = null;
        //    if (!IsFileInUse(ECMFile, out fs))
        //    {
        //        fs.Close();
        //        String path = backDirectory + "\\" + time + "_back.xls";
        //        File.Copy(ECMFile, path);
        //    }
        //    else
        //    {
        //        MessageBox.Show("请关闭实验表格，再点击保存");
        //        if (fs != null)
        //            fs.Close(); 
        //    }
        //}

        public static int SaveToExcel(string filePath,string[] data)
        {
            FileStream fs = null;
            IWorkbook wk=null;
            ISheet sheet=null;
            ICell cell=null;
            int count = 0;
            if (!IsFileInUse(filePath, out fs))
            {
                try
                {
                    wk = new HSSFWorkbook(fs);
                    //wk = new XSSFWorkbook(fs);
                    fs.Close();
                    sheet = wk.GetSheetAt(0);
                    count = sheet.LastRowNum + 1;
                    IRow row = sheet.CreateRow(count);
                    for (int i = 0; i < data.Length; i++)
                    {
                        cell = row.CreateCell(i);
                        cell.SetCellValue(data[i]);
                        string str = row.GetCell(i).StringCellValue;
                    }                   
                    fs= File.OpenWrite(filePath);
                    wk.Write(fs);
                    fs.Close();                   
                }
                catch(Exception e)
                {
                    MessageBox.Show("错误提示：" + e.Message);
                    return -1;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();                    
                    fs = null;
                }
            }
            else
            {
                MessageBox.Show("请关闭实验表格，再点击保存");
                if (fs != null)
                    fs.Close();               
            }
            return count;
        }
    }
}
