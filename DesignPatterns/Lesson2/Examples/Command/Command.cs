namespace Command
{
    /// <summary>
    ///  "Command" : ����������� �������
    /// </summary>
    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }
}