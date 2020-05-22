using Newtonsoft.Json;
using WeatherApp.Models.Coordinates;

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
