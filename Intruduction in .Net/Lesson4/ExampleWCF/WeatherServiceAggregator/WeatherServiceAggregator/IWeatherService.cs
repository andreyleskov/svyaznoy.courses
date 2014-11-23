using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherServiceAggregator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWeatherService" in both code and config file together.
    [ServiceContract]
    public interface IWeatherService
    {

        [OperationContract]
        int GetTemperature(int dayOffset);

        [OperationContract]
        WeatherForecast GetDataUsingDataContract(ForecastSettings settings);
    }

    [DataContract]
    public enum TemperatureMeasure
    {
        [EnumMemberAttribute ]
        Celcius,
        [EnumMemberAttribute ]
        Forengeit
    }

    // Use a data contract as illustrated in the sample below to add settings types to service operations.
    
    [DataContract]
    [KnownType(typeof(TemperatureMeasure))]
    public class ForecastSettings
    {
        [DataMember]
        public TemperatureMeasure Measure { get; set; }

        [DataMember]
        public int DayFrom { get; set; }

        [DataMember]
        public int DayTo { get; set; }

    }

    [DataContract]
    public class WeatherForecast
    {
        [DataMember]
        public int[] Temperatures;
    }

}
