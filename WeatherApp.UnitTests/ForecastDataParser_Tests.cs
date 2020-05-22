using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Unicode;
using WeatherApp.Models;
using WeatherApp.Models.ForecastModel;
using WeatherApp.Services;
using Xunit;
using Xunit.Abstractions;

namespace WeatherApp.UnitTests
{
    public class ForecastDataParser_Tests
    {
        private ForecastDataParser _parser;
        public ITestOutputHelper _output { get; }
        public ForecastDataParser_Tests(ITestOutputHelper output)
        {
            _output = output;
            _parser = new ForecastDataParser();
        }

        Forecast execute(string json)
        {
            return _parser.ParseForecastData(json);
        }

        [Fact]
        public void parses_city_name()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal("Londyn", result.City.Name);
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
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));
            
            Assert.Equal(18.93, result.ForecastDetails[0].MainParameters.Temp);
        }

        [Fact]
        public void parses_feels_like_temperature()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(15.28, result.ForecastDetails[0].MainParameters.FeelsLike);
        }

        [Fact]
        public void parses_min_temperature()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(18.48, result.ForecastDetails[0].MainParameters.TempMin);
        }

        [Fact]
        public void parses_max_temperature()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(18.93, result.ForecastDetails[0].MainParameters.TempMax);
        }

        [Fact]
        public void parses_clouds()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(100, result.ForecastDetails[0].Clouds.CloudinessLevel);
        }

        [Fact]
        public void parses_humidity()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(37, result.ForecastDetails[0].MainParameters.Humidity);
        }

        [Fact]
        public void parses_preasure()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(1016, result.ForecastDetails[0].MainParameters.Pressure);
        }

        [Fact]
        public void parses_wind_speed()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));
            
            Assert.Equal(3.31, result.ForecastDetails[0].Wind.Speed);
        }
        [Fact]
        public void parses_wind_direction()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal(189, result.ForecastDetails[0].Wind.Deg);
        }

        [Fact]
        public void parses_forecast_description_text()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal("ca³kowite zachmurzenie",result.ForecastDetails[0].Description[0].Text.ToString());
        }
        [Fact]
        public void parses_forecast_description_main()
        {
            Forecast result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.forecast.txt"));

            Assert.Equal("Clouds", result.ForecastDetails[0].Description[0].Main);
        }


        
    }
}
