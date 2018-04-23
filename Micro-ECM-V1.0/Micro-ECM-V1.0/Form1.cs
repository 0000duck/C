using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using PCOMMSERVERLib;

namespace Micro_ECM_V1._0
{
    public partial class DEMO : Form
    {
        public static PCOMMSERVERLib.PmacDeviceClass PMAC;//新建一个PMAC对象
        public bool selectPmacSuccess = false;
        public bool openPmacSuccess = false;
        public static int pmacNumber;        //设备号
        public static bool pmacStatus;       //设备状态标志

        public static string motorPosition;  //电机位置
        public static string motorVelocity;  //电机速度

        //浮点型正则表达式   ^(-?\d+)(\.\d+)?$
        Regex regexFloat = new Regex(@"^(-?\d+)(\.\d+)?$");
        //整数正则表达式 ^[0-9]*$         ^(\-)?\d+
        Regex regexInt = new Regex(@"^(\-)?\d+$");


        public DEMO()
        {
            InitializeComponent();
            //初始化PMAC相关的变量
            PMAC = new PCOMMSERVERLib.PmacDeviceClass();
            pmacNumber = 0;
            pmacStatus = false;

            tmrMotorStatus.Start();

        }
     
        private void DEMO_Load(object sender, EventArgs e)
        {
            ExitPmac.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            btnStart.Enabled = false;
            btnRelease.Enabled = false;
            btnStop.Enabled = false;
            ttipHelp.SetToolTip(txtSetV, "正值向右运动，负值向左运动");
            ttipHelp.SetToolTip(btnSetV, "请确定设定的速度合适");
            ttipHelp.SetToolTip(txtSetFeed, "输入整数，正值向右运动，负值向左运动");
            ttipHelp.SetToolTip(btnFeed, "整数且没有超量程");
        }


        //与PMAC建立通讯
        private void comunicateTSMI_Click(object sender, EventArgs e)
        {
            PMAC.SelectDevice(0, out pmacNumber, out selectPmacSuccess);
            if (selectPmacSuccess)
            {
                PMAC.Open(pmacNumber, out openPmacSuccess);
                if (openPmacSuccess)
                {
                    labPmacStatus.Text = "PMAC已连接";
                    comunicateTSMI.Enabled = false;
                    ExitPmac.Enabled = true;
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox4.Enabled = true;
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    MessageBox.Show("初始速度可能很高，请记得设定速度！");
                    txtSetV.BackColor = Color.Red;
                }
            }
        }

        //设定进给速度
        private void btnSetV_Click(object sender, EventArgs e)
        {
            string pResonse = "";
            int pstatus = 0;
            //string pAnswer = null;

            string speed=txtSetV.Text.Trim();
            if (regexFloat.IsMatch(speed))
            {
                if(Math.Abs(float.Parse(speed)/1000)<=16.0)
                {
                    PMAC.GetResponseEx(pmacNumber,"I122="+(float.Parse(speed)).ToString(),true,out pResonse,out pstatus);
                    labSetV.Text = speed;
                    btnStart.Enabled = true;
                }
                else
                {
                    MessageBox.Show("输入的速度过大，请重新输入");
                }
            }
            else
            {
                MessageBox.Show("请输入正确的参数");
            }
        }

        //设定进给距离
        private void btnFeed_Click(object sender, EventArgs e)
        {
            string pAnswer = null;
            string feedDistance = txtSetFeed.Text.Trim();            
            if (regexInt.IsMatch(feedDistance))
            {
                PMAC.GetResponse(pmacNumber, "#1j:" + feedDistance, out pAnswer);
                labSetP.Text = feedDistance;
            }
            else
            {
                MessageBox.Show("请输入正确的整数");
            }
            
        }

        /*********************************************************************************************************************************/
        //定时加工
        float workTime=0;        //定时加工时长
        int workCount = 0;       //加工计时
        private void btnSetT_Click(object sender, EventArgs e)
        {
            string pAnswer = null;
            string txtWorkTime = txtSetT.Text.ToString().Trim();
            if (regexFloat.IsMatch(txtWorkTime))
            {
                workCount = 0;                                        //计数初始化
                workTime=float.Parse(txtWorkTime);
                PMAC.GetResponse(pmacNumber, "#1j+", out pAnswer);
                tmrWork.Enabled=true;
                btnSetL.Enabled = false;
                btnSetT.Enabled = true;
            }
            else
            {
                MessageBox.Show("请输入正确的数值");
            }
        }
        private void tmrWork_Tick(object sender, EventArgs e)
        {
            if (workCount >= (workTime * 60))
            {
                string pAnswer = null;
                PMAC.GetResponse(pmacNumber, "#1j/", out pAnswer);   //使能电机
                tmrWork.Enabled = false;                               //定时器失效
                workTime = 0;
                workCount = 0;                                        //计数初始化
                btnSetT.Enabled = true;
                btnSetL.Enabled = true;
                MessageBox.Show("定时加工完成");
            }
            else
            {
                this.ProgressBar.Value = (int)(workCount / (workTime * 60) * 100);    //刷新进度条
                workCount++;
            }


        }
        /*********************************************************************************************************************************/

        /*********************************************************************************************************************************/
        //定长加工
        int workLong = 0;      //设定的加工长度
        float startLocation;   //加工时的初始位置

