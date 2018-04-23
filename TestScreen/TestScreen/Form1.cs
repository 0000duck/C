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

namespace TestScreen
{
    public partial class Form1 : Form
    {
        #region 各种引用
        [DllImport("user32.dll")]//获取窗口句柄

        public static extern IntPtr FindWindow(

        string lpClassName,

        string lpWindowName

        );

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

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

        [DllImport("gdi32.dll")]

        public static extern int DeleteDC(

        IntPtr hdc // handle to DC

        );

        [DllImport("gdi32.dll")]
        [DllImport("user32.dll", SetLastError = true)]
             private static extern bool PostMessage(
                 IntPtr hWnd,
                 int Msg,
                 int wParam,
                 int lParam
                 );


        #endregion

        public static extern int DeleteObject(

        IntPtr hdc

        );

        public Form1()
        {
            InitializeComponent();
            
        }

        private static IntPtr hWnd = IntPtr.Zero;

        Bitmap img;
        #region 获取截图
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public static Bitmap GetImg(IntPtr hWnd, int Width, int Height)//得到窗口截图

        {
            IntPtr hscrdc = GetWindowDC(hWnd);

            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, Width, Height);

            IntPtr hmemdc = CreateCompatibleDC(hscrdc);

            SelectObject(hmemdc, hbitmap);

            PrintWindow(hWnd, hmemdc, 0);

            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);

            DeleteDC(hscrdc);//删除用过的对象

            DeleteObject(hbitmap);//删除用过的对象

            DeleteDC(hmemdc);//删除用过的对象

