namespace WeatherApp.DTOs.DTOs
{
    public class Forecast
    {
        public ThreeHoursForecastParsed ThreeHoursForecast { get; set; }
        public DailyForecastParsed DailyForecast { get; set; }
    }
}
