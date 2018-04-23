namespace ExamSystem
{
    partial class PrimaryExamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Answer1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Answer21A = new System.Windows.Forms.RadioButton();
            this.Answer21B = new System.Windows.Forms.RadioButton();
            this.Answer21C = new System.Windows.Forms.RadioButton();
            this.Answer21D = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.Answer22 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Answer23 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Answer3A = new System.Windows.Forms.CheckBox();
            this.Answer3B = new System.Windows.Forms.CheckBox();
            this.Answer3C = new System.Windows.Forms.CheckBox();
            this.Answer3D = new System.Windows.Forms.CheckBox();
            this.ExamTime = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TotalScore = new System.Windows.Forms.TextBox();
            this.btnGrade = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "一、填空题";
            // 
            // Answer1
            // 
            this.Answer1.Location = new System.Drawing.Point(47, 25);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(100, 21);
            this.Answer1.TabIndex = 1;
            this.Answer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(153, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "名字？";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "二、单项选择题";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "1、C#中直接放置在同一窗体上的单选按钮将构成：";
            // 
            // Answer21A
            // 
            this.Answer21A.AutoSize = true;
            this.Answer21A.Location = new System.Drawing.Point(60, 102);
            this.Answer21A.Name = "Answer21A";
            this.Answer21A.Size = new System.Drawing.Size(41, 16);
            this.Answer21A.TabIndex = 5;
            this.Answer21A.TabStop = true;
            this.Answer21A.Text = "1组";
            this.Answer21A.UseVisualStyleBackColor = true;
            // 
            // Answer21B
            // 
            this.Answer21B.AutoSize = true;
            this.Answer21B.Location = new System.Drawing.Point(136, 102);
            this.Answer21B.Name = "Answer21B";
            this.Answer21B.Size = new System.Drawing.Size(41, 16);
            this.Answer21B.TabIndex = 6;
            this.Answer21B.TabStop = true;
            this.Answer21B.Text = "2组";
            this.Answer21B.UseVisualStyleBackColor = true;
            // 
            // Answer21C
            // 
            this.Answer21C.AutoSize = true;
            this.Answer21C.Location = new System.Drawing.Point(212, 102);
            this.Answer21C.Name = "Answer21C";
            this.Answer21C.Size = new System.Drawing.Size(41, 16);
            this.Answer21C.TabIndex = 6;
            this.Answer21C.TabStop = true;
            this.Answer21C.Text = "3组";
            this.Answer21C.UseVisualStyleBackColor = true;
            // 
            // Answer21D
            // 
            this.Answer21D.AutoSize = true;
            this.Answer21D.Location = new System.Drawing.Point(288, 102);
            this.Answer21D.Name = "Answer21D";
            this.Answer21D.Size = new System.Drawing.Size(41, 16);
            this.Answer21D.TabIndex = 6;
            this.Answer21D.TabStop = true;
            this.Answer21D.Text = "4组";
            this.Answer21D.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "2、C#中可以实现密码输入的文本框属性是：";
            // 
            // Answer22
            // 
            this.Answer22.FormattingEnabled = true;
            this.Answer22.ItemHeight = 12;
            this.Answer22.Items.AddRange(new object[] {
            "Text",
            "Enable",
            "PasswordChar",
            "Visible"});
            this.Answer22.Location = new System.Drawing.Point(292, 126);
            this.Answer22.Name = "Answer22";
            this.Answer22.Size = new System.Drawing.Size(120, 52);
            this.Answer22.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "3、不同于Panel控件的外观，GroupBox具有属性：";
            // 
            // Answer23
            // 
            this.Answer23.FormattingEnabled = true;
            this.Answer23.Items.AddRange(new object[] {
            "Name",
            "Size",
            "Font",
            "Text",
            "TabStop",
            "Visible",
            "BackColor"});
            this.Answer23.Location = new System.Drawing.Point(320, 186);
            this.Answer23.Name = "Answer23";
            this.Answer23.Size = new System.Drawing.Size(121, 20);
            this.Answer23.TabIndex = 10;
            this.Answer23.Text = "请下拉";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "三、多项选择题";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "1、C#的值类型包括：";
            // 
            // Answer3A
            // 
            this.Answer3A.AutoSize = true;
            this.Answer3A.Location = new System.Drawing.Point(193, 261);
            this.Answer3A.Name = "Answer3A";
            this.Answer3A.Size = new System.Drawing.Size(72, 16);
            this.Answer3A.TabIndex = 13;
            this.Answer3A.Text = "简单类型";
            this.Answer3A.UseVisualStyleBackColor = true;
            // 
            // Answer3B
            // 
            this.Answer3B.AutoSize = true;
            this.Answer3B.Location = new System.Drawing.Point(290, 261);
            this.Answer3B.Name = "Answer3B";
            this.Answer3B.Size = new System.Drawing.Size(72, 16);
            this.Answer3B.TabIndex = 13;
            this.Answer3B.Text = "结构类型";
            this.Answer3B.UseVisualStyleBackColor = true;
            // 
            // Answer3C
            // 
            this.Answer3C.AutoSize = true;
            this.Answer3C.Location = new System.Drawing.Point(387, 261);
            this.Answer3C.Name = "Answer3C";
            this.Answer3C.Size = new System.Drawing.Size(72, 16);
            this.Answer3C.TabIndex = 13;
            this.Answer3C.Text = "枚举类型";
            this.Answer3C.UseVisualStyleBackColor = true;
            // 
            // Answer3D
            // 
            this.Answer3D.AutoSize = true;
            this.Answer3D.Location = new System.Drawing.Point(484, 261);
            this.Answer3D.Name = "Answer3D";
            this.Answer3D.Size = new System.Drawing.Size(72, 16);
            this.Answer3D.TabIndex = 13;
            this.Answer3D.Text = "数组类型";
            this.Answer3D.UseVisualStyleBackColor = true;
            // 
            // ExamTime
            // 
            this.ExamTime.Enabled = true;
            this.ExamTime.Interval = 1000;
            this.ExamTime.Tick += new System.EventHandler(this.ExamTime_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(444, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "考试用时(秒)：";
            // 
            // Time
            // 
            this.Time.Location = new System.Drawing.Point(527, 15);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(29, 21);
            this.Time.TabIndex = 15;
            this.Time.Text = "0";
            this.Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(556, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "/120";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(480, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "总得分：";
            // 
            // TotalScore
            // 
            this.TotalScore.Location = new System.Drawing.Point(539, 46);
            this.TotalScore.Name = "TotalScore";
            this.TotalScore.Size = new System.Drawing.Size(42, 21);
            this.TotalScore.TabIndex = 18;
            this.TotalScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGrade
            // 
            this.btnGrade.Location = new System.Drawing.Point(205, 335);
            this.btnGrade.Name = "btnGrade";
            this.btnGrade.Size = new System.Drawing.Size(75, 23);
            this.btnGrade.TabIndex = 19;
            this.btnGrade.Text = "交卷";
            this.btnGrade.UseVisualStyleBackColor = true;
            this.btnGrade.Click += new System.EventHandler(this.btnGrade_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(355, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 120;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Value = 120;
            // 
            // PrimaryExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGrade);
            this.Controls.Add(this.TotalScore);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Answer3D);
            this.Controls.Add(this.Answer3C);
            this.Controls.Add(this.Answer3B);
            this.Controls.Add(this.Answer3A);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Answer23);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Answer22);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Answer21D);
            this.Controls.Add(this.Answer21C);
            this.Controls.Add(this.Answer21B);
            this.Controls.Add(this.Answer21A);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Answer1);
            this.Controls.Add(this.label1);
            this.Name = "PrimaryExamForm";
            this.Text = "初级试题";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrimaryExamForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Answer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Answer21A;
        private System.Windows.Forms.RadioButton Answer21B;
        private System.Windows.Forms.RadioButton Answer21C;
        private System.Windows.Forms.RadioButton Answer21D;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox Answer22;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Answer23;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox Answer3A;
        private System.Windows.Forms.CheckBox Answer3B;
        private System.Windows.Forms.CheckBox Answer3C;
        private System.Windows.Forms.CheckBox Answer3D;
        private System.Windows.Forms.Timer ExamTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TotalScore;
        private System.Windows.Forms.Button btnGrade;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}