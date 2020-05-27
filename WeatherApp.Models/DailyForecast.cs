using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.Models.DailyForecast;

namespace WeatherApp.Models.DTOs
{
    public class DailyForecast
    {
        [JsonProperty("daily")]
        public List<SingleDayForecast> SingleDay { get; set; }
    }
}

