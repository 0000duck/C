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

namespace Micro_ECM_V2._0
{

    public partial class DEMO : Form
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
        public bool flag_PMAC_Connect=false ;
        //protected conts int x = 0xE0000000;
        
        //浮点型正则表达式   ^(-?\d+)(\.\d+)?$
        Regex regexFloat = new Regex(@"^(-?\d+)(\.\d+)?$");
        //整数正则表达式 ^[0-9]*$         ^(\-)?\d+
        Regex regexInt = new Regex(@"^(\-)?\d+$");

        public DEMO()
        {
            InitializeComponent();
            //初始化PMAC相关变量
            PMAC = new PCOMMSERVERLib.PmacDeviceClass();
            pmacNumber = 0;
            pmacStatus = false;
        }

        private void DEMO_Load(object sender, EventArgs e)
        {
            DisconnectToPMAC.Enabled = false;
            gBoxSetAndShow.Enabled = false;
            gBoxWork.Enabled = false;
            tmrMotorStatus.Enabled = false;
            ttip.SetToolTip(gBoxSetV, "速度为正值，且小于8");
            ttip.SetToolTip(btnSetV, "速度为正值");
            ttip.SetToolTip(btnHome, "请勿多点");
        }
       

        //连接PMAC
        private void CommunicateToPMAC_Click(object sender, EventArgs e)
        {
            PMAC.SelectDevice(0, out pmacNumber, out selectPmacSuccess);  //PMAC状态查询
            if (selectPmacSuccess)
            {
                PMAC.Open(pmacNumber, out openPmacSuccess);
                if (openPmacSuccess)
                {
                    DisconnectToPMAC.Enabled = true;
                    gBoxSetAndShow.Enabled = true;
                    gBoxWork.Enabled = true;
                    tmrMotorStatus.Enabled = true;
                    flag_PMAC_Connect = false;
                    tssLab.Text = "PMAC已连接";
                    getVelocity();
                    labSetSpeed_X.Text = motorVelocity[0];
                    labSetSpeed_Y.Text = motorVelocity[2];
                    labSetSpeed_Z.Text = (float.Parse(motorVelocity[1])/10).ToString();                   
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

        //关闭PMAC
        private void DisconnectToPMAC_Click(object sender, EventArgs e)
        {
            if (openPmacSuccess)
            {
                tmrMotorStatus.Enabled = false;
                PMAC.Close(pmacNumber);
                DisconnectToPMAC.Enabled = false;
                gBoxSetAndShow.Enabled = false;
                gBoxWork.Enabled = false;
                CommunicateToPMAC.Enabled = true;
            }
        }


        //关于系统
        private void AboutSystem_Click(object sender, EventArgs e)
        {
            SystemInfo systemInfo = new SystemInfo();
            systemInfo.Show();
        }

       
        
        /*****************************************************************************************************************************
        //电机信息 返回一个二维数组，包含速度和位置信息
        private string[] getMotorInfo(int motorNum)
        {
            //中间变量
            int status = 0;
            string motorPosition;       //电机读取到的位置信息
            string motorVelocity;       //电机读取到的速度信息
            string position;            //计算出来的位置信息
            string velocity;            //计算出来的速度信息
            switch (motorNum)
            {
                case 1:   //#1电机
                    PMAC.GetResponseEx(pmacNumber, "#1P", false, out motorPosition, out status);
                    position = (float.Parse(motorPosition)).ToString("f1");
                    PMAC.GetResponseEx(pmacNumber, "#1V", false, out motorVelocity, out status);
                    velocity = (float.Parse(motorVelocity) * 8388608 / 3713991).ToString();
                    break;

                case 2:   //#2电机
                    PMAC.GetResponseEx(pmacNumber, "#2P", false, out motorPosition, out status);
                    position = (float.Parse(motorPosition)).ToString("f1");
                    PMAC.GetResponseEx(pmacNumber, "#2V", false, out motorVelocity, out status);
                    velocity = (float.Parse(motorVelocity) * 8388608 / 3713991).ToString();
                    break;
                case 3:   //#3电机
                    PMAC.GetResponseEx(pmacNumber, "#3P", false, out motorPosition, out status);
                    position = (float.Parse(motorPosition)).ToString("f1");
                    PMAC.GetResponseEx(pmacNumber, "#3V", false, out motorVelocity, out status);
                    velocity = (float.Parse(motorVelocity) * 8388608 / 3713991).ToString();
                    break;
                default:
                    velocity = "0";
                    position = "0";
                    break;
            }
            string[] motorInfo = new string[2]{ velocity, position };
            return motorInfo;           
        }
         *****************************************************************************************************************************/


        //连续进给  "#*j+"
        private void feed(int motorNum)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#"+motorNum+"j+", out pAnswer);   //开始加工
        }
        //进给相应的位移
        private void feed(int motorNum, string shift)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#" + motorNum + "j:"+shift, out pAnswer);   //进给shift距离
        }
        
        //释放电机
        private void release(int motorNum)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#" + motorNum + "k/", out pAnswer);
        }

