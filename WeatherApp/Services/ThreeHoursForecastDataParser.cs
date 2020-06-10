
using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.DTOs.DailyForecast;
using WeatherApp.DTOs.DailyForecastParsed;
using WeatherApp.DTOs.DTOs;
using WeatherApp.DTOs.ThreeHoursForecast;
using WeatherApp.DTOs.ThreeHoursForecastParsed;

namespace WeatherApp.Services
{
    public class ThreeHoursForecastDataParser
    {
        public ThreeHoursForecastParsed Parse(string json)
        {
            ThreeHoursForecast forecast  =  JsonConvert.DeserializeObject<ThreeHoursForecast>(json);

            ThreeHoursForecastParsed forecastParsed = new ThreeHoursForecastParsed
            {
                PlaceInfo = ParsePlaceInfo(forecast.PlaceInfo),
                Details = new List<ThreeHoursDetailsParsed>()
            };

            foreach (var item in forecast.Details)
                forecastParsed.Details.Add(ParseDetails(item));

            return forecastParsed;
        }

        private PlaceInfoParsed ParsePlaceInfo(PlaceInfo placeInfo)
        {
            return new PlaceInfoParsed
            {
                City = placeInfo.City,
                Country = placeInfo.Country,
                Sunrise = placeInfo.Sunrise,
                Sunset = placeInfo.Sunset
            };
        }

        private ThreeHoursDetailsParsed ParseDetails(ThreeHoursDetails set)
        {
            ThreeHoursDetailsParsed details =  new ThreeHoursDetailsParsed
            {
                Date = set.Date,
                CloudinessLevel = set.Clouds.CloudinessLevel,
                WeatherSummary = set.Description[0].Summary,
                WeatherDescription = set.Description[0].Text,
                Temperature = set.MainParameters.Temperature,
                FeelsLikeTemperature = set.MainParameters.FeelsLikeTemperature,
                TemperatureMin = set.MainParameters.TemperatureMin,
                TemperatureMax = set.MainParameters.TemperatureMax,
                Pressure = set.MainParameters.Pressure,
                Humidity = set.MainParameters.Humidity,
                WindSpeed = set.Wind.Speed,
                WindDirection = set.Wind.Direction,
            };

            if (set.Rain != null) details.Rain = set.Rain.Level;
            
            if (set.Snow != null) details.Snow = set.Snow.Level;
            
            return details;
        }

    }
}
