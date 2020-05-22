using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastModel
{
    public class ForecastDTO_get
    {
        //[JsonProperty("cnt")]
        //public long Cnt { get; set; }

        [JsonProperty("list")]
        public List<ForecastDetails_get> Details { get; set; }

        [JsonProperty("city")]
        public PlaceInfo_get PlaceInfo { get; set; }
    }
}
