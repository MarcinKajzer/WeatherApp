using System.Collections.Generic;
using WeatherApp.DTOs.ThreeHoursForecastParsed;

namespace WeatherApp.DTOs.DTOs
{
    public class ThreeHoursForecastParsed
    {
        public PlaceInfoParsed PlaceInfo { get; set; }
        public List<ThreeHoursDetailsParsed> Details { get; set; }

    }
}