        //电机回零
        private void getHome(int motorNum)
        {
            string pAnswer = null;
            PMAC.GetResponse(pmacNumber, "#" + motorNum + "HM", out pAnswer);
        }

        //设置电机速度
        private void setVelocity(int motorNum, string velocity)
        {
            string pResonse = "";
            int pstatus = 0;
            
            PMAC.GetResponseEx(pmacNumber, "I"+motorNum+"22=" + velocity, true, out pResonse, out pstatus);
        }
        //读取电机速度
        private string[] motorVelocity=new string[3];
        private void getVelocity()
        {
            int Vstatus;
            PMAC.GetResponseEx(pmacNumber, "I122", false, out motorVelocity[0], out Vstatus);
            PMAC.GetResponseEx(pmacNumber, "I222", false, out motorVelocity[1], out Vstatus);
            PMAC.GetResponseEx(pmacNumber, "I322", false, out motorVelocity[2], out Vstatus);
            for (int i = 0; i < 3; i++)
                if (motorVelocity[i].Length == 0)
                    motorVelocity[i] = "未知";
        }

        //单独得到电机位置信息
        //string lastPosition;
        private string getPosition(int motorNum)
        {
            int status = 0;
            string motorPosition;
            string position;            
            PMAC.GetResponseEx(pmacNumber, "#"+motorNum+"P", false, out motorPosition, out status);
            if (motorPosition.Length == 0)
                position = "0.0";
            else
                position =motorPosition;
            if (status == COMM_ERROR)
            {
                PMAC_Count++;
                position = "0";
            }
            return position;
        }
        //单独得到电机速度信息
        private string getVelocity(int motorNum)
        {
            int status;
            string velocity,motorVelocity;
            PMAC.GetResponseEx(pmacNumber, "#" + motorNum + "V", false, out motorVelocity, out status);
            if (motorVelocity.Length == 0)
                velocity = "未知";
            else
                velocity = (float.Parse(motorVelocity) * 8388608 / 3713991).ToString("f4");
            if (status == COMM_ERROR)
            {
                PMAC_Count++;
                velocity = "0";
            }
            return velocity;
        }
        //得到电机全部信息
        private string[] getMotorInfo(int motorNum)
        {
            getMotorStatus(motorX, out flag_X_Status);
            getMotorStatus(motorY, out flag_Y_Status);
            getMotorStatus(motorZ, out flag_Z_Status);
            string[] motorInfo=new string[2];
            motorInfo[0] = getVelocity(motorNum);
            motorInfo[1] = getPosition(motorNum);
            return motorInfo;
        }

        public bool flag_X_Status = false;
        public bool flag_Y_Status = false;
        public bool flag_Z_Status = false;

