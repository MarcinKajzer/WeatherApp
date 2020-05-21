using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest
{
    public class WeatherApiServiceTests
    {
        public ITestOutputHelper _output { get; }
        IConfiguration Configuration { get; set; }

        public WeatherApiServiceTests(ITestOutputHelper output )
        {
            _output = output;

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<WeatherApiServiceTests>();

            Configuration = builder.Build();
        }

        string execute(string latitude, string longitude)
        {
            string apiKey = Configuration["OpenWeatherMap.ApiKey"];
            string url = String.Format($"http://api.openweathermap.org/data/2.5/forecast?" +
                                        $"lat={latitude}&lon={longitude}&appid={apiKey}");

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        [Fact]
        public void returns_response()
        {
            string results = execute("51.5085", "-0.1257");
           
            Assert.NotEmpty(results);
        }
       
        [Fact]
        public void returns_json_response()
        {
            string results = execute("51.5085", "-0.1257");

            var exception = Record.Exception(() => deserialize_json(results));

            Assert.Null(exception);
        }

        private static dynamic deserialize_json(string results)
        {
            return JsonConvert.DeserializeObject<dynamic>(results);
        }

        [Fact]
        public void returns_forecast_for_London_by_given_coordinates()
        {
            string json = execute("51.5085", "-0.1257");

            dynamic deserializedObject = deserialize_json(json);

            dynamic cityInfo = deserializedObject["city"];
          
            Assert.True(cityInfo["id"] == 2643743);
            Assert.True(cityInfo["name"] == "London");
            Assert.True(cityInfo["country"] == "GB");
            Assert.True(cityInfo["coord"]["lat"] == 51.5085);
            Assert.True(cityInfo["coord"]["lon"] == -0.1257);
        }
    }
}
