using System;

namespace Builder
{
    public class ProductLabel
    {
        public string Name;
        public string Article;
        public decimal Price;
        public string BarCode;
        public decimal Weight;



        public virtual void Show()
        {
            Console.WriteLine("Label:");

            Console.WriteLine("Name = " + Name);
            Console.WriteLine("Article = " + Article);
            Console.WriteLine("BarCode =" + BarCode);

            Console.WriteLine("Price = " + Price);
            Console.WriteLine("Weight = " + Weight);
        }
    }
}