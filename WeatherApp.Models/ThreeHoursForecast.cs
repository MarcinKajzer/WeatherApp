using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.Models.ThreeHoursForecast;

namespace WeatherApp.Models.DTOs
{
    public class ThreeHoursForecast
    {
        //[JsonProperty("cnt")]
        //public long Cnt { get; set; }

        [JsonProperty("list")]
        public List<Details> Details { get; set; }

        [JsonProperty("city")]
        public PlaceInfo PlaceInfo { get; set; }
    }
}
