export interface Detail {
    date: number;
    cloudinessLevel: number;
    weatherSummary: string;
    weatherDescription: string;
    temperature: number;
    feelsLikeTemperature: number;
    temperatureMin: number;
    temperatureMax: number;
    pressure: number;
    humidity: number;
    rain?: number;
    snow?: any;
    windSpeed: number;
    windDirection: number;
}
