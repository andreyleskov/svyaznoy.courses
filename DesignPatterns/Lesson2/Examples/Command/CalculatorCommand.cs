namespace Command
{
    /// <summary>
    /// "ConcreteCommand" : конкретная команда
    /// </summary>
 

    class CalculatorCommand : Command
    {
        char @operator;
        int operand;
        Calculator calculator;

        // Constructor
        public CalculatorCommand(Calculator calculator,
                                 char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        public char Operator
        {
            set { this.@operator = value; }
        }

        public int Operand
        {
            set { this.operand = value; }
        }

        public override void Execute()
        {
            this.calculator.Operation(this.@operator, this.operand);
        }

        public override void UnExecute()
        {
            this.calculator.Operation(this.Undo(this.@operator), this.operand);
        }

        private char Undo(char @operator)
        {
            char undo;
            switch (@operator)
            {
                case '+': undo = '-'; break;
                case '-': undo = '+'; break;
                case '*': undo = '/'; break;
                case '/': undo = '*'; break;
                default: undo = ' '; break;
            }
            return undo;
        }
    }
}