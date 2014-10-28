using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        protected class Animal
        {
            public int bonesNum;
            protected Animal(int bonesNum)
            {
                this.bonesNum = bonesNum;
            }

            public static Animal Leech()
            {
                return new Animal(0);
            }
        }

        protected class Mammal : Animal
        {
            public readonly int Pealogy;
            public Mammal(int pealagy)
                : base(255)
            {
                Pealogy = pealagy;
            }
        }
        protected class Horse : Mammal
        {
            public int StomachSize;

            public Horse(int stomachSize)
                : base(3)
            {
                StomachSize = stomachSize;
            }
        }


        
        static void Main(string[] args)
        {
            Animal horse = new Mammal(100);

            if(horse is Horse)
                Console.WriteLine("yes it is");
            else
                Console.WriteLine("no");


            Horse expected_horse = horse as Horse;

            Console.WriteLine("Our horse has stomach of " + expected_horse.StomachSize
                             + " and its pealogy is " + expected_horse.Pealogy
                             + " and it has " + horse.bonesNum + " bones");

            Animal an = Animal.Leech();
            Console.WriteLine("Animal has " + an.bonesNum + " bones");
            Console.ReadKey();
        }
    }
}
