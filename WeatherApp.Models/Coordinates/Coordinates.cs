using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.Coordinates
{
    public partial class Coordinates
    {
        [JsonProperty("results")]
        public List<ApiResponse> Results { get; set; }

    }

}
