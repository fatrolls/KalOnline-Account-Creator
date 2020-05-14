using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Drawing;

namespace AccountCreator
{
    public static class Http
    {
        public static bool HttpPostRequest(string URL, string Referer, Dictionary<string, string> Parameters, out string htmlResp, out CookieCollection OUT_cookies, CookieCollection IN_cookies = null, string szProxy = "")
        {
            htmlResp = "";
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            request.Method = "POST";
            request.CookieContainer = new CookieContainer();
            if (IN_cookies != null)
            {
                request.CookieContainer.Add(IN_cookies);
            }

            string postData = "";

            foreach(var pair in Parameters)
            {
                postData += pair.Key + "=";
                postData += pair.Value + "&";
            }

            postData = postData.Substring(0, postData.Length-1);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:24.0) Gecko/20100101 Firefox/24.0";
            if (Referer != "")
                request.Referer = Referer;

            if (szProxy != "") {
                WebProxy proxy = new WebProxy(szProxy);
                request.Proxy = proxy;
            } else {
                request.Proxy = null;
            }

            request.Timeout = 5000;
            request.ContentLength = byteArray.Length;

            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Moved)
                {
                    dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);
                    htmlResp = reader.ReadToEnd();

                    OUT_cookies = response.Cookies;

                    response.Close();
                    reader.Close();
                    dataStream.Close();

                    if (htmlResp.StartsWith("HTTP/1.1 400 Bad Request")) return false;
                    return true;
                }
                else
                {
                    response.Close();
                    OUT_cookies = null;
                    return false;
                }
            }
            catch (Exception e)
            {
                OUT_cookies = null;
                return false;
            }
        }

        public static bool HttpGetRequest(string URL, string Referer, out string response, out CookieCollection OUT_cookies, CookieCollection IN_cookies = null, string szProxy = "")
        {
            response = "";
            HttpWebRequest myHttpWebRequest = HttpWebRequest.Create(URL) as HttpWebRequest;
            myHttpWebRequest.CookieContainer = new CookieContainer();
            if (IN_cookies != null)
            {
                myHttpWebRequest.CookieContainer.Add(IN_cookies);
            }

            myHttpWebRequest.Method = "GET";

            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:24.0) Gecko/20100101 Firefox/24.0";
            if (Referer != "")
                myHttpWebRequest.Referer = Referer;
            myHttpWebRequest.Timeout = 5000;

            if (szProxy != "") {
                WebProxy proxy = new WebProxy(szProxy);
                myHttpWebRequest.Proxy = proxy;
            } else {
                myHttpWebRequest.Proxy = null;
            }

            try
            {
                HttpWebResponse myHttpWebResponse = myHttpWebRequest.GetResponse() as HttpWebResponse;
                if (myHttpWebResponse.StatusCode == HttpStatusCode.OK || myHttpWebResponse.StatusCode == HttpStatusCode.Moved)
                {
                    StreamReader s = new StreamReader(myHttpWebResponse.GetResponseStream());
                    response = s.ReadToEnd();
                    myHttpWebResponse.Close();
                    OUT_cookies = myHttpWebResponse.Cookies;
                    if (response.StartsWith("HTTP/1.1 400 Bad Request")) return false;
                    return true;
                }
                else
                {
                    myHttpWebResponse.Close();
                    OUT_cookies = null;
                    return false;
                }
            }
            catch (Exception e)
            {
                OUT_cookies = null;
                return false;
            }
        }
        
        public static bool HttpGetPictureRequest(string URL, string Referer, out Image Picture, out CookieCollection OUT_cookies, CookieCollection IN_cookies = null, string szProxy = "")
        {
            HttpWebRequest myHttpWebRequest = HttpWebRequest.Create(URL) as HttpWebRequest;
            myHttpWebRequest.CookieContainer = new CookieContainer();
            if (IN_cookies != null)
            {
                myHttpWebRequest.CookieContainer.Add(IN_cookies);
            }

            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:24.0) Gecko/20100101 Firefox/24.0";
            if (Referer != "")
                myHttpWebRequest.Referer = Referer;
            myHttpWebRequest.Timeout = 5000;

            if (szProxy != "") {
                WebProxy proxy = new WebProxy(szProxy);
                myHttpWebRequest.Proxy = proxy;
            } else {
                myHttpWebRequest.Proxy = null;
            }

            try
            {
                HttpWebResponse myHttpWebResponse = myHttpWebRequest.GetResponse() as HttpWebResponse;
                if (myHttpWebResponse.StatusCode == HttpStatusCode.OK || myHttpWebResponse.StatusCode == HttpStatusCode.Moved)
                {
                    Picture = Image.FromStream(myHttpWebResponse.GetResponseStream());

                    myHttpWebResponse.Close();
                    OUT_cookies = myHttpWebResponse.Cookies;
                    return true;
                }
                else
                {
                    myHttpWebResponse.Close();
                    OUT_cookies = null;
                    Picture = null;
                    return false;
                }
            }
            catch (Exception e)
            {
                OUT_cookies = null;
                Picture = null;
                return false;
            }
        }
        
        public static bool HttpGetRequest(string URL, string Referer, out string response, string szProxy = "")
        {
            response = "";
            HttpWebRequest myHttpWebRequest;
            myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);

            myHttpWebRequest.Method = "GET";

            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:24.0) Gecko/20100101 Firefox/24.0";
            if (Referer != "")
                myHttpWebRequest.Referer = Referer;
            myHttpWebRequest.Timeout = 5000;
            
            if (szProxy != "") {
                WebProxy proxy = new WebProxy(szProxy);
                myHttpWebRequest.Proxy = proxy;
            } else {
                myHttpWebRequest.Proxy = null;
            }

            try
            {
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader s = new StreamReader(myHttpWebResponse.GetResponseStream());
                    response = s.ReadToEnd();
                    myHttpWebResponse.Close();
                    if (response.StartsWith("HTTP/1.1 400 Bad Request")) return false;
                    return true;
                }
                else
                {
                    myHttpWebResponse.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool HttpPostRequest(string URL, string Referer, Dictionary<string, string> Parameters, out string htmlResp, string szProxy = "")
        {
            htmlResp = "";
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            request.Method = "POST";

            string postData = "";

            foreach (var pair in Parameters)
            {
                postData += pair.Key + "=";
                postData += pair.Value + "&";
            }

            postData = postData.Substring(0, postData.Length - 1);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:24.0) Gecko/20100101 Firefox/24.0";
            if(Referer != "")
                request.Referer = Referer;
            request.Timeout = 5000;

            if (szProxy != "") {
                WebProxy proxy = new WebProxy(szProxy);
                request.Proxy = proxy;
            } else {
                request.Proxy = null;
            }

            request.ContentLength = byteArray.Length;

            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();

                if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
                {
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    htmlResp = reader.ReadToEnd();

                    response.Close();
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                    if (htmlResp.StartsWith("HTTP/1.1 400 Bad Request")) return false;
                    return true;
                }
                else
                {
                    response.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
