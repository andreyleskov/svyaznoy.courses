namespace Interfaces
{
    public class Cat_Fan : IEat, IMeow , IHaveName
    {
        public string Eat()
        {
            return "num num num";
        }

        public string Meow()
        {
            return "Meaaaaw! i'm like a cat, yeah? ";
        }

        public string Name { get
        {
            return "Andrew";
        }}
    }
}