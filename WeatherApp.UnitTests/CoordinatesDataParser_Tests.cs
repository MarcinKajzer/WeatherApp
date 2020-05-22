using System.IO;
using System.Reflection;
using WeatherApp.Models;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.ForecastDTO_post;
using WeatherApp.Services;
using Xunit;
using Xunit.Abstractions;

namespace WeatherApp.UnitTests
{
    public class CoordinatesDataParser_Tests
    {
        private ITestOutputHelper _output;
        private GeocodingDataParser _parser;
        public CoordinatesDataParser_Tests(ITestOutputHelper output)
        {
            _output = output;
            _parser = new GeocodingDataParser();
        }

        public Coordinates execute(string json)
        {
            return _parser.ParseJsonToCoordinatesObject(json);
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
        public void parse_adress()
        {
            Coordinates result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.coordinates.txt"));

            Assert.Equal("Gdańsk, Polska", result.Results[0].FormattedAddress);
        }

        [Fact]
        public void parse_latitude()
        {
            Coordinates result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.coordinates.txt"));

            Assert.Equal(54.35202520000001 , result.Results[0].Geometry.Location.Latitude);
        }

        [Fact]
        public void parse_longitude()
        {
            Coordinates result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.coordinates.txt"));

            Assert.Equal(18.6466384, result.Results[0].Geometry.Location.Longitude);
        }
    }
}
