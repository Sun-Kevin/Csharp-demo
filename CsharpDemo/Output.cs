using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo
{
    public class Output
    {
        public static void Output1(int i, out int j)
        {
            j = i + 1;
        }
        public static void Ref(int i, ref int j)
        {
            j = i + 6;
        }
    
    }
}
