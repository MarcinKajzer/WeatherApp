using Newtonsoft.Json;

namespace WeatherApp.DTOs.ThreeHoursForecast
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long CloudinessLevel { get; set; }
    }
}
