using Newtonsoft.Json;

namespace WeatherApp.DTOs.Coordinates
{
    public class Location
    {
        [JsonRequired]
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonRequired]
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
