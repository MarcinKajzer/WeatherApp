﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using WeatherApp.Services;
using Xunit;
using Xunit.Abstractions;
using HttpClient = System.Net.Http.HttpClient;

namespace WeatherApp.IntegrationTests
{
    public class GoogleGeocoderApiService_Tests
    {
        public ITestOutputHelper _output { get; }
        IConfiguration configuration { get; set; }

        public GoogleGeocoderApiService_Tests(ITestOutputHelper output)
        {
            _output = output;

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<GoogleGeocoderApiService_Tests>();
            
            

            configuration = builder.Build();
        }

        public string execute(string placeName)
        {
            string apiKey = configuration["Google.ApiKey"];
            string url = String.Format($"https://maps.googleapis.com/maps/api/geocode/json?" +
                                        $"address={placeName}&key={apiKey}");

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;

        }

        [Fact]
        public void returns_response()
        {
            string result = execute("London");

            Assert.NotEmpty(result);
        }

        [Fact]
        public void returns_json_response()
        {
            string result = execute("London");

            var exception = Record.Exception(() => deserialize_json(result));

            Assert.Null(exception);
        }

        private static dynamic deserialize_json(string result)
        {
            return JsonConvert.DeserializeObject<dynamic>(result);
        }

        [Fact]
        public void returns_correct_London_coordinates_by_given_city_name()
        {
            string json = execute("London");

            dynamic deserialized_object = deserialize_json(json);
            dynamic coordinates = deserialized_object["results"][0]["geometry"]["location"];

            Assert.True(coordinates["lat"] == 51.5073509);
            Assert.True(coordinates["lng"] == -0.1277583);
        }

    }
}
