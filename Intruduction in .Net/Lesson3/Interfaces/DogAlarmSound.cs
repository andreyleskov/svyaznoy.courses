namespace Interfaces
{
    public class DogAlarmSound : IBark,IHaveName
    {
        public string Bark()
        {
            return "Woof! Weef! Woof!";
        }

        public string Name
        {
            get
            {
                return "Alarm, made in China";
            }
        }
    }
}