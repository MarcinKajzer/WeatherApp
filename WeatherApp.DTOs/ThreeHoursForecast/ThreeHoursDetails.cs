using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApp.DTOs.ThreeHoursForecast
{
    public class ThreeHoursDetails
    {
        [JsonProperty("dt")]
        public long Date { get; set; }

        [JsonProperty("main")]
        public MainParameters MainParameters { get; set; }

        [JsonProperty("weather")]
        public List<Description> Description { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public Rain Rain { get; set; }

        [JsonProperty("snow", NullValueHandling = NullValueHandling.Ignore)]
        public Snow Snow { get; set; }
    }
}
