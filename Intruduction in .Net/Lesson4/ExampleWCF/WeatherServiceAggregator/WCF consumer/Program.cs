using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_consumer
{
    using WCF_consumer.WeatherService;

    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new WeatherServiceClient())
            {
                Console.WriteLine("getting temperature of day: " + service.GetTemperature(5));
                Console.WriteLine("getting temperature of days: " + service.GetDataUsingDataContract(new ForecastSettings(){DayFrom = 1, DayTo = 10,Measure = TemperatureMeasure.Forengeit}).Temperatures.First());

            }
            Console.ReadLine();
        }
    }
}
