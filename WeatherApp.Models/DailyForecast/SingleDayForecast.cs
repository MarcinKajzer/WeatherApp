using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApp.Models.DailyForecast
{
    public class SingleDayForecast
    {
        [JsonProperty("dt")]
        public long Date { get; set; }

        [JsonProperty("temp")]
        public Temperature Temperature { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLikeTemperature FeelsLikeTemperature { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_deg")]
        public long WindDeg { get; set; }

        [JsonProperty("weather")]
        public List<Description> Description { get; set; }

        [JsonProperty("clouds")]
        public long Clouds { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public double? Rain { get; set; }
        [JsonProperty("snow", NullValueHandling = NullValueHandling.Ignore)]
        public double? Snow { get; set; }
    }
}
