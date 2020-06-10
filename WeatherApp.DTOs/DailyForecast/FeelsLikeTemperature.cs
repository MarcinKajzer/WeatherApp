using Newtonsoft.Json;

namespace WeatherApp.DTOs.DailyForecast
{
    public class FeelsLikeTemperature
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }
    }
}
