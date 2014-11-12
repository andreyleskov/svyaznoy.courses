using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var swuare = GetRectangle();
            swuare.Height = 4;
            swuare.Width = 5;
            int square = swuare.Square();

            if(square == 20)
            Console.WriteLine("OK");
            else
            Console.WriteLine("No");

            Console.ReadKey();
        }

        static Rectangle GetRectangle()
        {
            return new Square();
        }

        public class Square: Rectangle
        {
            public override int Height
            {
                get
                {
                    return base.Height;
                }
                set
                {
                    base.Height = value;
                    base.Width = value;
                }
            }
            public override int Width
            {
                get
                {
                    return base.Width;
                }
                set
                {
                    base.Height = value;
                    base.Width = value;
                }
            }


        }

        public class Rectangle
        {
            public virtual int Height{get;set;}
            public virtual int Width{get;set;}

            public int Square()
            {
                return Height * Width;
            }
        }
    }
}
