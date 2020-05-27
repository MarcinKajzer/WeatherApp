using Newtonsoft.Json;

namespace WeatherApp.Models.DailyForecast
{
    public class Temperature
    {
        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

    }
}
