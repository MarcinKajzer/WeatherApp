
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WeatherApp.Models.ForecastDTO_post;
using WeatherApp.Models.ForecastModel;

namespace WeatherApp.Services
{
    public class ForecastDataParser
    {
        public ForecastDTO_post ParseForecastData(string json)
        {
            ForecastDTO_get forecast_get  =  JsonConvert.DeserializeObject<ForecastDTO_get>(json);

            List<ForecastDetails_post> detailsList = new List<ForecastDetails_post>();

            foreach (var item in forecast_get.Details)
            {
                detailsList.Add(ParseSingleDetailsSet(item));
            }

            ForecastDTO_post forecast_post = new ForecastDTO_post
            {
                PlaceInfo = ParsePlaceInfo(forecast_get.PlaceInfo),
                Details = detailsList
            };

            return forecast_post;
        }

        PlaceInfo_post ParsePlaceInfo(PlaceInfo_get placeInfo)
        {
            return new PlaceInfo_post
            {
                City = placeInfo.City,
                Country = placeInfo.Country,
                Sunrise = placeInfo.Sunrise,
                Sunset = placeInfo.Sunset
            };
        }

        ForecastDetails_post ParseSingleDetailsSet(ForecastDetails_get set)
        {
            ForecastDetails_post forecast_post =  new ForecastDetails_post
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

            if (set.Rain != null) forecast_post.Rain = set.Rain.The3H;
            
            if (set.Snow != null) forecast_post.Snow = set.Snow.The3H;
            
            return forecast_post;
        }
       
        
    }
}
