using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

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


    class Settings
    {
        public static readonly Settings Instance = new Settings();
        private Settings()
        {
            
        }

        public override string ToString()
        {
            return "Singleton hash: " + this.GetHashCode();
        }
    }
}
