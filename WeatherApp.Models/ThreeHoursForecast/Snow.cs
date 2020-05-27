using Newtonsoft.Json;

namespace WeatherApp.Models.ThreeHoursForecast
{
    public class Snow
    {
        [JsonProperty("3h")]
        public double The3H { get; set; }
    }
}