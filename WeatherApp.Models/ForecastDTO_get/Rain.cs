using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastModel
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double The3H { get; set; }
    }
}
