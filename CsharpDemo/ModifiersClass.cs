using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo
{
    public class ModifiersClass
    {
        protected string ProtectedFunc()
        {
            return "protected function";
        }
        internal string InternalFunc()
        {
            return "internal function";
        }
        protected internal string ProtectedInternalFunc()
        {
            return "protected internal function";
        }
    }
}
