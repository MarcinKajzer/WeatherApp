using Newtonsoft.Json;

namespace WeatherApp.Models.ThreeHoursForecast
{
    public class Description
    {
        [JsonProperty("main")]
        public string Summary { get; set; }

        [JsonProperty("description")]
        public string Text { get; set; }
    }
}
