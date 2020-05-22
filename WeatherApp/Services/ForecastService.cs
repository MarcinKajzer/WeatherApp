using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class ForecastService : IForecastService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;

        public ForecastService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
        }
        public async Task GetForecastByCoordinates(string latitude, string longitude)
        {
            string apiKey = configuration["OpenWeatherMap.ApiKey"];
            string url = String.Format($"api.openweathermap.org/data/2.5/forecast?" +
                                        $"lat={latitude}&lon={longitude}&appid={apiKey}");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await clientFactory.CreateClient().SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
            }
            else
            {

            }
        }
    }
}
