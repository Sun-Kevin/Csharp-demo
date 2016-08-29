using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostArticle
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://tieba.baidu.com/p/3483352912";
            var request = HttpWebRequest.Create(url);
            request.Method = "post";
            var response = request.GetResponse();
            using (Stream rs = response.GetResponseStream())
            {
                var sreader = new StreamReader(rs, Encoding.GetEncoding("GB2312"));
                FileStream fs = new FileStream("C:\\Users\\user\\Desktop\\htm.txt", FileMode.OpenOrCreate,FileAccess.ReadWrite);
                var swriter = new StreamWriter(fs, Encoding.GetEncoding("gbk"),1024*1024);
                swriter.Write(sreader.ReadToEnd());
                swriter.Flush();
            }
            
            Console.ReadKey(true);
        }
    }
}
