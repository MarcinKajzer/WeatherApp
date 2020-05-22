using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastModel
{
    public class Description
    {
        [JsonProperty("main")]
        public string Summary { get; set; }

        [JsonProperty("description")]
        public string Text { get; set; }
    }
}
