namespace Interfaces
{
    public class RealCat : IEat, IMeow, IHaveName
    {
        public string Eat()
        {
            return "num num num num om";
        }

        public string Meow()
        {
            return "Meaaaaw! Mr Mr";
        }

        public string Name { get
        {
            return "Bonifacii";
        }}
    }
}