import { Injectable, OnChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { Forecast } from '../Models/Forecast';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  private baseUrl = 'https://localhost:44387/WeatherForecast?place=';
  private url: string;

  private forecast = new Subject<Forecast>();

  constructor(private httpClent: HttpClient) { }

  setPlace(place: string) {

    this.url = this.baseUrl + place;

    this.httpClent.get<Forecast>(this.url).subscribe(result => {
     
      this.forecast.next(result);
    });

  }

  getForecast(): Observable<Forecast>{
    return this.forecast.asObservable();
  }

}
