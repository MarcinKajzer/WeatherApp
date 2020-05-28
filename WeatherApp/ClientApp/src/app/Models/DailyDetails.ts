export interface DailyDetails {
    date: number;
    temperatureMin: number;
    temperatureMax: number;
    feelsLikeTemperatureDay: number;
    feelsLikeTemperatureNight: number;
    pressure: number;
    humidity: number;
    windSpeed: number;
    windDirection: number;
    weatherSummary: string;
    weatherDescription: string;
    clouds: number;
    rain?: number;
    snow?: any;
}