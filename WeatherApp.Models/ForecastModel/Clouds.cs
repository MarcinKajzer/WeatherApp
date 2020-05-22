using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastModel
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long CloudinessLevel { get; set; }
    }
}
