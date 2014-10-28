namespace Command
{
    /// <summary>
    ///  "Command" : абстрактная Команда
    /// </summary>
    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }
}