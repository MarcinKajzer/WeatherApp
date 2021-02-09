using System.IO;
using System.Reflection;
using WeatherApp.DTOs;
using WeatherApp.DTOs.DTOs;
using WeatherApp.Helpers;
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

        public CoordinatesParsed execute(string json)
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
            CoordinatesParsed result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.coordinates.txt"));

            Assert.Equal("Gdańsk, Polska", result.Place);
        }

        [Fact]
        public void parse_latitude()
        {
            CoordinatesParsed result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.coordinates.txt"));

            Assert.Equal(54.35202520000001 , result.Latitude);
        }

        [Fact]
        public void parse_longitude()
        {
            CoordinatesParsed result = execute(ReadEmbededResourceFile("WeatherApp.UnitTests.TestData.coordinates.txt"));

            Assert.Equal(18.6466384, result.Longitude);
        }
    }
}
