using Newtonsoft.Json;
using WeatherApp.DTOs;
using WeatherApp.DTOs.DTOs;

namespace WeatherApp.Services
{
    public class GeocodingDataParser
    {
        public CoordinatesParsed ParseJsonToCoordinatesObject(string place)
        {
            Coordinates coord =  JsonConvert.DeserializeObject<Coordinates>(place);

            return new CoordinatesParsed
            {
                Latitude = coord.Details[0].Geometry.Location.Latitude,
                Longitude = coord.Details[0].Geometry.Location.Longitude,
                Place =coord.Details[0].FormattedAddress
            };
        }
    }
}
