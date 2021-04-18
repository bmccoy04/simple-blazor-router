using System;
using System.Collections.Generic;
using System.Linq;

namespace simple_blazor_router.application.WeatherConditions
{
    public class WeatherConditionsProvider : IWeatherConditionsProvider
    {
        public IEnumerable<WeatherCondition> Get()
        {
            var retValue = new List<WeatherCondition>
            { 
                AlderaanConditions, 
                HothConditions, 
                NabooConditions, 
                DagobahConditions,
                JakkuConditions, 
                BatuConditions
            };

            return retValue.OrderBy(x => x.Name).AsEnumerable();
        }

        public WeatherCondition Get(int id)
        {
            return Get().SingleOrDefault(x => x.Id == id);
        }

        public WeatherCondition AlderaanConditions => new WeatherCondition()
        {
            Id = 1,
            Name = "Alderaan",
            Description = "NaN",
            Temperature = "NaN",
            RelativeHumidity = "NaN",
            Visibility = "None",
            Time = "NaN",
            Type = "NaN"
        };
        public WeatherCondition HothConditions => new WeatherCondition()
        {
            Id = 2,
            Name = "Hoth",
            Description = "It's very cold here",
            Temperature = "-76",
            RelativeHumidity = "0",
            Visibility = "Very little",
            Time = GetTime(31, 21, 81, 6),
            Type = "Frigid"
        };

        public WeatherCondition NabooConditions => new WeatherCondition()
        {
            Id = 3,
            Name = "Naboo",
            Description = "It's all good here",
            Temperature = "76",
            RelativeHumidity = "10%",
            Visibility = "Good",
            Time = GetTime(2, 0, 41, 25),
            Type = "Sunny"
        };

        public WeatherCondition DagobahConditions => new WeatherCondition()
        {
            Id = 4,
            Name = "Degobah",
            Description = "Very rainy with violent lightning",
            Temperature = "91",
            RelativeHumidity = "100%",
            Visibility = "Ok",
            Time =  GetTime(-71, 6, 33, 0),
            Type = "Violently Storming"
        };
        public WeatherCondition JakkuConditions => new WeatherCondition()
        {
            Id = 5,
            Name = "Jakku",
            Description = "Bright, barren, and cold",
            Temperature = "55",
            RelativeHumidity = "5%",
            Visibility = "Very good",
            Time = GetTime(100, 10, 5, 30),
            Type = "Sunny"
        };
        public WeatherCondition BatuConditions => new WeatherCondition()
        {
            Id = 6,
            Name = "Batu",
            Description = "Hot and steamy",
            Temperature = "95",
            RelativeHumidity = "70%",
            Visibility = "Pretty Good",
            Time = GetTime(0, -1, 0, 0), 
            Type = "Sunny"
        };

        private string GetTime(int daysOffset, int hourOffest, int minOffset, int secondsOffset)
        {
            var now = DateTime.Now.AddDays(daysOffset).AddHours(hourOffest).AddMinutes(minOffset).AddSeconds(secondsOffset);
            return now.ToLongDateString() + " " + now.ToLongTimeString();
        }
    }

    public interface IWeatherConditionsProvider
    {
        IEnumerable<WeatherCondition> Get();
        WeatherCondition Get(int id);
    }

}