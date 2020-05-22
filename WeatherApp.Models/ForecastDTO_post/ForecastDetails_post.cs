using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.ForecastDTO_post
{
    public class ForecastDetails_post
    {
        public long Date { get; set; }
        public long CloudinessLevel { get; set; }
        public string WeatherSummary { get; set; }
        public string WeatherDescription { get; set; }
        public double Temperature { get; set; }
        public double FeelsLikeTemperature { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public long Pressure { get; set; }
        public long Humidity { get; set; }
        public double? Rain { get; set; }
        public double? Snow { get; set; }
        public double WindSpeed { get; set; }
        public long WindDirection { get; set; }
    }
}
