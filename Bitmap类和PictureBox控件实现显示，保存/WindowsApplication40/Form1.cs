using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication40
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.Width / 2, this.Height-100);
            Graphics g = this.CreateGraphics();
            Image image = new Bitmap(@"E:\我的文档\My Pictures\1.jpg");
            g.DrawImage(image, rect);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image image = new Bitmap(@"E:\我的文档\My Pictures\1.jpg");
            image.Save(@"E:\我的文档\My Pictures\11.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("保存成功!新图片名为11.jpg", "恭喜");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = new Bitmap(@"E:\我的文档\My Pictures\1.jpg");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image.Save(@"E:\我的文档\My Pictures\111.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("保存成功!新图片名为111.jpg","恭喜");

             
        }
    }
}