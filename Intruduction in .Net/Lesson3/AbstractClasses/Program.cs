using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int horsePower = 120;

            CarTaxCalculator[] calculators = { new CentralRegionTaxCalculator(), new EastRegionTaxCalculator() };
            foreach (var calculator in calculators)
            {
                Console.WriteLine("In region " + calculator + " tax for " + horsePower + " will be " + calculator.CalculateTax(horsePower));
            }
            Console.ReadKey();
        }
    }

    public class CentralRegionTaxCalculator : CarTaxCalculator
    {
        protected override double GetRegionCoefficient()
        {
            return 1.5;
        }

        protected override string GetName()
        {
            return "CentralRegion";
        }
    }

    public class EastRegionTaxCalculator : CarTaxCalculator
    {
        protected override double GetRegionCoefficient()
        {
            return 1.3;
        }
    }

    public abstract class CarTaxCalculator
    {
        protected abstract double GetRegionCoefficient();

        protected virtual string GetName()
        {
            return "CarTaxCalculator";
        }

        public double CalculateTax(int horsePower)
        {
            return horsePower * this.GetRegionCoefficient();
        }

        public override string ToString()
        {
            return this.GetName();
        }
    }
}
