namespace Builder
{
    class LabelDirector
    {
        public void ConstructBeerLabel(IBuilder builder)
        {
            builder.SetPrice(100)
                   .SetName("beer")
                   .SetArticle("12312323sdf")
                    .SetWeight((decimal)0.5);
                  // .Create();

            //var label = new ProductLabel(100, "beer", "234234", 0.5);
        }

        public void ConstructWiskiLabel(IBuilder builder)
        {
            builder.SetPrice(500)
                   .SetName("whiski")
                   .SetArticle("1223423sdf")
                   .SetWeight((decimal)0.7);
        }

        public void ConstructStrict(IBuilder builder)
        {
            var label = builder.StartStrictInit()
                               .SetPrice(0.7)
                               .SetName("123");
                               .Create(); 
        }
    }
}