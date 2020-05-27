import { Injectable, OnChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Forecast } from '../Models/Forecast';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  private place: string;
  private url: string;

  public forecast = new Subject<Forecast>();

  constructor(private httpClent: HttpClient) { }

  private setPlace(place: string) {
    this.place = place;
  }

  private setUrl() {
    this.url = 'https://localhost:44387/WeatherForecast?name=' + this.place;
  }

  getForecast(place: string) {

    this.setPlace(place);
    this.setUrl();

    this.httpClent.get<Forecast>(this.url).subscribe(result => {
      console.log(result);
      this.forecast.next(result);
    });

  }

}
