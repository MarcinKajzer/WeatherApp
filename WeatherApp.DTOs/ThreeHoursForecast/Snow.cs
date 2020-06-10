using Newtonsoft.Json;

namespace WeatherApp.DTOs.ThreeHoursForecast
{
    public class Snow
    {
        [JsonProperty("3h")]
        public double Level { get; set; }
    }
}