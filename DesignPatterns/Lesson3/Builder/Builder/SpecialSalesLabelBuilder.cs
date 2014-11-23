using System;

namespace Builder
{
    class SpecialSalesLabelBuilder : IBuilder
    {
        private readonly ProductLabel _productLabel;

        public SpecialSalesLabelBuilder(DateTime businessDate)
        {
            _productLabel = businessDate.Day == 1 ? (ProductLabel) new NYSalesProductLabel() : new ValentineProductLabel();
        }
        public IBuilder SetPrice(decimal price)
        {
            _productLabel.Price = (int)(price + 1) + (decimal)0.99;
            return this;
        }

        public IBuilder SetName(string name)
        {
            _productLabel.Name = string.Format("!!!SALES!!! {0} !!!!SALES!!!",name);
            return this;
        }

        public IBuilder SetArticle(string articel)
        {
            _productLabel.Article = articel;
            _productLabel.BarCode = string.Format("holiday{0}sales", articel);
            return this;
        }

        public IBuilder SetWeight(decimal weight)
        {
            _productLabel.Weight = weight;
            return this;
        }

        public ProductLabel GetResult()
        {
            return _productLabel;
        }


        public IPriceSetter StartStrictInit()
        {
            throw new NotImplementedException();
        }
    }
}