        private void tmrLong_Tick(object sender, EventArgs e)
        {
            float actualLocation = float.Parse(labReadP.Text);
            float hasWorked = Math.Abs(actualLocation - startLocation);
            if (hasWorked >= Math.Abs(workLong))
            {
                string pAnswer = null;
                PMAC.GetResponse(pmacNumber, "#1j/", out pAnswer);   //使能电机
                tmrLong.Enabled = false;
                workLong = 0;
                btnSetT.Enabled = true;
                btnSetL.Enabled = true;
                this.ProgressBar.Value = 100;
                MessageBox.Show("定点加工已经完成");
                this.ProgressBar.Value = 0;
            }
            else
            {
                this.ProgressBar.Value = (int)Math.Abs(hasWorked / workLong*100);          //刷新进度条
            }
        }
        private void btnSetL_Click(object sender, EventArgs e)
        {
            //中间变量
            int status = 0;
            string motorPosition;       //电机读取到的位置值
            string txtWorkLong = txtSetL.Text.Trim();
            
            if (regexInt.IsMatch(txtWorkLong))
            {
                workLong = int.Parse(txtWorkLong);
                string pAnswer = null;
                PMAC.GetResponse(pmacNumber, "#1j:"+txtWorkLong, out pAnswer);
                PMAC.GetResponseEx(pmacNumber, "#1P", false, out motorPosition, out status);
                if (motorPosition.Length == 0) 
                    startLocation = 0;
                else
                    startLocation = float.Parse(motorPosition);
                btnSetT.Enabled = false;
                btnSetL.Enabled = false;
                tmrLong.Enabled = true;
            }

        }
        /*********************************************************************************************************************************/
        //正常开始加工
        private void btnStart_Click(object sender, EventArgs e)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#1j+", out pAnswer);   //开始加工
            btnStart.Enabled = false;
            btnStart.Text = "正在加工";
            btnRelease.Enabled = true;
            btnSetL.Enabled = false;
            btnSetT.Enabled = false;
            btnFeed.Enabled = false;

        }
        //释放电机
        private void btnRelease_Click(object sender, EventArgs e)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#1k/", out pAnswer);   //开始加工电机
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnStart.Text = "加工";
            btnSetL.Enabled = true;
            btnSetT.Enabled = true;
            btnFeed.Enabled = true;
        }
        //停止/使能电机
        private void btnStop_Click(object sender, EventArgs e)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#1j/", out pAnswer);   //开始加工电机
            btnStart.Enabled = true;
            btnStart.Text = "加工";
            btnSetL.Enabled = true;
            btnSetT.Enabled = true;
            btnFeed.Enabled = true;
        }
        //系统相关信息
        private void 关于系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.Show();
        }
        //断开PMAC
        private void ExitPmac_Click(object sender, EventArgs e)
        {
            if (openPmacSuccess)
            {
                PMAC.Close(pmacNumber);
            }
            labPmacStatus.Text = "PMAC未连接";
            ExitPmac.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            btnStart.Enabled = false;
            btnRelease.Enabled = false;
            btnStop.Enabled = false;
            comunicateTSMI.Enabled = true;
        }

        //去掉速度设定高亮提示
        private void txtSetV_Enter(object sender, EventArgs e)
        {
            txtSetV.BackColor = Color.White;
        }

        //获取电机信息
        /*********************************************************************************************************************************/
        private void getMotorInfo(int motorNum, out string velocity, out string position)
        {
            //中间变量
            int status = 0;
            string motorPosition;       //电机读取到的位置值
            string motorVelocity;       //电机读取到的速度值
            switch (motorNum)
            {
                case 1:   //#1电机
                    PMAC.GetResponseEx(pmacNumber, "#1P", false, out motorPosition, out status);
                    if (motorPosition.Length == 0) 
                        position = "0";
                    else
                        position = (float.Parse(motorPosition)).ToString("f1");
                    PMAC.GetResponseEx(pmacNumber, "#1V", false, out motorVelocity, out status);
                    if (motorVelocity.Length == 0) 
                        velocity = "0";
                    else
                        velocity = (float.Parse(motorVelocity)*8388608/3713991).ToString();
                    break;

                case 2:   //#2电机
                    PMAC.GetResponseEx(pmacNumber, "#2P", false, out motorPosition, out status);
                    if (motorPosition.Length == 0) position = "0";
                    position = motorPosition.ToString();
                    PMAC.GetResponseEx(pmacNumber, "#2V", false, out motorVelocity, out status);
                    if (motorVelocity.Length == 0) velocity = "0";
                    velocity = motorVelocity.ToString();
                    break;
                default:
                    velocity = "0";
                    position = "0";
                    break;
            }
        }

        //定时刷新，实时获取点击信息并显示
        
        private void tmrMotorStatus_Tick(object sender, EventArgs e)
        {
            string motoV;
            int Vstatus;
            getMotorInfo(1, out motorVelocity, out motorPosition);
            labReadV.Text = motorVelocity;
            labReadP.Text = motorPosition;
            PMAC.GetResponseEx(pmacNumber, "I122", false, out motoV, out Vstatus);
            if (motoV.Length == 0)
                labSetV.Text = "未知";
            else
                labSetV.Text =motoV;
        }

        

        /*********************************************************************************************************************************/

        /*********************************************************************************************************************************/
        //API   https://pushbear.ftqq.com/sub?sendkey={sendkey}&text={text}&desp={desp}
        //例如：https://pushbear.ftqq.com/sub?sendkey=1141-85e887f237d4b72242273a9a7fc01e39&text=电火花加工实验&desp=测试成功
        public static string requestURL = "https://pushbear.ftqq.com/sub";
        public static string sendkey = "1141-85e887f237d4b72242273a9a7fc01e39";
        public static string wechatSend(string title, string text)
        {
            string requestURI = null;
            requestURI= requestURL + "?sendkey=" + sendkey + "&text=" + title + "&desp=" + text;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestURI);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "text/html;charset=UTF-8";            

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            string responseContent = streamReader.ReadToEnd();
            httpWebResponse.Close();
            streamReader.Close();
            MessageBox.Show(requestURI);
            return responseContent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(wechatSend("电火花加工系统", "测试成功"));
        }


    }
}
