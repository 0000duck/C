using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using PCOMMSERVERLib;

namespace Wechat_Jump
{
    public partial class Form1 : Form
    {
        #region 各种引用
        [DllImport("user32.dll")]//获取窗口句柄
        public static extern IntPtr FindWindow(
        string lpClassName,
        string lpWindowName
        );

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(
        IntPtr hwnd
        );

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(
        IntPtr hdc, // handle to DC
        int nWidth, // width of bitmap, in pixels
        int nHeight // height of bitmap, in pixels
        );

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(
        IntPtr hdc // handle to DC
        );

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(
        IntPtr hdc, // handle to DC
        IntPtr hgdiobj // handle to object
        );

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(
        IntPtr hwnd, // Window to copy,Handle to the window that will be copied. 
        IntPtr hdcBlt, // HDC to print into,Handle to the device context. 
        UInt32 nFlags // Optional flags,Specifies the drawing options. It can be one of the following values. 
        );

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [DllImport("gdi32.dll")]
        public static extern int DeleteDC(
        IntPtr hdc // handle to DC
        );

        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(
        IntPtr hdc
        );

        #endregion

        #region PMAC初始值相关
        public static PCOMMSERVERLib.PmacDeviceClass PMAC;//新建一个PMAC对象
        public bool selectPmacSuccess = false;
        public bool openPmacSuccess = false;
        public static int pmacNumber;        //设备号
        public static bool pmacStatus;       //设备状态标志
        public static string[] motor_1_Info; //1号电机速度位置信息
        public static string[] motor_2_Info; //2号电机速度位置信息
        public static string[] motor_3_Info; //3号电机速度位置信息
        public const int motorX = 1;  //1号电机代表X轴
        public const int motorY = 3;  //3号电机代表Y轴
        public const int motorZ = 2;  //2号电机代表Z轴
        public static int COMM_ERROR = -536870912;  //GetResponseEx函数返回的status如果等于十六进制负值0xE0000000,即十进制-536870912,此时电机状态为无法通讯；
        public sbyte PMAC_Count = 0;
        public bool flag_PMAC_Connect = false;
        //protected conts int x = 0xE0000000;
        public string zeroInfo;
        #endregion
        #region  PMAC相关
        

        private void CommunicateToPMAC()
        {
            PMAC.SelectDevice(0, out pmacNumber, out selectPmacSuccess);  //PMAC状态查询
            if (selectPmacSuccess)
            {
                PMAC.Open(pmacNumber, out openPmacSuccess);
                if (openPmacSuccess)
                {
                    MessageBox.Show("连接成功！");
                    flag_PMAC_Connect = false;
                }
                else
                {
                    MessageBox.Show("通讯失败，重新连接");
                }
            }
            else
            {
                MessageBox.Show("PMAC连接失败，请检查设备电源及连接线！");
            }
        }

