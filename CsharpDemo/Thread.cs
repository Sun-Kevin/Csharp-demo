using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Th = System.Threading.Thread;

namespace CsharpDemo
{
    class Thread
    {
        Dictionary<int, string> d = new Dictionary<int, string>();
        public Thread()
        {
            d.Add(1, "a");
            d.Add(2, "b");
        }
        public void Thread1(Dictionary<int, string> dic)
        {            
            foreach (var d in dic)
            {
                Console.WriteLine("key={0},val={1}", d.Key, d.Value);
            }
        }
        public void Thread1()
        {
            foreach (var dic in d)
            {
                Console.WriteLine("t1 key={0},val={1}", dic.Key, dic.Value);
                Console.WriteLine(Th.GetDomain());
                Th.Sleep(1000);
            }
        }
        public void Thread2()
        {
            foreach (var dic in d)
            {
                Console.WriteLine("t2 key={0},val={1}", dic.Key, dic.Value);
            }
        }
        public void Thread2(Dictionary<int, string> dic)
        {
            foreach (var d in dic)
            {
                Console.WriteLine("key={0},val={1}", d.Key, d.Value);
            }
        }
        public void Thread3()
        {
            
            foreach (var dic in d)
            {
                Console.WriteLine(dic.Key+":"+dic.Value);
            }
        }
    }
}
