namespace Builder
{
    class CommonLabelBuilder : IBuilder
    {
        private readonly ProductLabel _productLabel = new ProductLabel();


        public IBuilder SetPrice(decimal price)
        {
            _productLabel.Price = price;
            return this;
        }

        public IBuilder SetName(string name)
        {
            _productLabel.Name = name;
            return this;
        }

        public IBuilder SetArticle(string articel)
        {
            _productLabel.Article = articel;
            _productLabel.BarCode = string.Format("bbb{0}ccdd",articel);
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
    }
}