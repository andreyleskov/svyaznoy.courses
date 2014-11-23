using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{

    class Duck
    {
        public void Run()
        {

        }

        public void Swim()
        {

        }

        public string Criak()
        {
            return "cryaaa";
        }
    }

    class Emu
    {
        public void Run()
        {

        }

        public string Tweet()
        {
            return "yaaas";
        }
    }

    class Sparrow
    {
        public string Fly()
        {
            return "fly away";
        }

        public string Talk()
        {
            return "chirick";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var birdAggregator 
                = new FlyAggregator(new Sparrow(), new Emu());

            birdAggregator.WriteFlyers();
            birdAggregator.WriteTweeters();
            Console.ReadKey();
        }   
    }
}
