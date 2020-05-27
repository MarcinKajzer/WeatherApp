using Newtonsoft.Json;

namespace WeatherApp.Models.Coordinates
{
    public class ApiResponse
    {
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
