using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models.ThreeHoursForecastParsed;

namespace WeatherApp.Models.DTOs
{
    public class ThreeHoursForecastParsed
    {
        public PlaceInfo PlaceInfo { get; set; }
        public List<Details> Details { get; set; }

    }
}
