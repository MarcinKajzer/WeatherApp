using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.Models.Coordinates;

namespace WeatherApp.Models.DTOs
{
    public partial class Coordinates
    {
        [JsonProperty("results")]
        public List<ApiResponse> Results { get; set; }

    }

}
