using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherServiceAggregator
{

    public class WeatherService : IWeatherService
    {
        public int GetTemperature(int value)
        {
            return value % 7 + 10;
        }

        public WeatherForecast GetDataUsingDataContract(ForecastSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            int coeff = settings.Measure == TemperatureMeasure.Celcius ? 0 : 100;
            int dayOffset;

            int length = settings.DayTo - settings.DayFrom;
            int[] temperature = new int[length];

            for (dayOffset = 0; dayOffset < length; dayOffset++)
                temperature[dayOffset] = this.GetTemperature(dayOffset) + coeff;     

            return new WeatherForecast(){Temperatures = temperature};
        }
    }
}
