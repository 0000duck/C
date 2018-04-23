using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CsProcess
{
    public partial class MianForm : Form
    {
        public MianForm()
        {
            InitializeComponent();
        }

        

        private void btnStar1_Click(object sender, EventArgs e)
        {
            process1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo fInfo = new FileInfo(@"C:\Windows\System32\calc.exe");
            if (fInfo.Exists)
            {
                Process prcsSelfExam = new Process();
                prcsSelfExam.StartInfo.FileName = fInfo.FullName;
                prcsSelfExam.Start();
            }
            else
            {
                MessageBox.Show("文件：" + fInfo.FullName + "不存在！");
            }
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            Process[] cp;
            cp = Process.GetProcessesByName("calc");
            foreach (Process instance in cp)
            {
                instance.CloseMainWindow();
            }
        }
    }
}
