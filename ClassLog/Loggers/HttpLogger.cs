using ClassLog.Log;
using ClassLog.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace ClassLog.Loggers
{
    internal class HttpLogger : DefaultLogger
    {
        private string Url;

        public HttpLogger(string url)
        {
            Url = url;
        }

        protected override void DoLog(string message)
        {
            try
            {
                // It was used the site http://ptsv2.com/ to generate a http server to do this test, 
                // If you're having troubles to this URL, We recommend you generate a new URL and then
                // change the URL of code below:
                //http://ptsv2.com/t/8erlh-1532184489/post
                
                var request = (HttpWebRequest)WebRequest.Create(Url);
                var data = Encoding.ASCII.GetBytes(message);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
