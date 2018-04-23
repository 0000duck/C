using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Micro_ECM_V1._0
{
    class WeChatResponse
    {

        //API   https://pushbear.ftqq.com/sub?sendkey={sendkey}&text={text}&desp={desp}t
        //例如：https://pushbear.ftqq.com/sub?sendkey=1141-85e887f237d4b72242273a9a7fc01e39&text=电火花加工实验&desp=测试成功
        public static string requestURL = "https://pushbear.ftqq.com/sub";
        public static string sendkey = "1141-85e887f237d4b72242273a9a7fc01e39";
        //string title;   //发送的标题  text
        //string text;     //发送的文本  decp
        public static System.Net.HttpWebRequest request;  //创建一个HTTP请求
        public static void send(string title, string text)
        {
            requestURL = requestURL + "?sendkey=" + sendkey + "&text=" + title + "&desp=" + text;
            request = (System.Net.HttpWebRequest)WebRequest.Create(requestURL);
        }
    }
}
