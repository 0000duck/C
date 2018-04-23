using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace PushBear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*******************************************************************************************************************
         * API地址 https://pushbear.ftqq.com/sub
         * SendKey 1141-85e887f237d4b72242273a9a7fc01e39
         * API使用 https://pushbear.ftqq.com/sub?sendkey={sendkey}&text={text}&desp={desp}
         * 例如：  https://pushbear.ftqq.com/sub?sendkey=1141-85e887f237d4b72242273a9a7fc01e39&text=HTML测试&desp=测试成功
        *******************************************************************************************************************/

        
        private void btnSend_Click(object sender, EventArgs e)
        {
            string URL="https://pushbear.ftqq.com/sub";
            string SendKey = "1141-85e887f237d4b72242273a9a7fc01e39";
            string title = txtTitle.Text.Trim();
            string text = rtbText.Text.Trim();
            string requestURL = URL + "?sendkey=" + SendKey + "&text=" + title + "&desp=" + text;
            HttpWebRequest request =(HttpWebRequest) WebRequest.Create(requestURL);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            MessageBox.Show(retString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string URL = "https://sc.ftqq.com/SCU6953Tca9ae26df77417e09a1733b92ca8e37658d40a5e53b6b.send";
            string title = txtTitle.Text.Trim();
            string text = rtbText.Text.Trim();
            string requestURL = URL + "?text=" + title + "&desp=" + text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            MessageBox.Show(retString);
        }
    }
}
