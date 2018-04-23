using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出XToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 初级XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrimaryExamForm pef = new PrimaryExamForm();
            pef.Show();
        }

        private void 中级SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecondaryExamForm sef = new SecondaryExamForm();
            sef.Show();
        }

        private void 高级AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedExamForm aef = new AdvancedExamForm();
            aef.Show();
        }

  

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            String sltItem = this.toolStripComboBox1.Text;
            switch(sltItem)
            {
                case("初级试题"):
                    PrimaryExamForm pef = new PrimaryExamForm();
                    pef.ShowDialog();
                    break;
                case("中级试题"):
                    SecondaryExamForm sef = new SecondaryExamForm();
                    sef.Show();
                    break;
                case("高级试题"):
                    AdvancedExamForm adf = new AdvancedExamForm();
                    adf.Show();
                    break;
            }
        }

        private void 关于系统AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1 = new AboutBox1();
            ab1.ShowDialog();
        }
    }
}
