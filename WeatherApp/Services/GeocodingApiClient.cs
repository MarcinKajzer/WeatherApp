using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.ForecastDTO_post;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class GeocodingApiClient : IGeocodingApiClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private GeocodingDataParser _dataParser;

        public GeocodingApiClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _dataParser = new GeocodingDataParser();
        }

        public async Task<Coordinates> GetCoordinatesByGivenPlaceName(string place)
        {
            string apiKey = Environment.GetEnvironmentVariable("Google.ApiKey");
            string url = String.Format($"https://maps.googleapis.com/maps/api/geocode/json?" +
                                        $"address={place}&key={apiKey}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return _dataParser.ParseJsonToCoordinatesObject(response.Content.ReadAsStringAsync().Result);

            else
                throw new NotImplementedException();
        }
    }
    
}