        //查询电机使能状态
        public void getMotorStatus(int motorNum,out bool status)
        {
            string ZResonse = "";
            int pstatus = 0;
            PMAC.GetResponseEx(pmacNumber, "M" + motorNum + "39", true, out ZResonse, out pstatus);
            if ("1\n".Equals(ZResonse))
                status = true;
            else
                status = false;
        }

        //使能电机
        public void enableMotor(int motorNum)
        {
            string ZResonse = "";
            int pstatus = 0;
            PMAC.GetResponseEx(pmacNumber, "#" + motorNum + "j/", true, out ZResonse, out pstatus);
        }

        //释放电机
        public void releaseMotor(int motorNum)
        {
            string ZResonse = "";
            int pstatus = 0;
            PMAC.GetResponseEx(pmacNumber, "#" + motorNum + "k/", true, out ZResonse, out pstatus);
        }

        private void tmrMotorStatus_Tick(object sender, EventArgs e)
        {
            if (flag_X_Status)
                btnEnableX.Text = "释放";
            else
                btnEnableX.Text = "使能";

            /*
            if (flag_Z_Status)
                btnEnableZ.Text = "释放";
            else
                btnEnableZ.Text = "使能";    
             */  //暂时不使用
            motor_1_Info = getMotorInfo(1);
            motor_2_Info = getMotorInfo(2);
            motor_3_Info = getMotorInfo(3);
            labReadSpeed_X.Text = motor_1_Info[0];
            labReadPosition_X.Text = (float.Parse(motor_1_Info[1]) / 1000).ToString("f3");
            labRelativePosition_X.Text = (float.Parse(labReadPosition_X.Text) - float.Parse(relativePX)).ToString("f3");
            labReadSpeed_Y.Text = motor_3_Info[0];
            labReadPosition_Y.Text = (float.Parse(motor_3_Info[1]) / 1000).ToString("f3");
            labRelativePosition_Y.Text = (float.Parse(labReadPosition_Y.Text) - float.Parse(relativePY)).ToString("f3");
            labReadSpeed_Z.Text = (float.Parse(motor_2_Info[0]) / 10).ToString("f4");
            labReadPosition_Z.Text = (float.Parse(motor_2_Info[1]) / 10000).ToString("f3");
            labRelativePosition_Z.Text = (float.Parse(labReadPosition_Z.Text) - float.Parse(relativePZ)).ToString("f3");
            if (PMAC_Count > 20)
            {
                PMAC_Count = 0;
                flag_PMAC_Connect = true;
            }
            //if (flag_PMAC_Connect)
            //{
            //    tmrMotorStatus.Enabled = false;
            //    DisconnectToPMAC.Enabled = false;
            //    gBoxSetAndShow.Enabled = false;
            //    gBoxWork.Enabled = false;
            //    CommunicateToPMAC.Enabled = true;

            //}
        }

