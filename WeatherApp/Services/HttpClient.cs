using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class HttpClient : IHttpClient
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> Get(string url)
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
