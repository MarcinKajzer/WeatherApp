using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class GoogleGeocodingService : IGoogleGeocodingService
    {
        private readonly IHttpClientFactory _clientFactory;

        public GoogleGeocodingService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Location> GetCoordinatesByGivenPlaceName(string place)
        {
            string apiKey = Environment.GetEnvironmentVariable("Google.ApiKey");
            string url = String.Format($"https://maps.googleapis.com/maps/api/geocode/json?" +
                                        $"address={place}&key={apiKey}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Location>(result);
            }
            else
            {
                throw new NotImplementedException();
            }

        }
  
    }
}
