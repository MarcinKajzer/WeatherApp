using Newtonsoft.Json;

namespace WeatherApp.DTOs.ThreeHoursForecast
{
    public class MainParameters
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLikeTemperature { get; set; }

        [JsonProperty("temp_min")]
        public double TemperatureMin { get; set; }

        [JsonProperty("temp_max")]
        public double TemperatureMax { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }
    }

}
