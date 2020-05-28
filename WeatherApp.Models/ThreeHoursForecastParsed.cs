using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models.ThreeHoursForecastParsed;

namespace WeatherApp.Models.DTOs
{
    public class ThreeHoursForecastParsed
    {
        public PlaceInfoParsed PlaceInfo { get; set; }
        public List<DetailsParsed> Details { get; set; }

    }
}
