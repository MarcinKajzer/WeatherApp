using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using WeatherApp.DTOs;
using WeatherApp.DTOs.DTOs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class ForecastService : IForecastService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _config;
        private ThreeHoursForecastDataParser _threeHoursParser;
        private DailyForecastDataParser _dailyParser;
        private string _apiKey;
        
        public ForecastService(IHttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _threeHoursParser = new ThreeHoursForecastDataParser();
            _dailyParser = new DailyForecastDataParser();
            _apiKey = _config["OpenWeatherMap.ApiKey"];
        }

        public async Task<Forecast> Get(CoordinatesParsed coord)
        {
            return new Forecast
            {
                DailyForecast = await GetDailyForecast(coord),
                ThreeHoursForecast = await GetThreeHourForecast(coord)
            };
        }

        private async Task<ThreeHoursForecastParsed> GetThreeHourForecast(CoordinatesParsed coord)
        {
            string url = String.Format($"http://api.openweathermap.org/data/2.5/forecast?" +
                                        $"lat={coord.Latitude}&lon={coord.Longitude}&" +
                                        $"appid={_apiKey}&lang=pl&units=metric");

            string result = await _httpClient.Get(url);

            return _threeHoursParser.Parse(result);
        }

        private async Task<DailyForecastParsed> GetDailyForecast(CoordinatesParsed coord)
        {
            string url = String.Format($"https://api.openweathermap.org/data/2.5/onecall" +
                                        $"?lat={coord.Latitude}&lon={coord.Longitude}" +
                                        $"&appid={_apiKey}&units=metric&lang=pl" +
                                        $"&exclude=hourly,current,minutelly");

            string result = await _httpClient.Get(url);

            return  _dailyParser.Parse(result);
        }

    }
}