        //连续进给  "#*j+"
        private void feed(int motorNum)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#" + motorNum + "j+", out pAnswer);   //开始加工
        }
        //进给相应的位移
        private void feed(int motorNum, string shift)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#" + motorNum + "j:" + shift, out pAnswer);   //进给shift距离
        }
        //使能电机
        public void enableMotor(int motorNum)
        {
            string ZResonse = "";
            int pstatus = 0;
            PMAC.GetResponseEx(pmacNumber, "#" + motorNum + "j/", true, out ZResonse, out pstatus);
        }
        //释放电机
        private void release(int motorNum)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#" + motorNum + "k/", out pAnswer);
        }
        //设置某个变量的值
        public void setVariable(string variable, string value)
        {
            string pResonse = "";
            int pstatus = 0;

            PMAC.GetResponseEx(pmacNumber, variable + "=" + value, true, out pResonse, out pstatus);
        }
        public void setVariable(string info)
        {
            string pResonse = "";
            int pstatus = 0;

            PMAC.GetResponseEx(pmacNumber, info, true, out pResonse, out pstatus);
        }
        //发送command指令
        public string command(string command)
        {
            string pResonse = "";
            int pstatus = 0;

            PMAC.GetResponseEx(pmacNumber, command, true, out pResonse, out pstatus);
            return pResonse;
        }
        #endregion
        private IntPtr hWnd; //获取外部窗口句柄
        Bitmap img; //窗口截图
        public static int width;
        public static int height;
        Rectangle rects;
        public Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            //初始化PMAC相关变量
            PMAC = new PCOMMSERVERLib.PmacDeviceClass();
            pmacNumber = 0;
            pmacStatus = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CommunicateToPMAC();
            hWnd = FindWindow(null, "NEXTBIT-ROBIN (仅限非商业用途)");//得到外部程序的窗口句柄。
            RECT rect;
            GetWindowRect(hWnd, out rect);
            width = rect.Right - rect.Left;
            height = rect.Bottom - rect.Top;           
            this.Width = width + 20;
            this.Height = height + 20;
            img = GetImg(hWnd);
            rects = new Rectangle(0, 0, img.Width, img.Height);
            graphics = this.CreateGraphics();
            btn_change.Visible = false;
            textBox1.Visible = false;
            btn_jump.Visible = false;
            btn_jumpOnce.Visible = false;
            //img.Dispose();
        }
        //初始化，得到截图
        private void drawPic()
        {
            img = GetImg(hWnd);
           // rects = new Rectangle(0, 0, img.Width, img.Height);
            //graphics = this.CreateGraphics();
            graphics.DrawImage(img, rects);
            //img.Dispose();
        }
        private void btn_init_Click(object sender, EventArgs e)
        {
            img = GetImg(hWnd);          
            //rects = new Rectangle(0, 0, img.Width, img.Height);
            //Graphics g1 = this.CreateGraphics();
            graphics.DrawImage(img, rects);
            //img.Dispose();
            img.Dispose();
            textBox1.Visible = true;
            btn_init.Visible = false;
            btn_change.Visible = true;
            
            
        }
        #region 获取截图
        private static Bitmap GetImg(IntPtr hWnds)//得到窗口截图
        {
            IntPtr hscrdc = GetWindowDC(hWnds);
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, width, height);
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnds, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);//删除用过的对象
            DeleteObject(hbitmap);//删除用过的对象
            DeleteDC(hmemdc);//删除用过的对象
            return bmp;
        }
        #endregion

        #region 获取中心点
        int[] result = new int[4];   //找到的两个中心点
        private int[] getBoardCenterValue()
        {
            int halmaXSum = 0;
            int halmaXCount = 0;
            int halmaYMax = 0;
            int boardX = 0;
            int boardY = 0;
            Color color;
            //从截屏从上往下逐行遍历像素点，以棋子颜色作为位置识别的依据，最终取出棋子颜色最低行所有像素点的平均值，即计算出棋子所在的坐标
            for (int y = 200; y < height; y++)
            {
                for (int x = 50; x < width - 50; x++)
                {
                    color = img.GetPixel(x, y);
                    if (color.R > 55 && color.R < 65 && color.G > 55 && color.G < 65 && color.B > 90 && color.R < 105)
                    {
                        halmaXSum += x;
                        halmaXCount++;
                        //棋子底行的Y坐标值  
                        halmaYMax = y > halmaYMax ? y : halmaYMax;
                    }
                }
            }
            int halmaX = 0;  //棋子底行的X坐标值  
            int halmaY = 0;  //棋子底行的Y坐标值  
            if (halmaXSum != 0 && halmaXCount != 0)
            {
                //棋子底行的X坐标值  
                halmaX = halmaXSum / halmaXCount;
                //上移棋子底盘高度的一半  
                halmaY = halmaYMax-5;
                //棋子的X坐标  
                result[0] = halmaX;
                //棋子的Y坐标  
                result[1] = halmaY;
            }

            Boolean flag = false;

            for (int y = 200; y < height; y++)
            {
                color = img.GetPixel(10, y);
                int lastPixelR = color.R;
                int lastPixelG = color.G;
                int lastPixelB = color.B;
                //只要计算出来的boardX的值大于0，就表示下个跳板的中心坐标X值取到了。  
                //if (boardX > 0)
                //{
                //    break;
                //}
                int boardXSum = 0;
                int boardXCount = 0;               
                for (int x = 10; x < width - 10; x++)
                {
                    color = img.GetPixel(x, y);
                    int pixelR = color.R;
                    int pixelG = color.G;
                    int pixelB = color.B;
                    //处理小人头部比下一个跳板还高的情况  
                    //棋子的宽度，从截屏中量取，自行调节
                    if (((y>(halmaY-65)&&y<(halmaY+5)))&&(x > (halmaX - 12) && x < (halmaX + 12)))
                    {
                        continue;
                    }
                    //if (Math.Abs(x - halmaX) < 28)
                    //{
                    //    continue;
                    //}
                    //从上往下逐行扫描至下一个跳板的顶点位置，下个跳板可能为圆形，也可能为方框，取多个点，求平均值  
                    if ((Math.Abs(pixelR - lastPixelR) + Math.Abs(pixelG - lastPixelG) + Math.Abs(pixelB - lastPixelB)) > 30)
                    {
                        flag = true;
                        color = img.GetPixel(x, y+3);
                        pixelR = color.R;
                        pixelG = color.G;
                        pixelB = color.B;
                        Point topPoint = new Point();
                        topPoint.X = x;
                        topPoint.Y = y;
                        int xMin = 0;
                        int xMax = 0;
                        int yEnd = 0;
                        for (int yStart = topPoint.Y; yStart < topPoint.Y + 150; yStart++)
                        {
                            for (int xStart = topPoint.X-75; xStart < topPoint.X + 75; xStart++)
                            {
                                if (xStart <= 10 || yStart <= 10||xStart>width-10||yStart>height-20)
                                    continue;                       
                                color = img.GetPixel(xStart, yStart);
                                if (color.R == pixelR && color.G == pixelG && color.B == pixelB)
                                {
                                    if (xMin > xStart)
                                    {
                                        xMin = xStart;
                                        yEnd = yStart;
                                    }
                                    if (xMax < xStart)
                                    {
                                        xMax = xStart;
                                        yEnd = yStart;
                                    }
                                }

                            }
                        }
                        result[2] = x;
                        result[3] = yEnd;
                        if (Math.Abs(yEnd - y) < 5)
                            yEnd = y + 8;
                        break;
                        //boardXSum += x;
                        //boardXCount++;
                    }
                }
                if (flag)
                    break;
            }
            return result;
        }
        #endregion

        #region mouse_event
        //鼠标事件  因为我用的不多，所以其他参数没有写
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x0002;//模拟鼠标移动
        private readonly int MOUSEEVENTF_MOVE = 0x0001;//模拟鼠标左键按下
        private readonly int MOUSEEVENTF_LEFTUP = 0x0004;//模拟鼠标左键抬起
        private readonly int MOUSEEVENTF_ABSOLUTE = 0x8000;//鼠标绝对位置
        private readonly int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        private readonly int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        private readonly int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        private readonly int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        #endregion
        private void jump(int time)
        {
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, 155 * 65535 / 1920, 495 * 65535 / 1080, 0, 0);//移动到需要点击的位置
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, 155 * 65535 / 1920, 495 * 65535 / 1080, 0, 0);//点击
            Thread.Sleep(time);
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, 155 * 65535 / 1920, 495 * 65535 / 1080, 0, 0);//抬起
        }

        private void jump_PMAC(int time)
        {
            setVariable("P20", time.ToString());
            setVariable("&3b7r");
        }
        private double getDistance()
        {
            double xDistance = Math.Abs((result[0] - result[2]));
            double yDistance = Math.Abs((result[1] - result[3]));
            double angle = Math.Atan(yDistance / xDistance);
            double actualAngle = Math.Atan(Math.Abs(angle - Math.PI/4));
            double distance = Math.Sqrt((Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2)))*Math.Cos(actualAngle);
            return distance;
        }

        double s = 1;
        private void btn_change_Click(object sender, EventArgs e)
        {
            s = double.Parse(textBox1.Text);
            btn_init.Visible = false;
            btn_jump.Visible = true;
            btn_jumpOnce.Visible = true;
        }

        private void btn_jumpOnce_Click(object sender, EventArgs e)
        {
            img = GetImg(hWnd);
            graphics.DrawImage(img, rects);
            getBoardCenterValue();
            img.Dispose();
            Pen pen = new Pen(Color.Red, 2);
            Point[] points = {
                                        new Point(result[0],result[1]),
                                        new Point(result[2],result[3])
                                     };
            //double distance = Math.Sqrt(Math.Pow((result[0] - result[2]), 2) + Math.Pow((result[1] - result[3]), 2));
            double distance = getDistance();
            double time = distance * s;
            jump_PMAC((int)time);
            graphics.DrawLines(pen, points);
            pen.Dispose();
        }

        private void btn_jump_Click(object sender, EventArgs e)
        {
            //mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, 155 * 65535 / 1920, 495 * 65535 / 1080, 0, 0);//移动到需要点击的位置
           // jump_consistent();
            tmr_jump.Enabled = true;
        }
        private void jump_consistent()
        {
            while (true)
            {
                if ((Control.MousePosition.X < 400) && (Control.MousePosition.Y < 700))
                {
                    img = GetImg(hWnd);

                    //rects = new Rectangle(0, 0, img.Width, img.Height);
                    //Graphics g1 = this.CreateGraphics();
                    graphics.DrawImage(img, rects);
                    //img.Dispose();
                    getBoardCenterValue();
                    img.Dispose();
                    Pen pen = new Pen(Color.Red, 2);
                    Point[] points = {
                                        new Point(result[0],result[1]),
                                        new Point(result[2],result[3])
                                     };
                    //double distance = Math.Sqrt(Math.Pow((result[0] - result[2]), 2) + Math.Pow((result[1] - result[3]), 2));
                    double distance = getDistance();
                    double time = distance * s;
                    jump((int)time);
                    graphics.DrawLines(pen, points);
                    Thread.Sleep(1000);
                }
            }
        }

        private void tmr_jump_Tick(object sender, EventArgs e)
        {
                img = GetImg(hWnd);

                //rects = new Rectangle(0, 0, img.Width, img.Height);
                //Graphics g1 = this.CreateGraphics();
                graphics.DrawImage(img, rects);
                //img.Dispose();
                getBoardCenterValue();
                img.Dispose();
                Pen pen = new Pen(Color.Red, 2);
                Point[] points = {
                                        new Point(result[0],result[1]),
                                        new Point(result[2],result[3])
                                     };
                //double distance = Math.Sqrt(Math.Pow((result[0] - result[2]), 2) + Math.Pow((result[1] - result[3]), 2));
                double distance = getDistance();
                double time = distance * s;
                jump_PMAC((int)time);
                graphics.DrawLines(pen, points);
                Thread.Sleep(1000);

        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            tmr_jump.Enabled = false;
        }

    }
}
