using Newtonsoft.Json;

namespace WeatherApp.Models.ForecastModel
{
    public class Snow
    {
        [JsonProperty("3h")]
        public double The3H { get; set; }
    }
}