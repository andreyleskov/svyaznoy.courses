using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceAndValueTypes
{
    class ValueHolder
    {
        public int Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 5;
            string val = null;
            TryGetValue(1, ref val);
        }

        static bool TryGetValue( int key, out object value)
        {
            return false;
        }
    }
}
