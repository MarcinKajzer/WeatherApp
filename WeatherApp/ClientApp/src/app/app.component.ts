import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  forecast: Forecast;
  place = 'Warszawa';

  url = 'https://localhost:44387/WeatherForecast?name=' + this.place;


  constructor(private httpClient: HttpClient) { }

  getForecast() {
    this.url = 'https://localhost:44387/WeatherForecast?name=' + this.place;

    this.httpClient.get(this.url).subscribe((result) => {
      console.log(result);
    });

  }


}



export interface PlaceInfo {
  city: string;
  country: string;
  sunrise: number;
  sunset: number;
}

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

export interface Forecast {
  placeInfo: PlaceInfo;
  details: Detail[];
}




