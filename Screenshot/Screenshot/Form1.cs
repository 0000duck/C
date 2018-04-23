using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        private Rectangle cutImageRect = new Rectangle(0, 0, 5, 5);
        #endregion 

        /// <summary>  
        /// 更新UI的模式，用于标记哪些需要显示，哪些需要隐藏；  
        /// </summary>  
        [FlagsAttribute]
        public enum UpdateUIMode : uint
        {
            //值得注意的是，如果要使用组合值，那么就不能用连接的数字表示，必须是几何级增长！  
            None = 0,
            ShowTextPro = 1,
            ShowPenStyle = 2,
            ShowToolBox = 4,
            ShowInfoBox = 8,
            ShowZoomBox = 16,
            ShowCutImage = 32,
            HideTextPro = 64,
            HidePenStyle = 128,
            HideToolBox = 256,
            HideInfoBox = 512
        }

        /// <summary>  
        /// 计算并保存截图的区域框的大小  
        /// </summary>  
        private void SaveCutImageSize(Point beginPoint, Point endPoint)
        {
            // 保存最终的绘图基点，用于截取选中的区域  
            this.endPoint = beginPoint;

            // 计算截取图片的大小  
            int imgWidth = Math.Abs(endPoint.X - beginPoint.X) + 1;
            int imgHeight = Math.Abs(endPoint.Y - beginPoint.Y) + 1;
            int lblWidth = imgWidth + 4;
            int lblHeight = imgHeight + 4;

            // 设置截图区域的位置和大小  
            this.cutImageRect = new Rectangle(beginPoint.X - 2, beginPoint.Y - 2, lblWidth, lblHeight);
        }

        /// <summary>  
        /// 执行截图,将选定区域的图片保存到剪贴板  
        /// </summary>  
        /// <param name="saveToDisk">  
        /// 是否将图片保存到磁盘  
        /// </param>  
        private void ExecCutImage(bool saveToDisk, bool uploadImage) //bool saveToDisk = false, bool uploadImage = false  
        {
            // 如果图片获取区域不可见,则退出保存图片过程  
            if (!this.lbl_CutImage.Visible) { return; }
            Rectangle srcRect = new Rectangle();
            srcRect.X = this.lbl_CutImage.Location.X + 2;
            srcRect.Y = this.lbl_CutImage.Location.Y + 2;
            srcRect.Width = this.lbl_CutImage.Width - 4;
            srcRect.Height = this.lbl_CutImage.Height - 4;
            Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
            Bitmap bmp = new Bitmap(srcRect.Width, srcRect.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(this.screenImage, destRect, srcRect, GraphicsUnit.Pixel);

            Clipboard.SetImage(bmp);

            ExitCutImage(true);
        }
        /// <summary>  
        /// 退出截图过程  
        /// </summary>  
        private void ExitCutImage(bool hideWindow) //  = true  
        {
            this.lbl_CutImage.Visible = false;
            this.isCuting = false;

            if (hideWindow)
            {
                this.screenImage.Dispose();
                this.Hide();
            }
        }


        /// <summary>  
        /// 截图窗口鼠标按下事件处理程序  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 左键单击事件  
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (!this.lbl_CutImage.Visible)
                {
                    this.isCuting = true;
                    this.beginPoint = e.Location;
                    this.endPoint = e.Location;
                    SaveCutImageSize(e.Location, e.Location);

                    UpdateCutInfoLabel(UpdateUIMode.ShowCutImage | UpdateUIMode.ShowInfoBox);
                }
            }
            // 左键双击事件  
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (this.lbl_CutImage.Visible)
                {
                    ExecCutImage(false, false);
                }

            }
            // 右键单击事件  
            if (e.Button == MouseButtons.Right)
            {
                ExitCutImage(!this.lbl_CutImage.Visible);
            }

        }



        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // 如果截取区域不可见,则退出处理过程  
            if (!this.lbl_CutImage.Visible)
            {
                UpdateCutInfoLabel(UpdateUIMode.None);
                return;
            }

            Point pntBgn = this.beginPoint;
            Point pntEnd = e.Location;

            // 如果是反向拖动，重新设置起始点  
            if (e.Location.X < this.beginPoint.X && e.Location.Y < this.beginPoint.Y)
            {
                pntBgn = e.Location;
                pntEnd = this.beginPoint;
            }
            else
            {
                if (e.Location.X < this.beginPoint.X)
                {
                    pntBgn = new Point(e.Location.X, this.beginPoint.Y);
                    pntEnd = new Point(this.beginPoint.X, e.Location.Y);
                }
                else
                {
                    if (e.Location.Y < this.beginPoint.Y)
                    {
                        pntBgn = new Point(this.beginPoint.X, e.Location.Y);
                        pntEnd = new Point(e.Location.X, this.beginPoint.Y);
                    }
                }
            }

            if (this.isCuting)
            {
                SaveCutImageSize(pntBgn, pntEnd);
            }

            UpdateCutInfoLabel(UpdateUIMode.None);
        }


        /// <summary>  
        /// 截图窗口鼠标抬起事件处理程序  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.isCuting)
                {
                    this.isCuting = false;

                    UpdateCutInfoLabel(UpdateUIMode.None);
                }
            }
        }  



        /// <summary>  
        /// 向全局原子表添加一个字符串，并返回这个字符串的唯一标识符（原子ATOM）。  
        /// </summary>  
        /// <param name="lpString">自己设定的一个字符串</param>  
        /// <returns></returns>  
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern Int32 GlobalAddAtom(string lpString);

        /// <summary>  
        /// 注册热键  
        /// </summary>  
        /// <param name="hWnd"></param>  
        /// <param name="id"></param>  
        /// <param name="fsModifiers"></param>  
        /// <param name="vk"></param>  
        /// <returns></returns>  
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        /// <summary>  
        /// 取消热键注册  
        /// </summary>  
        /// <param name="hWnd"></param>  
        /// <param name="id"></param>  
        /// <returns></returns>  
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>  
        /// 热键ID  
        /// </summary>  
        public int hotKeyId = 100;

        /// <summary>  
        /// 热键模式:0=Ctrl + Alt + A, 1=Ctrl + Shift + A  
        /// </summary>  
        public int HotKeyMode = 1;

        /// <summary>  
        /// 控制键的类型  
        /// </summary>  
        public enum KeyModifiers : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        /// <summary>  
        /// 用于保存截取的整个屏幕的图片  
        /// </summary>  
        protected Bitmap screenImage;


        private void Form1_Load(object sender, EventArgs e)
        {
            //隐藏窗口  
            this.Hide();

            //注册快捷键  
            //注：HotKeyId的合法取之范围是0x0000到0xBFFF之间，GlobalAddAtom函数得到的值在0xC000到0xFFFF之间，所以减掉0xC000来满足调用要求。  
            this.hotKeyId = GlobalAddAtom("Screenshot") - 0xC000;
            if (this.hotKeyId == 0)
            {
                //如果获取失败，设定一个默认值；  
                this.hotKeyId = 0xBFFE;
            }

            if (this.HotKeyMode == 0)
            {
                RegisterHotKey(Handle, hotKeyId, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.A);
            }
            else
            {
                RegisterHotKey(Handle, hotKeyId, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.A);
            }
        }

        /// <summary>  
        /// 处理快捷键事件  
        /// </summary>  
        /// <param name="m"></param>  
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == 0x0014)  
            //{  
            //    return; // 禁掉清除背景消息  
            //}  
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ShowForm();
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }


        /// <summary>  
        /// 如果窗口为可见状态，则隐藏窗口；  
        /// 否则则显示窗口  
        /// </summary>  
        protected void ShowForm()
        {
            //if (this.Visible)
            //{
            //    this.Hide();
            //}
            //else
            //{
                Bitmap bkImage = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
                Graphics g = Graphics.FromImage(bkImage);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size, CopyPixelOperation.SourceCopy);
                screenImage = (Bitmap)bkImage.Clone();
                g.FillRectangle(new SolidBrush(Color.FromArgb(64, Color.Gray)), Screen.PrimaryScreen.Bounds);
                this.BackgroundImage = bkImage;

                this.ShowInTaskbar = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                this.Location = Screen.PrimaryScreen.Bounds.Location;

                this.WindowState = FormWindowState.Maximized;
                this.Show();
            //}
        }

        /// <summary>  
        /// 当窗口正在关闭时进行验证  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = false;
                UnregisterHotKey(this.Handle, hotKeyId);
            }
            else
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void lbl_CutImage_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.lbl_CutImage.Hide();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
