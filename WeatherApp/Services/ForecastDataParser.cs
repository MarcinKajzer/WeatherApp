
using Newtonsoft.Json;
using WeatherApp.Models.ForecastModel;

namespace WeatherApp.Services
{
    public class ForecastDataParser
    {
        public Forecast ParseForecastData(string json)
        {
            return JsonConvert.DeserializeObject<Forecast>(json);
        }

    }
}