            return bmp;

        }

 //private static string Recognition(string strFileName)//获取扫描信息

 //       {

 //           string strResult = string.Empty;

 //           MODI.Document modiDocument = new MODI.Document();

 //           modiDocument.Create(strFileName);

 //           MODI.Image modiImage = (MODI.Image)modiDocument.Images[0];

 //           modiImage.OCR(MODI.MiLANGUAGES.miLANG_CHINESE_SIMPLIFIED, false, false);//在这里设置要识别的语言的种类。

 //           strResult = modiImage.Layout.Text;

 //           modiDocument.Close(false);

 //           strResult = strResult.Replace(" ", "");

 //           return strResult;

 //       }

        /*
         * //按下鼠标左键  
         * const int WM_LBUTTONDOWN = 0x201;   
         //释放鼠标左键   
        const int WM_LBUTTONUP = 0x202;  
         */

        //按下鼠标左键  
        const int WM_LBUTTONDOWN = 0x201;   
         //释放鼠标左键   
        const int WM_LBUTTONUP = 0x202;

        private void click(double time)
        {
            hWnd = FindWindow(null, "UNKNOWN-GENERIC_A15 (仅限非商业用途)");
            int xClick = 300;
            int yClick = 300;
            IntPtr xParam = (IntPtr)((yClick << 16)|xClick);
            IntPtr yParam = IntPtr.Zero;
            //SendMessage(hWnd, WM_LBUTTONDOWN, 0, 0);
            PostMessage(hWnd, WM_LBUTTONDOWN, 0, 200 + 200 * 65536);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hWnd = FindWindow(null, "UNKNOWN-GENERIC_A15 (仅限非商业用途)");//得到名称为“记事本”的窗口句柄。
            //hWnd = FindWindow(null, "图片查看器");
            
            //img = GetImg((IntPtr)459314, 446, 840);//X,Y为所要获取截图的窗口宽度和高度。
            img = GetImg(hWnd, 416, 827);//X,Y为所要获取截图的窗口宽度和高度。
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
            this.Width = img.Width+20;
            this.Height = img.Height+20;
            Graphics g1 = this.CreateGraphics();
            g1.DrawImage(img, rect);
            int[] center = getBoardCenterValue();
            Pen pen = new Pen(Color.Red, 2);
            Point[] points = {
                                        new Point(result[0],result[1]),
                                        new Point(result[2],result[3])
                                     };
            g1.DrawLines(pen, points);
        }
        #endregion



        //游戏截屏里的两个跳板的中点坐标，主要用来计算角度，可依据实际的截屏计算，计算XY的比例  
    private  int           boardX1                 = 813;  
  
    private  int           boardY1                 = 1122;  
  
    private  int           boardX2                 = 310;  
  
    private  int           boardY2                 = 813;
    int[] result = new int[4];
        /**
         * 获取小人以及下一跳板的中心坐标
         */
        private int[] getBoardCenterValue()
        {
            int width=img.Width;
            int height=img.Height;
            int halmaXSum = 0;
            int halmaXCount = 0;
            int halmaYMax = 0;
            int boardX = 0;
            int boardY = 0;
            //int[] rgb=new int[3];
            Color color;
            //从截屏从上往下逐行遍历像素点，以小人颜色作为位置识别的依据，最终取出小人颜色最低行所有像素点的平均值，即计算出小人所在的坐标
            for (int y = 200; y < height; y++)
            {
                for (int x = 10; x < width-10; x++)
                {
                    color = img.GetPixel(x, y);
                    if (color.R > 50 && color.R < 60 && color.G > 53 && color.G < 63 && color.B > 95 && color.R < 110)
                    {
                        halmaXSum += x;
                        halmaXCount++;
                        //小人底行的Y坐标值  
                        halmaYMax = y > halmaYMax ? y : halmaYMax;
                    }
                }
            }
            if (halmaXSum != 0 && halmaXCount != 0)
            {
                //棋子底行的X坐标值  
                int halmaX = halmaXSum / halmaXCount;
                //上移棋子底盘高度的一半  
                int halmaY = halmaYMax - 10;
                //棋子的X坐标  
                result[0] = halmaX;
                //棋子的Y坐标  
                result[1] = halmaY;
                Boolean flag = false;
                for (int y = 200; y < height ; y++)
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
                    for (int x = 10; x < width-10; x++)
                    {
                        color = img.GetPixel(x, y);
                        int pixelR = color.R;
                        int pixelG = color.G;
                        int pixelB = color.B;
                        //处理小人头部比下一个跳板还高的情况  
                        //棋子的宽度，从截屏中量取，自行调节
                        //if (Math.Abs(x - halmaX) < 28)
                        //{
                        //    continue;
                        //}
                        //从上往下逐行扫描至下一个跳板的顶点位置，下个跳板可能为圆形，也可能为方框，取多个点，求平均值  
                        if ((Math.Abs(pixelR - lastPixelR) + Math.Abs(pixelG - lastPixelG) + Math.Abs(pixelB - lastPixelB)) > 30)
                        {
                            flag = true;
                            result[2] = x;
                            result[3] = y+25;
                            break;
                            //boardXSum += x;
                            //boardXCount++;
                        }
                     }
                    //if (boardXSum > 0)
                    //{
                    //    boardX = boardXSum / boardXCount;
                    //}
                    if (flag)
                        break;
                }
                //按实际的角度来算，找到接近下一个 board 中心的坐标  
                boardY = (int)(halmaY - Math.Abs(boardX - halmaX) * Math.Abs(boardY1 - boardY2)
                        / Math.Abs(boardX1 - boardX2));
                if (boardX > 0 && boardY > 0)
                {
                    
                    //棋子的X坐标  
                    result[0] = halmaX;
                    //棋子的Y坐标  
                    result[1] = halmaY;
                    //下一块跳板的X坐标  
                    //result[2] = boardX;
                    ////下一块跳板的Y坐标  
                    //result[3] = boardY;
                    MessageBox.Show((Math.Sqrt(Math.Pow((result[0]-result[2]),2)+Math.Pow((result[1]-result[3]),2)).ToString()));
                    
                }
            }
                return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click(1000);
        }

    }
}
