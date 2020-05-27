
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Models.DailyForecast;
using WeatherApp.Models.DailyForecastParsed;
using WeatherApp.Models.DTOs;
using WeatherApp.Models.ThreeHoursForecast;
using WeatherApp.Models.ThreeHoursForecastParsed;

namespace WeatherApp.Services
{
    public class ForecastDataParser
    {
        public ThreeHoursForecastParsed ParseThreeHoursForecastData(string json)
        {
            ThreeHoursForecast forecast  =  JsonConvert.DeserializeObject<ThreeHoursForecast>(json);

            ThreeHoursForecastParsed forecastParsed = new ThreeHoursForecastParsed
            {
                PlaceInfo = ParsePlaceInfo(forecast.PlaceInfo),
                Details = new List<Models.ThreeHoursForecastParsed.Details>()
            };

            foreach (var item in forecast.Details)
                forecastParsed.Details.Add(ParseSingleDetailsSet(item));

            return forecastParsed;
        }

        private Models.ThreeHoursForecastParsed.PlaceInfo ParsePlaceInfo(Models.ThreeHoursForecast.PlaceInfo placeInfo)
        {
            return new Models.ThreeHoursForecastParsed.PlaceInfo
            {
                City = placeInfo.City,
                Country = placeInfo.Country,
                Sunrise = placeInfo.Sunrise,
                Sunset = placeInfo.Sunset
            };
        }

        private Models.ThreeHoursForecastParsed.Details ParseSingleDetailsSet(Models.ThreeHoursForecast.Details set)
        {
            Models.ThreeHoursForecastParsed.Details details =  new Models.ThreeHoursForecastParsed.Details
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

            if (set.Rain != null) details.Rain = set.Rain.The3H;
            
            if (set.Snow != null) details.Snow = set.Snow.The3H;
            
            return details;
        }


        public DailyForecastParsed ParseDailyForecastData(string json)
        {
            DailyForecast forecast = JsonConvert.DeserializeObject<DailyForecast>(json);

            DailyForecastParsed forecastParsed = new DailyForecastParsed
            {
                Details = new List<Models.DailyForecastParsed.SingleDayForecast>()
            };

            foreach (var item in forecast.SingleDay)
                forecastParsed.Details.Add(ParseSingleDayData(item));
           
            return forecastParsed;
        }

        private Models.DailyForecastParsed.SingleDayForecast ParseSingleDayData(Models.DailyForecast.SingleDayForecast data)
        {
            Models.DailyForecastParsed.SingleDayForecast day = new Models.DailyForecastParsed.SingleDayForecast
            {
                Date = data.Date,
                TemperatureMin = data.Temperature.Min,
                TemperatureMax = data.Temperature.Max,
                FeelsLikeTemperatureDay = data.FeelsLikeTemperature.Day,
                FeelsLikeTemperatureNight = data.FeelsLikeTemperature.Night,
                Pressure = data.Pressure,
                Humidity = data.Humidity,
                WindSpeed = data.WindSpeed,
                WindDirection = data.WindDeg,
                WeatherSummary = data.Description[0].Summary,
                WeatherDescription = data.Description[0].Text,
                Clouds = data.Clouds

            };

            if (data.Rain != null) day.Rain = data.Rain;

            if (data.Snow != null) day.Snow = data.Snow;

            return day;
        }

    }
}
