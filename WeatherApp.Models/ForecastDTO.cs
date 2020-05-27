namespace WeatherApp.Models.DTOs
{
    public class ForecastDTO
    {
        public ThreeHoursForecastParsed ThreeHoursForecast { get; set; }

        public DailyForecastParsed DailyForecast { get; set; }
    }
}
