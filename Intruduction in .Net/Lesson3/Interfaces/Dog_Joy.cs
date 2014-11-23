namespace Interfaces
{
    public class Dog_Joy : IEat, IBark, IHaveName
    {
        public string Eat()
        {
            return "omnomnom rrrr";
        }

        public string Bark()
        {
            return "Woof! WWoooooorrrf!";
        }

        public string Name 
        {
            get
            {
                return "Joy";
            }
        }
    }
}