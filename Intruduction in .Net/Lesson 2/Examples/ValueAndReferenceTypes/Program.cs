using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    class Program
    {
        class ValueHolder
        {
            public int Value;
        }

        static void Main(string[] args)
        {
            int a = 5;
            Console.WriteLine("internal int changed value = " + ChangeValue(a));
            Console.WriteLine("initial int value  = " + a);

            ValueHolder holder = new ValueHolder();
            holder.Value = 10;

            Console.WriteLine("internal holder changed value = " + ChangeValue(holder));
            Console.WriteLine("initial holder value  = " + holder.Value);
            Console.ReadLine();
        }

        static int ChangeValue(int value)
        {
            value = value + 100;
            return value;
        }

        static int ChangeValue(ValueHolder holder)
        {
            holder.Value = holder.Value + 100;
            return holder.Value;
        }
    }
}
