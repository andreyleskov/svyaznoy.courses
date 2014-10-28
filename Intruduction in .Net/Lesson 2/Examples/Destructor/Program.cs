using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor
{
    class Program
    {
        static void Main(string[] args)
        {
            new Horse(42);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("after gc.collect");
            Console.ReadKey();
        }
    }

    class Horse
    {
        private int _magicNumber;
        public Horse(int magicNumber)
        {
            _magicNumber = magicNumber;
        }

        ~Horse()
        {
            Console.WriteLine("I'm leaving and this is my magic number: " + _magicNumber);
            Console.ReadKey();
        }
    }
}
