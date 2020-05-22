using System.IO;
using System.Reflection;
using WeatherApp.Models.ForecastDTO_post;
using WeatherApp.Services;
using Xunit;
using Xunit.Abstractions;

namespace WeatherApp.UnitTests
{
    public class ForecastDataParser_Tests
    {
        private ForecastDataParser _parser;
        private ITestOutputHelper _output { get; }
        public ForecastDataParser_Tests(ITestOutputHelper output)
        {
            _output = output;
            _parser = new ForecastDataParser();
        }

        ForecastDTO_post execute(string json)
        {
            return _parser.ParseForecastData(json);
        }

        [Fact]
        public void parses_city_name()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));
            
            Assert.Equal("Londyn", result.PlaceInfo.City);
        }

        private string ReadEmbededResourceFile(string filename)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            using (var stream = thisAssembly.GetManifestResourceStream(filename))
            {
                using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        [Fact]
        public void parses_current_temperature()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));
            
            Assert.Equal(18.93, result.Details[0].Temperature);
        }

        [Fact]
        public void parses_feels_like_temperature()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(15.28, result.Details[0].FeelsLikeTemperature);
        }

        [Fact]
        public void parses_min_temperature()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(18.48, result.Details[0].TemperatureMin);
        }

        [Fact]
        public void parses_max_temperature()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(18.93, result.Details[0].TemperatureMax);
        }

        [Fact]
        public void parses_clouds()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(100, result.Details[0].CloudinessLevel);
        }

        [Fact]
        public void parses_humidity()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(37, result.Details[0].Humidity);
        }

        [Fact]
        public void parses_preasure()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(1016, result.Details[0].Pressure);
        }

        [Fact]
        public void parses_wind_speed()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(3.31, result.Details[0].WindSpeed);
        }
        [Fact]
        public void parses_wind_direction()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(189, result.Details[0].WindDirection);
        }

        [Fact]
        public void parses_forecast_description_text()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal("ca³kowite zachmurzenie", result.Details[0].WeatherDescription);
        }

        [Fact]
        public void parses_forecast_description_summary()
        {
            ForecastDTO_post result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal("Clouds", result.Details[0].WeatherSummary);
        }



    }
}
