using Newtonsoft.Json;

namespace WeatherApp.Models.ThreeHoursForecast
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double The3H { get; set; }
    }
}
