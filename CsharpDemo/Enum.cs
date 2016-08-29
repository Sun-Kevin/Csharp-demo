using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo
{
    public class Enum
    {
        public enum Type
        {
            male=1,
            female=2,
            other=3,
            user = 16,
            admin = 1
        }
        Dictionary<int, string> dic = new Dictionary<int, string>();
        public static void dicIterate(Dictionary<int, string> dic)
        {
            
        }
    }
}
