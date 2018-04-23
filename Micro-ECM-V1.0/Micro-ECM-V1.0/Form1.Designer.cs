namespace Micro_ECM_V1._0
{
    partial class DEMO
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.comunicateTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitPmac = new System.Windows.Forms.ToolStripMenuItem();
            this.关于系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labSetP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labSetV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFeed = new System.Windows.Forms.Button();
            this.btnSetV = new System.Windows.Forms.Button();
            this.txtSetFeed = new Micro_ECM_V1._0.WatermarkTextBox();
            this.txtSetV = new Micro_ECM_V1._0.WatermarkTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labReadP = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labReadV = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetL = new System.Windows.Forms.Button();
            this.txtSetT = new Micro_ECM_V1._0.WatermarkTextBox();
            this.btnSetT = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSetL = new Micro_ECM_V1._0.WatermarkTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labPmacStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tmrMotorStatus = new System.Windows.Forms.Timer(this.components);
            this.ttipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.tmrWork = new System.Windows.Forms.Timer(this.components);
            this.tmrLong = new System.Windows.Forms.Timer(this.components);
            this.tmrTest = new System.Windows.Forms.Timer(this.components);
            this.labTest = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comunicateTSMI,
            this.ExitPmac,
            this.关于系统ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(429, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // comunicateTSMI
            // 
            this.comunicateTSMI.Name = "comunicateTSMI";
            this.comunicateTSMI.Size = new System.Drawing.Size(79, 21);
            this.comunicateTSMI.Text = "连接PMAC";
            this.comunicateTSMI.Click += new System.EventHandler(this.comunicateTSMI_Click);
            // 
            // ExitPmac
            // 
            this.ExitPmac.Name = "ExitPmac";
            this.ExitPmac.Size = new System.Drawing.Size(79, 21);
            this.ExitPmac.Text = "断开PMAC";
            this.ExitPmac.Click += new System.EventHandler(this.ExitPmac_Click);
            // 
            // 关于系统ToolStripMenuItem
            // 
            this.关于系统ToolStripMenuItem.Name = "关于系统ToolStripMenuItem";
            this.关于系统ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.关于系统ToolStripMenuItem.Text = "关于系统";
            this.关于系统ToolStripMenuItem.Click += new System.EventHandler(this.关于系统ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labSetP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labSetV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "给定参数";
            // 
            // labSetP
            // 
            this.labSetP.AutoSize = true;
            this.labSetP.Location = new System.Drawing.Point(86, 58);
            this.labSetP.Name = "labSetP";
            this.labSetP.Size = new System.Drawing.Size(41, 12);
            this.labSetP.TabIndex = 0;
            this.labSetP.Text = "未设定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "位置(um)：";
            // 
            // labSetV
            // 
            this.labSetV.AutoSize = true;
            this.labSetV.Location = new System.Drawing.Point(86, 28);
            this.labSetV.Name = "labSetV";
            this.labSetV.Size = new System.Drawing.Size(41, 12);
            this.labSetV.TabIndex = 0;
            this.labSetV.Text = "未设定";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "速度(mm/s)：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFeed);
            this.groupBox2.Controls.Add(this.btnSetV);
            this.groupBox2.Controls.Add(this.txtSetFeed);
            this.groupBox2.Controls.Add(this.txtSetV);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(218, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手动设定";
            // 
            // btnFeed
            // 
            this.btnFeed.Location = new System.Drawing.Point(151, 53);
            this.btnFeed.Name = "btnFeed";
            this.btnFeed.Size = new System.Drawing.Size(47, 23);
            this.btnFeed.TabIndex = 3;
            this.btnFeed.Text = "进给";
            this.btnFeed.UseVisualStyleBackColor = true;
            this.btnFeed.Click += new System.EventHandler(this.btnFeed_Click);
            // 
            // btnSetV
            // 
            this.btnSetV.Location = new System.Drawing.Point(151, 23);
            this.btnSetV.Name = "btnSetV";
            this.btnSetV.Size = new System.Drawing.Size(47, 23);
            this.btnSetV.TabIndex = 3;
            this.btnSetV.Text = "设定";
            this.btnSetV.UseVisualStyleBackColor = true;
            this.btnSetV.Click += new System.EventHandler(this.btnSetV_Click);
            // 
            // txtSetFeed
            // 
            this.txtSetFeed.Location = new System.Drawing.Point(68, 54);
            this.txtSetFeed.Name = "txtSetFeed";
            this.txtSetFeed.Size = new System.Drawing.Size(83, 21);
            this.txtSetFeed.TabIndex = 5;
            this.txtSetFeed.WatermarkText = "进给位移(um)";
            // 
            // txtSetV
            // 
            this.txtSetV.Location = new System.Drawing.Point(68, 24);
            this.txtSetV.Name = "txtSetV";
            this.txtSetV.Size = new System.Drawing.Size(83, 21);
            this.txtSetV.TabIndex = 5;
            this.txtSetV.WatermarkText = "进给速度(mm/s)";
            this.txtSetV.Enter += new System.EventHandler(this.txtSetV_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "位移设置：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "速度设置：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labReadP);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.labReadV);
            this.groupBox3.Location = new System.Drawing.Point(12, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "实际参数";
            // 
            // labReadP
            // 
            this.labReadP.AutoSize = true;
            this.labReadP.Location = new System.Drawing.Point(86, 60);
            this.labReadP.Name = "labReadP";
            this.labReadP.Size = new System.Drawing.Size(41, 12);
            this.labReadP.TabIndex = 0;
            this.labReadP.Text = "未读取";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "速度(mm/s)：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "位置(um)：";
            // 
            // labReadV
            // 
            this.labReadV.AutoSize = true;
            this.labReadV.Location = new System.Drawing.Point(86, 30);
            this.labReadV.Name = "labReadV";
            this.labReadV.Size = new System.Drawing.Size(41, 12);
            this.labReadV.TabIndex = 0;
            this.labReadV.Text = "未读取";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSetL);
            this.groupBox4.Controls.Add(this.txtSetT);
            this.groupBox4.Controls.Add(this.btnSetT);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtSetL);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(218, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "定点/定时加工";
            // 
            // btnSetL
            // 
            this.btnSetL.Location = new System.Drawing.Point(151, 56);
            this.btnSetL.Name = "btnSetL";
            this.btnSetL.Size = new System.Drawing.Size(47, 23);
            this.btnSetL.TabIndex = 3;
            this.btnSetL.Text = "定点";
            this.btnSetL.UseVisualStyleBackColor = true;
            this.btnSetL.Click += new System.EventHandler(this.btnSetL_Click);
            // 
            // txtSetT
            // 
            this.txtSetT.Location = new System.Drawing.Point(68, 27);
            this.txtSetT.Name = "txtSetT";
            this.txtSetT.Size = new System.Drawing.Size(83, 21);
            this.txtSetT.TabIndex = 5;
            this.txtSetT.WatermarkText = "定时/分钟(min)";
            // 
            // btnSetT
            // 
            this.btnSetT.Location = new System.Drawing.Point(151, 26);
            this.btnSetT.Name = "btnSetT";
            this.btnSetT.Size = new System.Drawing.Size(47, 23);
            this.btnSetT.TabIndex = 3;
            this.btnSetT.Text = "定时";
            this.btnSetT.UseVisualStyleBackColor = true;
            this.btnSetT.Click += new System.EventHandler(this.btnSetT_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "加工时间：";
            // 
            // txtSetL
            // 
            this.txtSetL.Location = new System.Drawing.Point(68, 57);
            this.txtSetL.Name = "txtSetL";
            this.txtSetL.Size = new System.Drawing.Size(83, 21);
            this.txtSetL.TabIndex = 5;
            this.txtSetL.WatermarkText = "加工长度(um)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "加工长度：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(47, 265);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 51);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(173, 265);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(82, 51);
            this.btnRelease.TabIndex = 2;
            this.btnRelease.Text = "释放";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(299, 265);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(82, 51);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "停止/使能";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labPmacStatus,
            this.ProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 353);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(429, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labPmacStatus
            // 
            this.labPmacStatus.Name = "labPmacStatus";
            this.labPmacStatus.Size = new System.Drawing.Size(79, 17);
            this.labPmacStatus.Text = "PMAC未连接";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tmrMotorStatus
            // 
            this.tmrMotorStatus.Enabled = true;
            this.tmrMotorStatus.Tick += new System.EventHandler(this.tmrMotorStatus_Tick);
            // 
            // ttipHelp
            // 
            this.ttipHelp.AutomaticDelay = 5000;
            this.ttipHelp.AutoPopDelay = 50000;
            this.ttipHelp.InitialDelay = 10;
            this.ttipHelp.ReshowDelay = 1000;
            // 
            // tmrWork
            // 
            this.tmrWork.Interval = 1000;
            this.tmrWork.Tick += new System.EventHandler(this.tmrWork_Tick);
            // 
            // tmrLong
            // 
            this.tmrLong.Interval = 500;
            this.tmrLong.Tick += new System.EventHandler(this.tmrLong_Tick);
            // 
            // labTest
            // 
            this.labTest.AutoSize = true;
            this.labTest.Location = new System.Drawing.Point(198, 363);
            this.labTest.Name = "labTest";
            this.labTest.Size = new System.Drawing.Size(41, 12);
            this.labTest.TabIndex = 5;
            this.labTest.Text = "label6";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DEMO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(429, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labTest);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "DEMO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微细电火花加工系统V1.0";
            this.Load += new System.EventHandler(this.DEMO_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comunicateTSMI;
        private System.Windows.Forms.ToolStripMenuItem ExitPmac;
        private System.Windows.Forms.ToolStripMenuItem 关于系统ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labSetP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labSetV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private WatermarkTextBox txtSetFeed;
        private WatermarkTextBox txtSetV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnFeed;
        private System.Windows.Forms.Button btnSetV;
        private System.Windows.Forms.Label labReadP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labReadV;
        private System.Windows.Forms.Button btnSetL;
        private WatermarkTextBox txtSetT;
        private System.Windows.Forms.Button btnSetT;
        private System.Windows.Forms.Label label9;
        private WatermarkTextBox txtSetL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labPmacStatus;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.Timer tmrMotorStatus;
        private System.Windows.Forms.ToolTip ttipHelp;
        private System.Windows.Forms.Timer tmrWork;
        private System.Windows.Forms.Timer tmrLong;
        private System.Windows.Forms.Timer tmrTest;
        private System.Windows.Forms.Label labTest;
        private System.Windows.Forms.Button button1;
    }
}

