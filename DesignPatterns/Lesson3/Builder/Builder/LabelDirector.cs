namespace Builder
{
    class LabelDirector
    {
        public void ConstructBeerLabel(IBuilder builder)
        {
            builder.SetPrice(100)
                   .SetName("beer")
                   .SetArticle("12312323sdf")
                   .SetWeight((decimal) 0.5);
        }

        public void ConstructWiskiLabel(IBuilder builder)
        {
            builder.SetPrice(500)
                   .SetName("whiski")
                   .SetArticle("1223423sdf")
                   .SetWeight((decimal)0.7);
        }
    }
}