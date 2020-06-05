import { Injectable, OnChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable, BehaviorSubject } from 'rxjs';
import { Forecast } from '../Models/Forecast';
import { DisplayParams } from '../Models/DisplayParams';
import { DailyForecast } from '../Models/DailyForecast';
import { ThreeHoursDetails } from '../Models/ThreeHoursDetails';
import { ThreeHoursForecast } from '../Models/ThreeHoursForecast';
import { PlaceInfo } from '../Models/PlaceInfo';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  private baseUrl = 'https://localhost:44387/WeatherForecast/GetByPlace?place=';
  private url: string;

  private dailyForecast = new Subject<DailyForecast>();
  private threeHoursForecast = new Subject<ThreeHoursForecast>();
  private placeInfo = new Subject<PlaceInfo>();

  constructor(private httpClent: HttpClient) {
    this.setPlace('Gdańsk');
  }

  setPlace(place: string) {
    this.url = this.baseUrl + place;
    
    this.httpClent.get<Forecast>(this.url).subscribe(result => {
      this.dailyForecast.next(result.dailyForecast);
      this.threeHoursForecast.next(result.threeHoursForecast);
      this.placeInfo.next(result.threeHoursForecast.placeInfo);
    });
  }

  getDailyForecast(): Observable<DailyForecast> {
    return this.dailyForecast.asObservable();
  }

  getThreeHoursForecast(): Observable<ThreeHoursForecast> {
    return this.threeHoursForecast.asObservable();
  }

  getPlaceInfo(): Observable<PlaceInfo>{
    return this.placeInfo.asObservable();
  }

}
