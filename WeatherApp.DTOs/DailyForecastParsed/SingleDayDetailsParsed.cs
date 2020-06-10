namespace WeatherApp.DTOs.DailyForecastParsed
{
    public class SingleDayDetailsParsed
    {
        public long Date { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double FeelsLikeTemperatureDay { get; set; }
        public double FeelsLikeTemperatureNight { get; set; }
        public long Pressure { get; set; }
        public long Humidity { get; set; }
        public double WindSpeed { get; set; }
        public long WindDirection { get; set; }
        public string WeatherSummary { get; set; }
        public string WeatherDescription { get; set; }
        public long CloudinessLevel { get; set; }
        public double? Rain { get; set; }
        public double? Snow { get; set; }
    }
}
