using Newtonsoft.Json;

namespace WeatherApp.DTOs.ThreeHoursForecast
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double Level { get; set; }
    }
}
