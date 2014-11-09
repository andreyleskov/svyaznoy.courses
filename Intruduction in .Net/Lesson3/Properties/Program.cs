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
            Console.WriteLine("Square is:" + rectangle.Square);
            rectangle.YSize = 10;
            Console.WriteLine("Square is:" + rectangle.Square);
            Console.ReadKey();
        }
    }

    class GeometryShape
    {
        public double Square { get; protected set; }
    }

    class Rectangle : GeometryShape
    {
        private double _ySize;        
        public double X_size { get; set; }

        public double YSize
        {
            get
            {
                return _ySize;
            }
            set
            {
                _ySize = value;
                Square = _ySize * X_size;
            }
        }
    }
}
