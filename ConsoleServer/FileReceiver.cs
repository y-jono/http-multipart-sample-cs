using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ConsoleApp1
{
    public class FileReceiver
    {
        public void Receive()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://+:8123/");
            listener.Start();
            StreamWriter writer = new StreamWriter(@"Test.txt");
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerResponse res = context.Response;
                switch (context.Request.Url.AbsolutePath)
                {
                    case "/test.cgi":
                        {
                            StreamReader reader = new StreamReader(context.Request.InputStream);
                            string str = reader.ReadToEnd();
                            writer.WriteLine(str);
                            writer.Flush();
                        }
                        break;
                }
                byte[] html = System.Text.Encoding.GetEncoding(932).GetBytes(@"<form action='test.cgi' method='post'><input type='text' name='name'></form>");
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "text/html";
                context.Response.OutputStream.Write(html, 0, html.Length);
                res.Close();
            }
        }
    }
}
