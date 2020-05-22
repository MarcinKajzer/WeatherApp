using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastModel
{
    public class ForecastDetails
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("main")]
        public WeatherDetails MainParameters { get; set; }

        [JsonProperty("weather")]
        public Description[] Description { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("dt_txt")]
        public DateTimeOffset DtTxt { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public Rain Rain { get; set; }

        [JsonProperty("snow", NullValueHandling = NullValueHandling.Ignore)]
        public Snow Snow { get; set; }
    }
}
