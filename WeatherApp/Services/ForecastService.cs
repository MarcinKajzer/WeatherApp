using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.DTOs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class ForecastService : IForecastService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private ForecastDataParser _dataParser;
        private string _apiKey;
        
        public ForecastService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
            _dataParser = new ForecastDataParser();
            _apiKey = _config["OpenWeatherMap.ApiKey"];
        }

        public async Task<ForecastDTO> GetForecast(CoordinatesParsed coord)
        {
            return new ForecastDTO
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

            string result = await HttpGet(url);

            return _dataParser.ParseThreeHoursForecastData(result);
        }

        private async Task<DailyForecastParsed> GetDailyForecast(CoordinatesParsed coord)
        {
            string url = String.Format($"https://api.openweathermap.org/data/2.5/onecall" +
                                        $"?lat={coord.Latitude}&lon={coord.Longitude}" +
                                        $"&appid={_apiKey}&units=metric&lang=pl" +
                                        $"&exclude=hourly,current,minutelly");

            string result = await HttpGet(url);

            return  _dataParser.ParseDailyForecastData(result);
        }

        private async Task<string> HttpGet(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsStringAsync().Result;

            else
                return null;
        }

    }
}
