using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.DTOs.ThreeHoursForecast;

namespace WeatherApp.DTOs.DTOs
{
    public class ThreeHoursForecast
    {
        [JsonProperty("list")]
        public List<ThreeHoursDetails> Details { get; set; }

        [JsonProperty("city")]
        public PlaceInfo PlaceInfo { get; set; }
    }
}
