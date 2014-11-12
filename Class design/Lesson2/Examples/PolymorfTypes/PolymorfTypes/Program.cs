using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfTypes
{
    class Program
    {
        class Calculator
        {
            public virtual object Add(object a, object b)
            {
                if(a==null) throw new NullReferenceException("a == null");
                if(b==null) throw new NullReferenceException("a == null");
                return a.ToString() + b.ToString();
            }

        }

        class Callulator<T> : Calculator
        {
            public T Add(T a, T b)
            {
                 Func<object, object, object> adder;
                if (adders.TryGetValue(typeof (T), out adder)) return (T)adder(a, b);
                return (T)base.Add((T)a, (T)b);
            }

            private readonly Dictionary<Type, Func<object, object, object>> adders = new Dictionary
                <Type, Func<object, object, object>>
            {
                {typeof (int), (a, b) => (int) a + (int) b},
                {typeof (decimal), (a, b) => (decimal) a + (decimal) b},
                {typeof (float), (a, b) => (float) a + (float) b},
                {typeof (string), (a, b) => Double.Parse(a.ToString()) + Double.Parse(b.ToString())}
            };

        }
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add("1", "2"));


            var calculator2 = new Callulator<int>();
            Console.WriteLine(calculator2.Add(1, 2));

            Console.WriteLine(calculator2.Add((object)1, (object)2));

            Console.ReadKey();
        }
    }
}
