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
    public partial class PrimaryExamForm : Form
    {
        public PrimaryExamForm()
        {
            InitializeComponent();
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            ExamScore();
        }

        //评分方法
        private void ExamScore()
        {
            int Score = 0;
            if (this.Answer1.Text == "xuejun") Score = Score + 10;
            if (this.Answer21A.Checked) Score += 10;
            if (this.Answer22.Text == "PasswordChar") Score += 10; ;
            if (this.Answer23.Text == "Text") Score += 10; 
            if(this.Answer1.Text == "xuejun" && this.Answer21A.Checked && this.Answer22.Text == "PasswordChar" && this.Answer23.Text == "Text")
                Score += 10;
            this.ExamTime.Enabled = false;
            this.btnGrade.Enabled = false;
            this.TotalScore.Text = Score.ToString();
        }

        int ExamSecond = 0;//考试用时(秒）

        private void ExamTime_Tick(object sender, EventArgs e)
        {
            if(ExamSecond<120)
            {
                ExamSecond++;
                this.Time.Text = ExamSecond.ToString();
                this.toolStripProgressBar1.Value = ExamSecond;
            }
            else
            {
                ExamScore();
            }
        }

        private void PrimaryExamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show(this,"确定要关闭吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                PrimaryExamForm pef = new PrimaryExamForm();
                pef.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
