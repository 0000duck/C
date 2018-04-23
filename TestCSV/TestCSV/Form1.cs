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

namespace TestCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd,yyyy-dddd";
            
        }

        public static bool SaveCSV(String Data)     
        {
            bool re = true;
            try
            {
                FileStream fileStream = new FileStream(@"d:\xuejun\text.csv", FileMode.Append);
                StreamWriter sw = new StreamWriter(fileStream, System.Text.Encoding.UTF8);
                sw.WriteLine(Data);
                sw.Flush();
                sw.Close();
                fileStream.Close();
            }
            catch
            {
                re = false;
            }
            return re;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text;
            bool flag=SaveCSV(data);
            if (flag)
            {
                MessageBox.Show("保存成功");
            }
            label1.Text = dateTimePicker1.Text;
        }

    }
}
