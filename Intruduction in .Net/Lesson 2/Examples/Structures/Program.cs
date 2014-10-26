using System;

namespace ConsoleApplication1
{
    // Создадим структуру
    struct UserInfo
    {
        public string Name;
        public byte Age;

        public UserInfo(string Name, byte Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public void WriteUserInfo()
        {
            Console.WriteLine("Name:{0} Age: {1}", Name, Age);
        }
    }

    class Program
    {
        static void Main()
        {
            UserInfo user1 = new UserInfo("Alexandr", 26);
            Console.Write("user1: ");
            user1.WriteUserInfo();
            UserInfo user2 = new UserInfo("Elena", 22);
            Console.Write("user2: ");
            user2.WriteUserInfo();

            // Показать главное отличие структур от классов
            user1 = user2;
            user2.Name = "Natalya";
            user2.Age = 25;
            Console.Write("\nuser1: ");
            user1.WriteUserInfo();
            Console.Write("user2: ");
            user2.WriteUserInfo();

            Console.ReadLine();
        }
    }
}