        //设置速度
        private void btnSetV_Click(object sender, EventArgs e)
        {
            if (chbV_X.Checked)
            {
                string SetSpeedX = txtSetSpeed_X.Text.Trim();
                if (regexFloat.IsMatch(SetSpeedX))
                {
                    if (Math.Abs(float.Parse(SetSpeedX)) <= 8.0)
                    {
                        setVelocity(1, SetSpeedX);
                        labSetSpeed_X.Text = SetSpeedX;
                    }
                    else
                    {
                        MessageBox.Show("速度过大，请调小速度！", "安全提示");
                    }     
                }
                else
                {
                    MessageBox.Show("请输入正确的数值，不要有其他符号！","错误提示");
                }

            }
            if (chbV_Y.Checked)
            {
                string SetSpeedY = txtSetSpeed_Y.Text.Trim();
                if (regexFloat.IsMatch(SetSpeedY))
                {
                    if (Math.Abs(float.Parse(SetSpeedY)) <= 8.0)
                    {
                        setVelocity(3, SetSpeedY);
                        labSetSpeed_Y.Text = SetSpeedY;
                    }
                    else
                    {
                        MessageBox.Show("速度过大，请调小速度！", "安全提示");
                    }
                }
                else
                {
                    MessageBox.Show("请输入正确的数值，不要有其他符号！", "错误提示");
                }

            }
            if (chbV_Z.Checked)
            {
                string SetSpeedZ = txtSetSpeed_Z.Text.Trim();               
                string speedZ=(float.Parse(SetSpeedZ) * 10).ToString();
                if (regexFloat.IsMatch(SetSpeedZ))
                {
                    if (Math.Abs(float.Parse(SetSpeedZ)) <= 8.0)
                    {
                        setVelocity(2, speedZ);
                        labSetSpeed_Z.Text = SetSpeedZ;
                    }
                    else
                    {
                        MessageBox.Show("速度过大，请调小速度！", "安全提示");
                    }
                }
                else
                {
                    MessageBox.Show("请输入正确的数值，不要有其他符号！", "错误提示");
                }

            }
        }
        //Z轴进给
        private void btnFeedZ_Click(object sender, EventArgs e)
        {
            string feedL = txtFeedZ.Text.Trim();
            string feedZ = (float.Parse(feedL) * 10000).ToString();
            if (regexFloat.IsMatch(feedL))
            {
                feed(motorZ, feedZ);
            }
        }

        //Z轴使能/释放
        private void btnEnableZ_Click(object sender, EventArgs e)
        {
            /*
            if (flag_Z_Status)
            {
                //releaseMotor(motorZ);  暂时不使用释放功能
            }
            else
            {
                enableMotor(motorZ);
            }
             */
            enableMotor(motorZ);
        }

        private void btnEnableX_Click(object sender, EventArgs e)
        {
            if (flag_X_Status)
            {
                releaseMotor(motorX);
                this.progressBar.Value = 0;
                tmrLong.Enabled = false;
            }
            else
            {
                enableMotor(motorX);
            }
        }
        //X轴直接进给
        private void btnFeedX_Click(object sender, EventArgs e)
        {
            string feedL = txtFeedX.Text.Trim();            
            if (regexFloat.IsMatch(feedL))
            {
                string feedX = (float.Parse(feedL) * 1000).ToString();
                feed(motorX, feedX);
            }
        }
        //X轴定点加工
        private void btnSetLong_Click(object sender, EventArgs e)
        {
            string feedL = txtSetLong.Text.Trim();
            workLong=float.Parse(feedL)*1000;
            string feedX = workLong.ToString();
            startLocation = float.Parse(getPosition(motorX));
            if (regexFloat.IsMatch(feedL))
            {
                feed(motorX, feedX);
                tmrLong.Enabled = true;
            }
        }

        //定点加工
        float workLong = 0;      //设定的加工长度
        float startLocation;   //加工时的初始位置 
        float actualLocation;  //即时位置信息
        float hasWorked;       //已经加工的长度
        private void tmrLong_Tick(object sender, EventArgs e)
        {
            actualLocation = float.Parse(getPosition(motorX));
            hasWorked = Math.Abs(actualLocation - startLocation);
            if (hasWorked >= Math.Abs(workLong))
            {
                tmrLong.Enabled = false;
                this.progressBar.Value = 100;
                workLong = 0;
                MessageBox.Show("加工完成");
                this.progressBar.Value = 0;
            }
            else
            {
                this.progressBar.Value = (int)Math.Abs(hasWorked / workLong * 100);          //刷新进度条
            }

        }

        //速度清零
        string relativePX = "0";
        string relativePY = "0";
        string relativePZ = "0";
        private void btnClearP_Click(object sender, EventArgs e)
        {
            relativePX = labReadPosition_X.Text;
            relativePY = labReadPosition_Y.Text;
            relativePZ = labReadPosition_Z.Text;            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            getHome(motorZ);
        }

        
        
    }   
}
