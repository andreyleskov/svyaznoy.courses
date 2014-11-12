using System;

namespace Builder
{
    class ValentineProductLabel : ProductLabel
    {
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Happy Valentine day!");
        }
    }
}