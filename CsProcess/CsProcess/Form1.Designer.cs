namespace CsProcess
{
    partial class MianForm
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
            this.btnStar1 = new System.Windows.Forms.Button();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.SuspendLayout();
            // 
            // btnStar1
            // 
            this.btnStar1.Location = new System.Drawing.Point(83, 38);
            this.btnStar1.Name = "btnStar1";
            this.btnStar1.Size = new System.Drawing.Size(119, 23);
            this.btnStar1.TabIndex = 0;
            this.btnStar1.Text = "启动计算器(方法1)";
            this.btnStar1.UseVisualStyleBackColor = true;
            this.btnStar1.Click += new System.EventHandler(this.btnStar1_Click);
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(83, 85);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(119, 23);
            this.btnStart2.TabIndex = 0;
            this.btnStart2.Text = "启动计算器(方法2)";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Location = new System.Drawing.Point(83, 132);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(119, 23);
            this.btnCloseAll.TabIndex = 0;
            this.btnCloseAll.Text = "关闭全部计算器";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.FileName = "C:\\Windows\\System32\\calc.exe";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // MianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.btnStart2);
            this.Controls.Add(this.btnStar1);
            this.Name = "MianForm";
            this.Text = "启动计算器";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStar1;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Diagnostics.Process process1;
    }
}

