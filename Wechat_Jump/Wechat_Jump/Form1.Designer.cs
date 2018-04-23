namespace Wechat_Jump
{
    partial class Form1
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
            this.btn_init = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_jumpOnce = new System.Windows.Forms.Button();
            this.btn_jump = new System.Windows.Forms.Button();
            this.btn_change = new System.Windows.Forms.Button();
            this.tmr_jump = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_init
            // 
            this.btn_init.Location = new System.Drawing.Point(93, 10);
            this.btn_init.Name = "btn_init";
            this.btn_init.Size = new System.Drawing.Size(75, 23);
            this.btn_init.TabIndex = 0;
            this.btn_init.Text = "初始化";
            this.btn_init.UseVisualStyleBackColor = true;
            this.btn_init.Click += new System.EventHandler(this.btn_init_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // btn_jumpOnce
            // 
            this.btn_jumpOnce.Location = new System.Drawing.Point(12, 10);
            this.btn_jumpOnce.Name = "btn_jumpOnce";
            this.btn_jumpOnce.Size = new System.Drawing.Size(75, 23);
            this.btn_jumpOnce.TabIndex = 2;
            this.btn_jumpOnce.Text = "跳一次";
            this.btn_jumpOnce.UseVisualStyleBackColor = true;
            this.btn_jumpOnce.Click += new System.EventHandler(this.btn_jumpOnce_Click);
            // 
            // btn_jump
            // 
            this.btn_jump.Location = new System.Drawing.Point(168, 10);
            this.btn_jump.Name = "btn_jump";
            this.btn_jump.Size = new System.Drawing.Size(75, 23);
            this.btn_jump.TabIndex = 3;
            this.btn_jump.Text = "自动";
            this.btn_jump.UseVisualStyleBackColor = true;
            this.btn_jump.Click += new System.EventHandler(this.btn_jump_Click);
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(118, 39);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(75, 23);
            this.btn_change.TabIndex = 4;
            this.btn_change.Text = "倍率调整";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // tmr_jump
            // 
            this.tmr_jump.Interval = 2500;
            this.tmr_jump.Tick += new System.EventHandler(this.tmr_jump_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 261);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.btn_jump);
            this.Controls.Add(this.btn_jumpOnce);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_init);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_init;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_jumpOnce;
        private System.Windows.Forms.Button btn_jump;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Timer tmr_jump;
    }
}

