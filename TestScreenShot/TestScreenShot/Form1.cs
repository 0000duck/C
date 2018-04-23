using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestScreenShot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected Bitmap screenImage;
        protected void ShowForm()
        {
            //if (this.Visible)
            //{
            //    this.Hide();
            //}
            //else
            //{
            Bitmap bkImage = new Bitmap(Screen.AllScreens[0].Bounds.Width/5, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(bkImage);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size, CopyPixelOperation.SourceCopy);
            screenImage = (Bitmap)bkImage.Clone();
            Rectangle rect = new Rectangle(0, 0, bkImage.Width, bkImage.Height);
            Graphics g1 = this.CreateGraphics();
            Image image = screenImage;
            g1.DrawImage(image, rect);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(64, Color.Gray)), Screen.PrimaryScreen.Bounds);
            //this.BackgroundImage = bkImage;

            //this.ShowInTaskbar = false;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Width = Screen.PrimaryScreen.Bounds.Width;
            //this.Height = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = Screen.PrimaryScreen.Bounds.Location;

            //this.WindowState = FormWindowState.Maximized;
            //this.Show();
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowForm();
            //MessageBox.Show(this.ToString());

            //this.lbl_CutImage.SetBounds(this.cutImageRect.Left, this.cutImageRect.Top, this.cutImageRect.Width, this.cutImageRect.Height, BoundsSpecified.All);
            //this.lbl_CutImage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lbl_CutImage.Hide();
            ShowForm();
        }

        #region 截图基本变量
        /// <summary>  
        /// 用于判断是否已经开始截图，控制信息框是否显示。  
        /// </summary>  
        private bool isCuting;
        /// <summary>  
        /// 鼠标按下的点  
        /// </summary>  
        private Point beginPoint;
        /// <summary>  
        /// 最终确定的绘图基点  
        /// </summary>  
        private Point endPoint;
        /// <summary>  
        /// 用于记录截图显示区域的大小（包括调整块的区域，调整区域边框宽度2px）  
        /// </summary>  
        private Rectangle cutImageRect = new Rectangle(0, 0, 300,400);
        #endregion

        /// <summary>  
        /// 截取区域图片的绘制事件处理程序  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void lbl_CutImage_Paint(object sender, PaintEventArgs e)
        {
            int imgWidth = this.lbl_CutImage.Width - 4;
            int imgHeight = this.lbl_CutImage.Height - 4;
            if (imgWidth < 1) { imgWidth = 1; }
            if (imgHeight < 1) { imgHeight = 1; }

            // 创建缓存图像，先将要绘制的内容全部绘制到缓存中，最后再一次性绘制到 Label 上，  
            // 这样可以提高性能，并且可以防止屏幕闪烁的问题  
            Bitmap bmp_lbl = new Bitmap(this.lbl_CutImage.Width, this.lbl_CutImage.Height);
            Graphics g = Graphics.FromImage(bmp_lbl);

            // 将要截取的部分绘制到缓存  
            Rectangle destRect = new Rectangle(2, 2, imgWidth, imgHeight);
            Point srcPoint = this.lbl_CutImage.Location;
            srcPoint.Offset(2, 2);
            Rectangle srcRect = new Rectangle(srcPoint, new System.Drawing.Size(imgWidth, imgHeight));
            g.DrawImage(this.screenImage, destRect, srcRect, GraphicsUnit.Pixel);

            SolidBrush brush = new SolidBrush(Color.FromArgb(10, 124, 202));
            Pen pen = new Pen(brush, 1.0F);

            //以下部分（边框和调整块）的绘制放在（编辑内容）的后面，是解决绘制编辑内容会覆盖（边框和调整块）的问题  

            // 绘制边框外的区域，解决会被编辑内容覆盖的问题  
            // 上边  
            destRect = new Rectangle(0, 0, this.lbl_CutImage.Width, 2);
            srcPoint = this.lbl_CutImage.Location;
            //srcPoint.Offset(2, 2);  
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(this.lbl_CutImage.Width, 2));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 下边  
            destRect = new Rectangle(0, this.lbl_CutImage.Height - 2, this.lbl_CutImage.Width, 2);
            srcPoint = this.lbl_CutImage.Location;
            srcPoint.Offset(0, this.lbl_CutImage.Height - 2);
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(this.lbl_CutImage.Width, 2));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 左边  
            destRect = new Rectangle(0, 2, 2, this.lbl_CutImage.Height - 4);
            srcPoint = this.lbl_CutImage.Location;
            srcPoint.Offset(0, 2);
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(2, this.lbl_CutImage.Height - 4));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 右边  
            destRect = new Rectangle(this.lbl_CutImage.Width - 2, 2, 2, this.lbl_CutImage.Height - 4);
            srcPoint = this.lbl_CutImage.Location;
            srcPoint.Offset(this.lbl_CutImage.Width - 2, 2);
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(2, this.lbl_CutImage.Height - 4));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 绘制边框  
            g.DrawLine(pen, 2, 2, this.lbl_CutImage.Width - 3, 2);
            g.DrawLine(pen, 2, 2, 2, this.lbl_CutImage.Height - 3);
            g.DrawLine(pen, this.lbl_CutImage.Width - 3, 2, this.lbl_CutImage.Width - 3, this.lbl_CutImage.Height - 3);
            g.DrawLine(pen, 2, this.lbl_CutImage.Height - 3, this.lbl_CutImage.Width - 3, this.lbl_CutImage.Height - 3);

            // 绘制四个角的调整块  
            g.FillRectangle(brush, 0, 0, 4, 5);
            g.FillRectangle(brush, this.lbl_CutImage.Width - 4, 0, 4, 5);
            g.FillRectangle(brush, 0, this.lbl_CutImage.Height - 5, 4, 5);
            g.FillRectangle(brush, this.lbl_CutImage.Width - 4, this.lbl_CutImage.Height - 5, 4, 5);

            // 绘制中间的四个调整块  
            int blockX = this.lbl_CutImage.Width / 2 - 2;
            int blockY = this.lbl_CutImage.Height / 2 - 2;
            g.FillRectangle(brush, blockX, 0, 4, 5);
            g.FillRectangle(brush, 0, blockY, 4, 5);
            g.FillRectangle(brush, blockX, this.lbl_CutImage.Height - 5, 4, 5);
            g.FillRectangle(brush, this.lbl_CutImage.Width - 4, blockY, 4, 5);

            // 绘制到 Label 上  
            e.Graphics.DrawImage(bmp_lbl, 0, 0);
            bmp_lbl.Dispose();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 左键单击事件  
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (!this.lbl_CutImage.Visible)
                {
                    this.isCuting = true;
                    this.beginPoint = e.Location;
                    
                   
                }
            }  
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.endPoint = e.Location;
            MessageBox.Show(this.beginPoint.X +"_"+ this.beginPoint.Y+"___"+this.endPoint.X+"_"+this.endPoint.Y);
        }  

        

    }
}
