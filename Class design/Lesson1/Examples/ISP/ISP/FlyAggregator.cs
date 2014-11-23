using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISP
{
    class FlyAggregator
    {
        private Sparrow _spr;
        private Emu _em;
        private Duck _dck;

        public FlyAggregator(Sparrow spr, Emu em, Duck dck)
        {
            _spr = spr;
            _em = em;
            _dck = dck;
        }

        public void WriteFlyers()
        {
            Console.WriteLine(_spr.Fly());
        }

        public  void WriteTweeters()
        {
            Console.WriteLine(_em.Tweet());
            Console.WriteLine(_dck.Criak());
            Console.WriteLine(_spr.Talk());
        }
    }
}
