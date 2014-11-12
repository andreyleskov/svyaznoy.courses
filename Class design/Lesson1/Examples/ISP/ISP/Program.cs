using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    public class Program
    {
        public interface IBird: IFly, ITweet
        {

        }

        class Emu : ITweet
        {
            public void Run()
            {

            }

            public string Tweet()
            {
                return "yaaas";
            }
        }


        class Sparrow : IBird
        {
            public string Fly()
            {
                return "fly away";
            }

            public string Tweet()
            {
                return "chirick";
            }
        }

        static void Main(string[] args)
        {
            var truebirds = new IBird[] { new Sparrow()};
            var allbirds = new IBird[] { new Sparrow()};

            WriteFlyers(truebirds);
            WriteTweeters(allbirds);
            Console.ReadKey();
        }   

        public static void WriteFlyers(IBird[] birds)
        {
            foreach (var bird in birds)
                Console.WriteLine(bird.Fly());
        }

        public static void WriteTweeters(IBird[] birds)
        {
            foreach (var bird in birds)
                Console.WriteLine(bird.Tweet());
        }
    }
}
