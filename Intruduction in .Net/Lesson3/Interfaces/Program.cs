using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            DogAlarmSound alarm = new DogAlarmSound();
            Dog_Joy realDog = new Dog_Joy();
            RealCat realRealCat = new RealCat();
            Cat_Fan catFan = new Cat_Fan();

            IBark[] barkies = { alarm, realDog };
            IMeow[] meows = { realRealCat, catFan };
            IEat[] eatres = { realDog, realRealCat, catFan };

            Console.WriteLine("Barkies bark for food");

            foreach(IBark barie in barkies)
                Console.WriteLine(barie.Name + ":" + barie.Bark());
            Console.WriteLine();

            Console.WriteLine("Meowies meow for food");
            foreach (IMeow barie in meows)
                Console.WriteLine(barie.Name + ":" + barie.Meow());

            Console.WriteLine();
            Console.WriteLine("There is a lot of food for all!!");
            Console.WriteLine();

            foreach (IEat eater in eatres)
            {
                Console.WriteLine(eater.Name + ":" + eater.Eat());
            }

            Console.ReadKey();
        }
    }
}
