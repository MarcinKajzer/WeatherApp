using Newtonsoft.Json;

namespace WeatherApp.DTOs.Coordinates
{
    public class Details
    {
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
