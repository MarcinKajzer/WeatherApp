using System.Collections.Generic;
using WeatherApp.DTOs.DailyForecastParsed;

namespace WeatherApp.DTOs.DTOs
{
    public class DailyForecastParsed
    {
        public List<SingleDayDetailsParsed> Details { get; set; }
    }
}
