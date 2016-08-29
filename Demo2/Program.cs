using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            new ModifiersClass().Function(); 
        }
    }
    
    class ModifiersClass : CsharpDemo.ModifiersClass
    {
        public void Function()
        {
            base.ProtectedFunc();
            base.ProtectedInternalFunc();
        }
    }
}
