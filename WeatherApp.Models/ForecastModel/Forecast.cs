using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastModel
{
    public class Forecast
    {
        [JsonProperty("cnt")]
        public long Cnt { get; set; }

        [JsonProperty("list")]
        public ForecastDetails[] ForecastDetails { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
