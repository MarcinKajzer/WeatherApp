using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        private GeocodingDataParser _dataParser;

        public GeocodingApiClient(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
            _dataParser = new GeocodingDataParser();
        }

        public async Task<Coordinates> GetCoordinatesByGivenPlaceName(string place)
        {
            string apiKey = _config["Google.ApiKey"];
            string url = String.Format($"https://maps.googleapis.com/maps/api/geocode/json?" +
                                        $"address={place}&key={apiKey}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return _dataParser.ParseJsonToCoordinatesObject(response.Content.ReadAsStringAsync().Result);

            else
                return null;    
        }
    }
    
}
