using Newtonsoft.Json;

namespace WeatherApp.DTOs.Coordinates
{
    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
