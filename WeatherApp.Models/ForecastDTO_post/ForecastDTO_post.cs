using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastDTO_post
{
    public class ForecastDTO_post
    {
        public PlaceInfo_post PlaceInfo { get; set; }
        public List<ForecastDetails_post> Details { get; set; }

    }
}
