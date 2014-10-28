using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFunctionsExtended
{
    class Rhomb : Rectangle
    {
        public int diagA;
        public int diagB;
        new public int CalcSquare() { return 10; }
    }

    class Geometry
    {
        public int CalcSquare() { return 0; }
    }
    class Rectangle : Geometry
    {
        public int heigh = 10;
        public int width = 5;
        public int CalcSquare() { return 5; }
    }

    class Square : Rhomb
    {
        public int size;

        public int CalcSquare() { return 15; }

        public override string ToString()
        {
            return "i'm a square";
        }
    }
    class Test
    {
        static void Main()
        {
            int a = 10;
            int b = 5;
            a = b;
            b = 100;

            Rhomb ra = new Square();
            Console.WriteLine(ra.diagA);

            Rhomb sq = ra;
            ra.diagA = 100;

            Console.WriteLine(sq.diagA);

            Console.ReadKey();
        }
    }
}
