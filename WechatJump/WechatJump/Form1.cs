using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCOMMSERVERLib;

namespace WechatJump
{
    public partial class Form1 : Form
    {
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
        double distance = 0;
        double time = 0;

        #region  PMAC相关
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
        }

        private void CommunicateToPMAC(){
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
        protected Bitmap screenImage;
        Boolean startFlag;
        Boolean endFlag;
        private Point startPoint;
        private Point endPoint;

        protected void ShowForm()
        {
            startFlag = false;
            endFlag = false;
            Bitmap bkImage = new Bitmap(Screen.AllScreens[0].Bounds.Width / 5-45, Screen.AllScreens[0].Bounds.Height-300);
            Graphics g = Graphics.FromImage(bkImage);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size, CopyPixelOperation.SourceCopy);
            screenImage = (Bitmap)bkImage.Clone();
            Rectangle rect = new Rectangle(0, 0, bkImage.Width, bkImage.Height);
            this.Width = bkImage.Width ;
            this.Height = bkImage.Height;
            this.btn_init.Visible = false;
            Graphics g1 = this.CreateGraphics();
            Image image = screenImage;
            curBitmap = screenImage;
            K_Means();
            g1.DrawImage(curBitmap, rect);
            startFlag = true;
            endFlag = true;
        }
        
        private void btn_init_Click(object sender, EventArgs e)
        {
            
            ShowForm();
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            if (startFlag && endFlag)
            {
                startPoint = e.Location;
                startFlag = false;
            }
            else if (!startFlag && endFlag)
            {
                endPoint = e.Location;
                endFlag = false;
               // MessageBox.Show(this.startPoint.X + "_" + this.startPoint.Y + "___" + this.endPoint.X + "_" + this.endPoint.Y);
                distance = Math.Sqrt(Math.Pow((startPoint.X - endPoint.X), 2) + Math.Pow((endPoint.Y - startPoint.Y), 2));
                time = distance*10;
                jump(time);
                Thread.Sleep(2000);
                ShowForm();
            }*/
            Point point = e.Location;
            MessageBox.Show(point.X + "_" + point.Y);
            Color color = curBitmap.GetPixel(point.X, point.Y);
            MessageBox.Show(color.R + "_" + color.G + "_" + color.B);
        }
        private void jump(double t)
        {
            setVariable("P20", t.ToString());
            setVariable("&3b7r");
        }

        Bitmap curBitmap;
        //读取图像
        private void openImage()
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|"
                + "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            opnDlg.Title = "打开图像文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                string curFileName = opnDlg.FileName;
                try
                {
                    curBitmap = (Bitmap)Image.FromFile(curFileName);
                    pictureBox1.Image = curBitmap;
                    pictureBox1.Width = this.curBitmap.Width;
                    pictureBox1.Height = this.curBitmap.Height;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            Invalidate();
        }

        private void btn_openImage_Click(object sender, EventArgs e)
        {
            openImage();
            K_Means();
        }
        private void K_Means()
        {
            if (curBitmap != null)
            {
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height;
                byte[] rgbValues = new byte[bytes * 3];
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes * 3);

                byte numbers = 2; //预期聚类数目，需要分几类就是几

                int[] kNum = new int[numbers];
                int[] kAver = new int[numbers * 3];
                int[] kOldAver = new int[numbers * 3];
                int[] kSum = new int[numbers * 3];
                double[] kTemp = new double[numbers];
                byte[] segmentMap = new byte[bytes * 3];
                int[] kkkk = new int[bytes * 3];
                int counts = 0;
                //初始化聚类均值
                for (int i = 0; i < numbers; i++)
                {
                    kAver[i * 3 + 2] = kOldAver[i * 3 + 2] = Convert.ToInt16(i * 255 / (numbers - 1));
                    kAver[i * 3 + 1] = kOldAver[i * 3 + 1] = Convert.ToInt16(i * 255 / (numbers - 1));
                    kAver[i * 3] = kOldAver[i * 3] = Convert.ToInt16(i * 255 / (numbers - 1));
                }
                int count = 0;

                while (true)
                {
                    int order = 0;
                    for (int i = 0; i < numbers; i++)
                    {
                        kNum[i] = 0;
                        kSum[i * 3 + 2] = kSum[i * 3 + 1] = kSum[i * 3] = 0;
                        kAver[i * 3 + 2] = kOldAver[i * 3 + 2];
                        kAver[i * 3 + 1] = kOldAver[i * 3 + 1];
                        kAver[i * 3] = kOldAver[i * 3];
                    }
                    //归属聚类
                    for (int i = 0; i < bytes; i++)
                    {
                        for (int j = 0; j < numbers; j++)
                        {
                            kTemp[j] = Math.Pow(rgbValues[i * 3 + 2] - kAver[j * 3 + 2], 2) + Math.Pow(rgbValues[i * 3 + 1] - kAver[j * 3 + 1], 2) + Math.Pow(rgbValues[i * 3] - kAver[j * 3], 2);
                        }
                        double temp = 100000;

                        for (int j = 0; j < numbers; j++)
                        {
                            if (kTemp[j] < temp)
                            {
                                temp = kTemp[j];
                                order = j;
                            }
                        }
                        kNum[order]++;
                        kSum[order * 3 + 2] += rgbValues[i * 3 + 2];
                        kSum[order * 3 + 1] += rgbValues[i * 3 + 1];
                        kSum[order * 3] += rgbValues[i * 3];
                        segmentMap[i] = Convert.ToByte(order);
                    }
                    for (int i = 0; i < numbers; i++)
                    {
                        if (kNum[i] != 0)
                        {
                            kOldAver[i * 3 + 2] = Convert.ToInt16(kSum[i * 3 + 2] / kNum[i]);
                            kOldAver[i * 3 + 1] = Convert.ToInt16(kSum[i * 3 + 1] / kNum[i]);
                            kOldAver[i * 3] = Convert.ToInt16(kSum[i * 3] / kNum[i]);
                        }
                    }

                    int kkk = 0;
                    count++;
                    for (int i = 0; i < numbers; i++)
                    {
                        if (kAver[i * 3 + 2] == kOldAver[i * 3 + 2] && kAver[i * 3 + 1] == kOldAver[i * 3 + 1] && kAver[i * 3] == kOldAver[i * 3])
                            kkk++;
                    }
                    if (kkk == numbers || count == 100)
                        break;
                }

                for (int i = 0; i < bytes; i++)
                {
                    for (int j = 0; j < numbers; j++)
                    {
                        if (segmentMap[i] == j)
                        {
                            rgbValues[i * 3 + 2] = Convert.ToByte(kAver[j * 3 + 2]);
                            rgbValues[i * 3 + 1] = Convert.ToByte(kAver[j * 3 + 1]);
                            rgbValues[i * 3] = Convert.ToByte(kAver[j * 3]);
                        }
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes * 3);
                curBitmap.UnlockBits(bmpData); 
            }
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            Color color = new Bitmap(pictureBox1.Image).GetPixel(point.X, point.Y);
            MessageBox.Show(color.R + "_" + color.G + "_" + color.B);
        }
    }
}
