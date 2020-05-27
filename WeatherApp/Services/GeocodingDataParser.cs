using Newtonsoft.Json;
using WeatherApp.Models.DTOs;

namespace WeatherApp.Services
{
    public class GeocodingDataParser
    {
        public Coordinates ParseJsonToCoordinatesObject(string place)
        {
            return JsonConvert.DeserializeObject<Coordinates>(place);
        }
    }
}
