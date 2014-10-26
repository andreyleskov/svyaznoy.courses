using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceAndValueTypes
{
    class Program
    {
        class ValueHolder
        {
            public int Value;
        }

        static void Main(string[] args)
        {
            int a = 10;
            int b = 5;

            Exchange(ref a,ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);

            ValueHolder holderA = new ValueHolder();
            ValueHolder holderB = new ValueHolder();
            holderA.Value = 10;
            holderB.Value = 5;
            Exchange(holderA,holderB);
            Console.WriteLine(holderA.Value);
            Console.WriteLine(holderB.Value);
            Console.ReadKey();
        }

        static void Exchange(ref int a , ref int b)
        {
            int c;
            c = a;
            a = b;
            b = c;
        }

        static void Exchange(ValueHolder a, ValueHolder b)
        {
            ValueHolder c;
            c = a;
            a = b;
            b = c;
        }
    }
}
