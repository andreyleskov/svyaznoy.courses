using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueReferenceEquality
{
    class Program

    {
        class ExampleClass
        {
            public int Value;
            public override bool Equals(object obj)
            {
                return this.Value == ((ExampleClass)obj).Value;
            }
        }

        public struct ExampleStruct
        {
            public int Value;
        }

        static void Main(string[] args)
        {



            int a = 10;
            int b = 10;
            if (a == b)
                Console.WriteLine("a==b");

            ExampleClass exampleA = new ExampleClass();
            exampleA.Value = 10;
            ExampleClass exampleB = new ExampleClass();
            exampleB.Value = 10;

            if(exampleA == exampleB)
               Console.WriteLine("exampleA == exampleB")  ;

            if (exampleA.Equals(exampleB))
                Console.WriteLine("exampleA == exampleB");
 
            //ExampleStruct structA;
            //structA.Value = 10;
            //ExampleStruct structB;
            //structB.Value = 10;

            //if (structA.Equals(structB))
            //    Console.WriteLine("structA == structB");


            Console.ReadKey();

        }

        class Equality
        {
            void Main()
            {
                // Numeric equality: True
                Console.WriteLine((2 + 2) == 4);

                // Reference equality: different objects,  
                // same boxed value: False. 
                object s = 1;
                object t = 1;
                Console.WriteLine(s == t);

                // Define some strings: 
                string a = "hello";
                string b = String.Copy(a);
                string c = "hello";

                // Compare string values of a constant and an instance: True
                Console.WriteLine(a == b);

                // Compare string references;  
                // a is a constant but b is an instance: False.
                Console.WriteLine((object)a == (object)b);

                // Compare string references, both constants  
                // have the same value, so string interning 
                // points to same reference: True.
                Console.WriteLine((object)a == (object)c);
            }
        }
        /*
        Output:
        True
        False
        True
        False
        True
        */
    }
}
