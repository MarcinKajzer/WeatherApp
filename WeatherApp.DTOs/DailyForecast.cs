using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.DTOs.DailyForecast;

namespace WeatherApp.DTOs.DTOs
{
    public class DailyForecast
    {
        [JsonProperty("daily")]
        public List<SingleDayDetails> Details { get; set; }
    }
}
