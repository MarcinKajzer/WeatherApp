using Newtonsoft.Json;
using WeatherApp.Models;
using WeatherApp.Models.DTOs;

namespace WeatherApp.Services
{
    public class GeocodingDataParser
    {
        public CoordinatesParsed ParseJsonToCoordinatesObject(string place)
        {
            Coordinates coord =  JsonConvert.DeserializeObject<Coordinates>(place);

            return new CoordinatesParsed
            {
                Latitude = coord.Results[0].Geometry.Location.Latitude,
                Longitude = coord.Results[0].Geometry.Location.Longitude,
                Place =coord.Results[0].FormattedAddress
            };
        }
    }
}
