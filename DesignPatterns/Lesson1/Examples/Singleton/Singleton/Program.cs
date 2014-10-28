using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using ConsoleApplication1;

namespace Example
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Привет, " + Settings.Instance);
            Console.WriteLine("Ты точно один?, " + Settings.Instance);
            Console.ReadKey();
        }
    }




    
}
