using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.ForecastDTO_post;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class ForecastApiClient : IForecastApiClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private ForecastDataParser _dataParser;

        public ForecastApiClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _dataParser = new ForecastDataParser();
        }

        public async Task<ForecastDTO_post> GetForecastByGivenCoordinates(Location coordinates)
        {
            string apiKey = Environment.GetEnvironmentVariable("OpenWeatherMap.ApiKey");
            string url = String.Format($"http://api.openweathermap.org/data/2.5/forecast?" +
                                        $"lat={coordinates.Latitude}&lon={coordinates.Longitude}&" +
                                        $"appid={apiKey}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return _dataParser.ParseForecastData(response.Content.ReadAsStringAsync().Result);

            else
                throw new NotImplementedException();
        }

    }
}
