using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {

        interface IWeatherService
        {
            int GetTemperature(int day);
        }

        class WeatherService:IWeatherService
        {
            public WeatherService()
            {
                Console.WriteLine("Creating real service");
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }

            public int GetTemperature(int day)
            {
                Console.WriteLine("In real service");
                Thread.Sleep(TimeSpan.FromSeconds(4));
                return day % 7 + 10;
            }
        }

        class WeatherServiceProxy:IWeatherService
        {
            private Lazy<IWeatherService> _service; 
            private Dictionary<int,Tuple<int,DateTime>> _cache = new Dictionary<int, Tuple<int, DateTime>>();
            private readonly TimeSpan _expirationTime;

            public WeatherServiceProxy(Func<IWeatherService> serviceCreator, TimeSpan expirationTime)
            {
                _expirationTime = expirationTime;
                _service = new Lazy<IWeatherService>(serviceCreator);
            }

            public int GetTemperature(int day)
            {
                Tuple<int,DateTime> cachedValue;
                if (_cache.TryGetValue(day, out cachedValue))
                {
                    Console.WriteLine("found cached value");
                    if(DateTime.Now < cachedValue.Item2 + _expirationTime) return cachedValue.Item1;
                    Console.WriteLine("but it is expired");
                }

                var serviceValue = _service.Value.GetTemperature(day);
                _cache[day] = new Tuple<int, DateTime>(serviceValue, DateTime.Now);
                Console.WriteLine("{2}: Cached new temperature: {0} for day {1}",serviceValue, day, DateTime.Now);
                return serviceValue;
            }

        }
        static void Main(string[] args)
        {
            var weatherService = new WeatherServiceProxy(() => new WeatherService(),TimeSpan.FromSeconds(60));

            //var weatherService =  new WeatherService();

            StartTemperatureMonitoring(weatherService);
        }

        private static void StartTemperatureMonitoring(IWeatherService weatherService)
        {
            var random = new Random();
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(random.Next(2)));
                int day = random.Next(3);
                Console.WriteLine("{0}: Getting temperature for day {1}", DateTime.Now, day);
                var temperature = weatherService.GetTemperature(day);
                Console.WriteLine("{0}: Temperature is {1}", DateTime.Now, temperature);
            }
        }
    }
}
