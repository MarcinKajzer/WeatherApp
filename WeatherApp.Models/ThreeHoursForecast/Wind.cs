using Newtonsoft.Json;

namespace WeatherApp.Models.ThreeHoursForecast
{

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Direction { get; set; }
    }
}
