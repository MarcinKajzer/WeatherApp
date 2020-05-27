using Newtonsoft.Json;

namespace WeatherApp.Models.ThreeHoursForecast
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long CloudinessLevel { get; set; }
    }
}
