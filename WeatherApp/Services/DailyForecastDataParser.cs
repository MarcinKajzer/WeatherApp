using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.DTOs.DailyForecast;
using WeatherApp.DTOs.DailyForecastParsed;
using WeatherApp.DTOs.DTOs;

namespace WeatherApp.Services
{
    public class DailyForecastDataParser
    {
        public DailyForecastParsed Parse(string json)
        {
            DailyForecast forecast = JsonConvert.DeserializeObject<DailyForecast>(json);

            DailyForecastParsed forecastParsed = new DailyForecastParsed
            {
                Details = new List<SingleDayDetailsParsed>()
            };

            foreach (var item in forecast.Details)
                forecastParsed.Details.Add(ParseDetails(item));

            return forecastParsed;
        }

        private SingleDayDetailsParsed ParseDetails(SingleDayDetails details)
        {
            SingleDayDetailsParsed detailsParsed = new SingleDayDetailsParsed
            {
                Date = details.Date,
                TemperatureMin = details.Temperature.Min,
                TemperatureMax = details.Temperature.Max,
                FeelsLikeTemperatureDay = details.FeelsLikeTemperature.Day,
                FeelsLikeTemperatureNight = details.FeelsLikeTemperature.Night,
                Pressure = details.Pressure,
                Humidity = details.Humidity,
                WindSpeed = details.WindSpeed,
                WindDirection = details.WindDirection,
                WeatherSummary = details.Description[0].Summary,
                WeatherDescription = details.Description[0].Text,
                CloudinessLevel = details.Clouds

            };

            if (details.Rain != null) detailsParsed.Rain = details.Rain;

            if (details.Snow != null) detailsParsed.Snow = details.Snow;

            return detailsParsed;
        }
    }
}
