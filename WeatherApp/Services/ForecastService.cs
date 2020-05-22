using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.ForecastDTO_post;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class ForecastService : IForecastService
    {
        private readonly IHttpClientFactory _clientFactory;
        private ForecastDataParser _dataParser;

        public ForecastService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _dataParser = new ForecastDataParser();
        }

        public async Task<ForecastDTO_post> GetForecastByCoordinates(Location coordinates)
        {
            string apiKey = Environment.GetEnvironmentVariable("OpenWeatherMap.ApiKey");
            string url = String.Format($"http://api.openweathermap.org/data/2.5/forecast?" +
                                        $"lat={coordinates.Latitude}&lon={coordinates.Longitude}&" +
                                        $"appid={apiKey}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result =  response.Content.ReadAsStringAsync().Result;

                return _dataParser.ParseForecastData(result);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}
