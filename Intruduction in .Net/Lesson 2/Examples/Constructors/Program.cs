using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        private class Animal
        {
            public int bonesNum;
            public Animal(int bonesNum)
            {
                this.bonesNum = bonesNum;
            }
        }

        protected class  Mammal : Animal
        {
            public readonly int Pealogy;
            public Mammal(int pealagy):base(255)
	        {
                Pealogy = pealagy;
	        }
        }
        public class Horse : Mammal
        {
            public int StomachSize;

            public Horse(int stomachSize):base(3)
            {
                StomachSize = stomachSize;
            }
        }

        static void Main(string[] args)
        {
            Horse horse = new Horse(11);
            Console.WriteLine("Our horse has stomach of " + horse.StomachSize
                             + " and its pealogy is " + horse.Pealogy
                             + " and it haas " + horse.bonesNum + " bones");

            Console.ReadKey();
        }
    }
}
