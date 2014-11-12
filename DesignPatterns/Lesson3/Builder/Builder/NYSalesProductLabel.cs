using System;

namespace Builder
{
    class NYSalesProductLabel : ProductLabel
    {
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Happy NY! Come again!");
        }
    }
}