using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.DTOs.Coordinates;

namespace WeatherApp.DTOs.DTOs
{
    public partial class Coordinates
    {
        [JsonProperty("results")]
        public List<Details> Details { get; set; }

    }

}
