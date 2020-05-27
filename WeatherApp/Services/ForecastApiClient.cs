using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.DTOs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class ForecastApiClient : IForecastApiClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private ForecastDataParser _dataParser;
        private string _apiKey;
        
        public ForecastApiClient(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
            _dataParser = new ForecastDataParser();
            _apiKey = _config["OpenWeatherMap.ApiKey"];
        }

        public async Task<ForecastDTO> GetForecast(Location coordinates)
        {
            return new ForecastDTO
            {
                DailyForecast = await GetDailyForecast(coordinates),
                ThreeHoursForecast = await GetThreeHourForecast(coordinates)
            };
        }

        private async Task<ThreeHoursForecastParsed> GetThreeHourForecast(Location coordinates)
        {
            string url = String.Format($"http://api.openweathermap.org/data/2.5/forecast?" +
                                        $"lat={coordinates.Latitude}&lon={coordinates.Longitude}&" +
                                        $"appid={_apiKey}&lang=pl&units=metric");

            string result = await HttpGet(url);

            return _dataParser.ParseThreeHoursForecastData(result);
        }

        private async Task<DailyForecastParsed> GetDailyForecast(Location coordinates)
        {
            string url = String.Format($"https://api.openweathermap.org/data/2.5/onecall" +
                                        $"?lat={coordinates.Latitude}&lon={coordinates.Longitude}" +
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
