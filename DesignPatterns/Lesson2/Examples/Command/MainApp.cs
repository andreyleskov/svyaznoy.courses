using System;

namespace Command
{
    class MainApp
    {
        static void Main()
        {
            // Создаем пользователя.
            User user = new User();

            // Пусть он что-нибудь сделает.
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Отменяем 4 команды
            user.Undo(4);

            // Вернём 3 отменённые команды.
            user.Redo(3);

            // Ждем ввода пользователя и завершаемся.
            Console.Read();
        }
    }
}

