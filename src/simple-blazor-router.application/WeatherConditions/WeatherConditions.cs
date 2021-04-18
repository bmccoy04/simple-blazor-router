using System;
using System.Collections.Generic;
using System.Linq;

namespace simple_blazor_router.application.WeatherConditions
{
    public class WeatherCondition
    {
        public string Type { get; internal set; }
        public string Time { get; internal set; }
        public string Visibility { get; internal set; }
        public string RelativeHumidity { get; internal set; }
        public string Temperature { get; internal set; }
        public string Description { get; internal set; }
        public string Name { get; internal set; }
        public int Id { get; internal set; }
    }
}