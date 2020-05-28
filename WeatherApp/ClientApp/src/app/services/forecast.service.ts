import { Injectable, OnChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Forecast } from '../Models/Forecast';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  private baseUrl = 'https://localhost:44387/WeatherForecast?place=';
  private url: string;

  public forecast = new Subject<Forecast>();

  constructor(private httpClent: HttpClient) { }

  getForecast(place: string) {

    this.url = this.baseUrl + place;

    this.httpClent.get(this.url).subscribe(result => {
      console.log(result); // potem usunąć
      // this.forecast.next(result);
    });

  }

}
