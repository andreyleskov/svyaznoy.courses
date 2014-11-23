using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle();
            Console.WriteLine("Square is:" + rectangle.Square);
            rectangle.X_size = 5;
            //rectangle.SetXSize(5);// X_size = 5;
            Console.WriteLine("Square is:" + rectangle.Square);
            rectangle.YSize = 10;
            Console.WriteLine("Square is:" + rectangle.Square);
            Console.WriteLine("YSize is:" + (rectangle.YSize = 20));
            Console.ReadKey();
        }
    }

    class GeometryShape
    {
        public double Square { get; protected set; }
    }

    class Rectangle : GeometryShape
    {
        public double X_size { get; set; }


        public double _get__YSize()
        {
            return 0;
        }

        protected double _set_YSize(double value)
        {
            _ySize = value;
            Square = value * X_size;

            return value;
        }

        private double _ySize;        
        public double YSize
        {
            get
            {
                return _ySize;
            }
            set
            {
                _ySize = value;
                Square = value * X_size;
            }
        }
    }
}
