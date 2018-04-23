public static string GetHttp(string url, HttpContext httpContext)
 2     {
 3         string queryString = "?";
 4 
 5         foreach (string key in httpContext.Request.QueryString.AllKeys)
 6         {
 7             queryString += key + "=" + httpContext.Request.QueryString[key] + "&";
 8         }
 9 
10         queryString = queryString.Substring(0, queryString.Length - 1);
11 
12         HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url + queryString);
13 
14         httpWebRequest.ContentType = "application/json";
15         httpWebRequest.Method = "GET";
16         httpWebRequest.Timeout = 20000;
17 
18         //byte[] btBodys = Encoding.UTF8.GetBytes(body);
19         //httpWebRequest.ContentLength = btBodys.Length;
20         //httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
21 
22         HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
23         StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
24         string responseContent = streamReader.ReadToEnd();
25 
26         httpWebResponse.Close();
27         streamReader.Close();
28 
29         return responseContent;
30     }