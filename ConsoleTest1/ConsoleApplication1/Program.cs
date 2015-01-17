using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using SimpleWebServer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // string str = System.IO.File.ReadAllText(@"C:\Users\nicholas\Desktop\dump.txt");
            // ParseJSON(str);
            // return;

            WebServer ws = new WebServer(SendResponse, "http://*:80/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            if (request.HttpMethod == "GET")
            {
                Console.WriteLine(" - GET");
            }
            else if (request.HttpMethod == "POST")
            {
                Console.WriteLine(" - POST");
                ProcessPost(request);
            }

            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }

        public static void ProcessPost(HttpListenerRequest request)
        {
            Console.WriteLine(" - Content: " + request.ContentType);
            Console.WriteLine(" - Length: " + request.ContentLength64);
            Console.WriteLine(" - Remote: " + request.RemoteEndPoint);
            Console.WriteLine(" - Service: " + request.ServiceName);
            Console.WriteLine(" - Host: " + request.UserHostAddress);
            Console.WriteLine(" - Headers: " + request.Headers.Count);

            System.Collections.Specialized.NameValueCollection coll;
            coll = request.Headers;
            String[] arr1 = coll.AllKeys;

            for (int loop1 = 0; loop1 < arr1.Length; loop1++)
            {
                Console.WriteLine("  - Key: [" + arr1[loop1] + "]");
                // Get all values under this key.
                String[] arr2 = coll.GetValues(arr1[loop1]);
                for (int loop2 = 0; loop2 < arr2.Length; loop2++)
                {
                    Console.WriteLine("   - Value " + loop2 + ": " + arr2[loop2]);
                }
            }
            
            if (request.ContentType == @"application/json")
            {
                byte[] buf = new byte[request.ContentLength64];
                request.InputStream.Read(buf, 0, (int)request.ContentLength64);
                request.InputStream.Close();
                var str = System.Text.Encoding.Default.GetString(buf);
                System.IO.File.WriteAllText(@"C:\Users\nicholas\Desktop\dump.txt", str);
                ParseJSON(str);
            }
        }

        public static void ParseJSON(string str)
        {
            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(str);
            int maxprint = 10;
            foreach (var item in jObject)
            {
                Console.WriteLine(item.ToString());
                if (maxprint-- <= 0) break;
            }
            string name = (string) jObject["ref"];
            Console.WriteLine("ref: " + name);
        }
    }
}

