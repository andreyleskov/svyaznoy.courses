namespace Command
{
    using System;

    /// <summary>
    /// "Receiver" : ���������� 
    /// </summary>
 

    class Calculator
    {
        private int curr = 0;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': this.curr += operand; break;
                case '-': this.curr -= operand; break;
                case '*': this.curr *= operand; break;
                case '/': this.curr /= operand; break;
                case '^': this.curr = (int)Math.Pow(curr, operand); break;
                case 's': this.curr = (int)Math.Pow(curr, 1.0 / operand); break;
            }

            Console.WriteLine(
                "Current value = {0,3} (following {1} {2})",
                this.curr, @operator, operand);
        }
    }
}