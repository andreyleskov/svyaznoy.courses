using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        public interface ICashDesk
        {
            int Sale(int summ);
            int Withdraw(int summ);
            int CurrentAmount {get;}
        }
        class MemoryCashDesk: ICashDesk
        {
            private int sum = 0;
            public int Sale(int summ)
            {
                sum += summ;
                return sum;
            }

            public int Withdraw(int summ)
            {
                sum -= summ;
                return sum;
            }

            public int CurrentAmount
            {
                get { return sum; }
            }
        }
        class LoggingDecorator: ICashDesk 
        {
            ICashDesk _desk;
            private void Log(string name)
            {
                Console.WriteLine("Beware: action was done! : " + name);
            }
            public LoggingDecorator(ICashDesk desk)
            {
                _desk = desk;
            }

            public int Sale(int summ)
            {
                Log("sale drugs");
                return _desk.Sale(summ);
            }

            public int Withdraw(int summ)
            {
                Log("stealing cash");
                return _desk.Withdraw(summ);
            }

            public int CurrentAmount
            {
                get {
                    Log("looking for current amount");
                    return _desk.CurrentAmount; }
            }
        }
        static void Main(string[] args)
        {
            ICashDesk cash = new LoggingDecorator(new MemoryCashDesk());

            Console.WriteLine("sale for 10, current amount:" + cash.Sale(10));
            Console.WriteLine("withdraw for 4, current amount:" + cash.Withdraw(4));
            Console.WriteLine("current amount:" + cash.CurrentAmount);

            Console.ReadKey();
        }
    }
}
