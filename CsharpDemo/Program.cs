#define debug
using System;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Threading;
using System.Dynamic;
using System.Web;
using System.Text;
using System.Collections.Generic;
using CsharpDemo;
using System.Linq;
using System.Threading.Tasks;
//using IronPython.Hosting;
//using IronPython.Runtime;
//using Microsoft.Scripting;
//using Microsoft.Scripting.Hosting;

namespace CsharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //int i = int.Parse(Console.ReadLine());
            //new B().fun();
            //Console.WriteLine(a1);

            //Console.Write(new Discount().Price(22,10));

            /*int i1 = 0;
            int i2 = 1;
            string s = "u";
            new Program().Method(i1);
            new Program().Method(ref i2);
            new Program().Method(ref s);
            Console.WriteLine("i1={0}", i1);
            Console.WriteLine("i2={0}", i2);
            Console.WriteLine("s={0}", s);
            Discount dis = new Discount();
            dis.Method(ref s);
            Console.WriteLine(s);*/

            /*List<int> l = null;
            var e = l.GetEnumerator();//报错，NullReferenceException
            while (e.MoveNext())
            {
                Console.Write(e.Current);
            }*/

            /*Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1,"a");
            dic.Add(2,"b");
            Thread th1 = new Thread();
            System.Threading.Thread t1 = new System.Threading.Thread(new ThreadStart(th1.Thread1));
            System.Threading.Thread t2 = new System.Threading.Thread(new ThreadStart(th1.Thread2));
            t1.Start();
            t2.Start();*/
            /*
            string strXml = "<root><cityName>郑州</cityName><sign>2510688445</sign><postId>206821262</postId><masterId>206821261</masterId><postTitle>Re:正商城的工地连大门都不开，一点都不正规</postTitle><titleurl>http://zzbbs.soufun.com/2510688445~-1/206821261_206821261.htm</titleurl><contenturl>http://zzbbs.soufun.com/2510688445~-1/206821261_206821262.htm#206821262</contenturl><from>正商城</from><fromurl>http://zzbbs.soufun.com/board/2510688445</fromurl></root>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strXml);
            string vv;     
            XmlNodeList   myNodes   =   doc.GetElementsByTagName("Version");  
            vv   =   myNodes[0].InnerText;   
            //修改   
            myNodes[0].InnerText   =   "123455";   
            Console.WriteLine(vv);   
            string myNode   =   doc.SelectNodes("root")[0].InnerText;   
            vv   =   myNodes[0].InnerText;   
            Console.WriteLine(doc.InnerXml);  */
            //再修改   
            //myNodes[0].InnerText  =  "67890";   
            //doc.Save("d:\\text.xml");

            //unsafe
            //{
            //    int i = 1; char s = 's';
            //    int* j = &i;
            //    *j = 2;
            //    Console.WriteLine((int)j);
            //    Console.WriteLine((int)&i);
            //    Console.WriteLine(*j);
            //    Console.WriteLine(i);
            //    char* p = &s;
            //    *p = '2';
            //    Console.WriteLine((int)p);
            //    Console.WriteLine(*p);
            //    Console.WriteLine(s);
            //}
            //Type t = Type.GetType(/*"System.Data.DataTable,System.Data,Version=1.0.3300.0,  Culture=neutral,  PublicKeyToken=b77a5c561934e089"*/"System.Data.DataTable"); Console.Write(t.ToString() ?? "isnull");
            //Activator.CreateInstance(t);
            /*
            List<Students> l = new List<Students>() { new Students { Id = 1, Name = "sk" }, new Students { Id = 2, Name = "zwh" } };
            var list = l.Select(o => { return (dynamic)new { 学号=o.Id,名字=o.Name,性别="male" }; }).ToList();
            foreach (var s in list)
            {
                Console.WriteLine(s.学号 + " " + s.名字 + " " + s.性别);
            }
             */
            //Console.WriteLine( Convert.ToInt32(Convert.ToChar("z")).ToString());
            /*List<Students> l = new List<Students>() { new Students { Id = 1, Name = "sk" }, new Students { Id = 2, Name = "zwh" } };
            var t = l.First().GetType().GetProperties();
            foreach (var e in l)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    Console.WriteLine(t[i].Name + ":" + t[i].GetValue(e));
                }
            }*/

            /*
            var request = HttpWebRequest.Create("http://www.baidu.com");
            var response = request.GetResponse();
            Stream rs = response.GetResponseStream();
            var sreader = new StreamReader(rs);
            Console.WriteLine(sreader.ReadToEnd());*/

            /*
            string s = "北京";
            Byte[] bt = Encoding.GetEncoding("utf-8").GetBytes(s);
            var c = Encoding.GetEncoding("utf-8").GetDecoder();
            
            foreach (var b in bt)
                Console.Write(b);
            Console.Write(Encoding.GetEncoding("gb2312").GetString(bt));
            */

            /*
            string s = "&#12345;";
            Regex regex = new Regex(@"&#(\d{5});", RegexOptions.Compiled);
            var matches = regex.Matches(s);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString());
                foreach (var m in match.Groups)
                {
                    Console.Write(m.ToString() + " ");
                }
            }*/
            /*
            System.Text.Encoding iso8859, gb2312;
            //iso8859   
            iso8859 = System.Text.Encoding.GetEncoding("utf-8");
            //国标2312   
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            byte[] gb;
            gb = gb2312.GetBytes("一二三");
            //返回转换后的字符 
            foreach (var v in gb)
            {
                Console.WriteLine(v);
            }
            var s = iso8859.GetString(gb);
            Console.WriteLine(s); */
            /*
            string s = HttpUtility.UrlEncode(Encrypt("actv_v2_dingsiyan@soufun.com_107", "isso_key"), Encoding.GetEncoding("gbk"));
            Console.WriteLine(s);
            Console.WriteLine(Encrypt("actv_v2_dingsiyan@soufun.com_107", "isso_key"));*/
            /*
            var data = Encoding.GetEncoding("gb2312").GetBytes("sunkai");
            foreach (var d in data)
            {
                Console.WriteLine(d + ":" + ((d & 0xF0) >> 4));
                Console.WriteLine(d & 0xF0);
                Console.WriteLine(d & 0x0F);
                Console.WriteLine();
            }
             */
            /*
            var li = new List<int> { 1, 2, 3, 4, 5 };
            var intA = new int[3] { 1, 2, 3 };
            dynamic d = intA;
            Func<int, bool> F = n => n == 1;
            //intA = intA.AsEnumerable().Where(F).ToArray();
            d = d.Where(F).ToArray();

            foreach (var i in d)
                Console.Write(i);
            */

            //string s = " 120";
            //var sa = s.Split(new char[]{' '}, StringSplitOptions.None);
            //Console.WriteLine(sa.Length);
            //foreach (var i in sa)
            //    Console.WriteLine(i);

            //string s = "<?xml version=\"1.0\" encoding=\"GBK\"?><root><user><s>sunkai</s></user><user>sk</user><u>ks</u></root>";
            //var x = XElement.Parse(s);
            //var xml = new XmlDocument(); xml.LoadXml(s);
            //Console.WriteLine();
            //var n = x.Element("user").NextNode;
            //Console.WriteLine(n.ToString().Contains("<user>"));
            //Expression first = Expression.Constant(1, Type.GetType("int"));

            //            Console.WriteLine("release");
            #endregion
