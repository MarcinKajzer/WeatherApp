using Newtonsoft.Json;

namespace WeatherApp.Models.Coordinates
{
    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
