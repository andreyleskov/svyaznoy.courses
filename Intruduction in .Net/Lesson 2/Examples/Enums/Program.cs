using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public enum Gender:int
    {
        Male=10,
        Female=5,
        NotAvailable=-1
    }

    class Person
    {
        public readonly Gender Gender;
        public Person(Gender gender)
        {
            Gender = gender;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person man = new Person(Gender.Male);
            Person female = new Person(Gender.Female);
            Person alien = new Person((Gender)(-1));

            Console.WriteLine(man.Gender);
            Console.WriteLine(female.Gender);
            Console.WriteLine(alien.Gender);

            Console.WriteLine((int)man.Gender);
            Console.WriteLine((int)female.Gender);
            Console.WriteLine((int)alien.Gender);

            Console.ReadKey();
        }
    }
}