#if debug
            Console.WriteLine("debug");
#else
            Console.WriteLine("publish");            
#endif
            Console.WriteLine();
            #region Demo

            //var l = new List<Students>
            //{
            //    new Students{Id=1,Name="a",Sex="m"},
            //    new Students{Id=2,Name="b",Sex="f"},
            //    new Students{Id=3,Name="a",Sex="m"},
            //    new Students{Id=4,Name="a",Sex="f"}
            //};
            //string pattern = "^[\\d]+$";
            //var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            //Console.WriteLine(reg.IsMatch("111"));
            //Students[] stus = new Students[] { new Students { Name = "sunkai", Id = 1, stu=new Students {Sex="f" } },
            //    new Students { Name = "xiang", Id = 2, stu=new Students {Sex="m" } } };
            //Students[] stuarra = new Students[2];
            //stuarra = (Students[])stus.Clone();
            //stuarra[0].stu.Sex = "girl";
            //string s = "delegate";
            //Func<object, object> act = (obj) => { Console.WriteLine(obj); return $"return{obj}"; };
            //Action<object> a = delegate (object st) { };
            //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(a), s);
            //System.Threading.Thread t = new System.Threading.Thread((o) => Console.WriteLine("thread"));
            //t.Start();
            //Task.Delay(1000);
            //var arr = s.ToCharArray();
            //string sf = string.Empty;
            //var e = arr.GetEnumerator();
            //while (e.MoveNext())
            //    sf += $"'{e.Current}'";//C#6新特性，字符串内插
            //Console.WriteLine(sf);

            //var stu = Student.instance();
            //Console.WriteLine($"id={stu.Id},name={stu.Name},sex={stu.Sex}");
            //stu = null;
            //GC.Collect();
            


            #endregion
            Console.ReadKey(true);
        }

        static void fun(dynamic s)
        {
            Console.WriteLine(nameof(s));
            Console.WriteLine(s.str);
        }
        //Async methods cannot have ref or out parameters	
        async static Task<T> asyncF<T>()
        {
            var url = "http://tieba.baidu.com/p/3483352912";
            int len;
            var type = typeof(T);
            using (HttpClient client = new HttpClient())
            {
                //var html = await client.GetStringAsync(url);
                var html = client.GetStringAsync(url);
                len = (await html).Length;
            }
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("sleep over");
            return (T)Convert.ChangeType(len, type);
        }
        async static Task<int> asyncF()
        {
            var url = "http://tieba.baidu.com/p/3483352912";
            int len;
            using (HttpClient client = new HttpClient())
            {
                //var html = await client.GetStringAsync(url);
                var html = client.GetStringAsync(url);
                len = (await html).Length;
            }
            return len;
        }

        interface IMyInter<in T> { }

        static char b;
        //unsafe static void uns(char a)
        //{
        //    fixed (char* c = &b)
        //    {
        //        Console.Write(*c);
        //    }
        //}
        static void Fun(int? i = 8, int? j = 7)
        {
            Console.Write(i * j);
        }
        void Method(int i)
        {
            i = 10;
        }
        static void Method(ref int i)
        {
            i = 11;
        }
        static void Method(ref string s)
        {
            s = "ref";
        }
        void SecondLarge(params int[] array)
        {
            int index = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[index])
                {
                    index = i;
                }
            }
            int temp;
            if (index < array.Length)
            {
                temp = array[index];
                array[index] = array[array.Length - 1];
                array[array.Length - 1] = temp;
            }
            index = 0;
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[index])
                {
                    index = i;
                }
            }
            Console.Write(array[index]);
        }
    }
    class Discount
    {

        public void Method(ref string str)
        {
            str = "ref";
        }

        public static decimal Price(int days, int price, int @string)
        {
            decimal counts = System.Math.Ceiling((decimal)100 / price);
            decimal totalPrice = 0;
            if (days > counts)
            {
                int i;
                totalPrice += (price * counts);
                for (i = (int)counts + 1; i <= days; i++)
                {
                    totalPrice += (decimal)(price * 0.8);
                    if (totalPrice > 150)
                    {
                        break;
                    }
                }
                for (int j = i + 1; j <= days; j++)
                {
                    totalPrice += (decimal)(price * 0.5);
                }
            }
            else
            {
                totalPrice = price * days;
            }
            return totalPrice;
        }
    }
    public class A
    {
        public int A1 { get; set; }
        public A()
        {
            A1 = 1;
        }
        public A(int i) { A1 = i; }
        public virtual void print()
        {
            Console.WriteLine("A");
        }
    }
    public class B : A
    {
        public int B1 { get; set; }
        public B()
        //: base()
        {
            B1 = base.A1;
        }
        public B(int i) : base(i) { B1 = base.A1; }
        internal void fun()
        {
            B1 = base.A1;
            Console.WriteLine(B1);
        }
        public new void print()
        {
            Console.WriteLine("B");
        }
    }
    partial class PartialClass1
    {
        static void Fun2() { Func1(); }
    }
}
