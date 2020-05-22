using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.Coordinates
{
    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
