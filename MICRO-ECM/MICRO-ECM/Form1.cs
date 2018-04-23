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
using PCOMMSERVERLib;

namespace MICRO_ECM
{
    public partial class DEMO : Form
    {
        public static PCOMMSERVERLib.PmacDeviceClass PMAC;//新建一个PMAC对象
        public bool communicatePmacSuccess = false;
        public bool openPmacSuccess=false;
        public int pmacNumber;

        //设备位置信息
        public static string position1 = "0", velocity1 = "0";
        public DEMO()
        {
            InitializeComponent();
            PMAC = new PmacDeviceClass();
        }

        private void DEMO_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(setSpeed, "正值向右运动，负值向左运动");
        }

        //与PMAC建立通讯
        private void communicatePmac_Click(object sender, EventArgs e)
        {
            PMAC.SelectDevice(0, out pmacNumber, out communicatePmacSuccess);
            if (communicatePmacSuccess)
            {
                PMAC.Open(pmacNumber, out openPmacSuccess);
                if (openPmacSuccess)
                {
                    PmacStatus.Text = "PMAC已连接";
                    communicatePmac.Enabled = false;
                    ExitPmac.Enabled = true;
                }
            }
        }
        //退出PMAC
        private void ExitPmac_Click(object sender, EventArgs e)
        {
            if (openPmacSuccess)
            {
                PMAC.Close(pmacNumber);
            }
            openPmacSuccess = false;
            PmacStatus.Text = "PMAC未连接";
            communicatePmac.Enabled = true;
            ExitPmac.Enabled = false;
        }

        //加工指令
        float speed;//设定速度变量，浮点型
        private void btnStart_Click(object sender, EventArgs e)
        {
            string pReponse = "";
            int pStatus = 0;
            string answer = null;
            //浮点型正则表达式   ^(-?\d+)(\.\d+)?$
            string speedText = setSpeed.Text.ToString().Trim();
            Regex reg = new Regex(@"^(-?\d+)(\.\d+)?$");
            if (reg.IsMatch(speedText))
            {
                speed = float.Parse(speedText);
                PMAC.GetResponseEx(pmacNumber, "I122=" + speedText, true, out pReponse, out pStatus);
            }
            else
            {
                MessageBox.Show("请输入正确的参数");
            }
            PMAC.GetResponse(pmacNumber, "#1j+", out answer);
        }


        //获取电机信息
        /******************************************************************************************************/

        private void getMotorInfo(int motorNum, out string velocity, out string position)
        {
            //中间变量
            int status = 0;
            string motorPosition;   //电机读取到的位置值
            string motorVelocity;       //电机读取到的速度值
            switch (motorNum)
            {
                case 1:   //#1电机
                    PMAC.GetResponseEx(pmacNumber, "#1P", false, out motorPosition, out status);
                    if (motorPosition.Length == 0) position = "0";
                    position = motorPosition.ToString();
                    PMAC.GetResponseEx(pmacNumber, "#1V", false, out motorVelocity, out status);
                    if (motorVelocity.Length == 0) velocity = "0";
                    velocity = motorVelocity.ToString();
                    break;

                case 2:   //#1电机
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

        /******************************************************************************************************/



        //文本框提示水印
        /******************************************************************************************************/
        Boolean setSpeedHasText = false;
        private void setSpeed_Enter(object sender, EventArgs e)
        {
            if (!setSpeedHasText)
            {
                setSpeed.Text = "";
            }
            setSpeed.ForeColor = Color.Black;

        }

        private void setSpeed_Leave(object sender, EventArgs e)
        {
            if (setSpeed.Text == "")
            {
                setSpeed.Text = "请输入速度值";
                setSpeed.ForeColor = Color.LightGray;
                setSpeedHasText = false;
            }
            else
            {
                setSpeedHasText = true;              
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            getMotorInfo(1, out  velocity1, out  position1);
            speedShow.Text = velocity1;
            positionShow.Text = position1;
        }
        /******************************************************************************************************/


      
    }
}
