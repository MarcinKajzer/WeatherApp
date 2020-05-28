using System.Collections.Generic;
using WeatherApp.Models.DailyForecastParsed;

namespace WeatherApp.Models.DTOs
{
    public class DailyForecastParsed
    {
        public List<SingleDayForecastParsed> Details { get; set; }
    }
}
