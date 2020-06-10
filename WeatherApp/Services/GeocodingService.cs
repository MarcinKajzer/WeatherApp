using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.DTOs;
using WeatherApp.DTOs.DTOs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class GeocodingService : IGeocodingService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _config;
        private GeocodingDataParser _dataParser;
        private readonly string _apiKey;

        public GeocodingService(IHttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _dataParser = new GeocodingDataParser();
            _apiKey = _config["Google.ApiKey"];
        }

        public async Task<CoordinatesParsed> GetCoordinates(string place)
        {
            string url = String.Format($"https://maps.googleapis.com/maps/api/geocode/json?" +
                                        $"address={place}&key={_apiKey}&language=pl");

            string result = await _httpClient.Get(url);

            return _dataParser.ParseJsonToCoordinatesObject(result);
        }
    }
    
}
