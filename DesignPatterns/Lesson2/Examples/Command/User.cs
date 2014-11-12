namespace Command
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// "Invoker" : вызывающий
    /// </summary>

    class User
    {
        // Initializers
        private readonly Calculator _calculator = new Calculator();
        private readonly List<Command> _commands = new List<Command>();

        private int _current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);

            // Делаем возврат операций
            for (int i = 0; i < levels; i++)
                if (this._current < this._commands.Count - 1)
                    this._commands[this._current++].Execute();
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);

            // Делаем отмену операций
            for (int i = 0; i < levels; i++)
                if (this._current > 0)
                    this._commands[--this._current].UnExecute();
        }

        public void Compute(char @operator, int operand)
        {

            // Создаем команду операции и выполняем её
            Command command = new CalculatorCommand(this._calculator, @operator, operand);
            command.Execute();

            if (this._current < this._commands.Count)
            {
                // если "внутри undo" мы запускаем новую операцию, 
                // надо обрубать список команд, следующих после текущей, 
                // иначе undo/redo будут некорректны
                this._commands.RemoveRange(this._current, this._commands.Count - this._current);
            }

            // Добавляем операцию к списку отмены
            this._commands.Add(command);
            this._current++;
        }
    }
}