import { Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { Forecast } from '../Models/Forecast';
import { DailyForecast } from '../Models/DailyForecast';
import { ThreeHoursForecast } from '../Models/ThreeHoursForecast';
import { PlaceInfo } from '../Models/PlaceInfo';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  private baseUrl = 'https://localhost:44387/api/forecast?place=';

  private dailyForecast = new Subject<DailyForecast>();
  private threeHoursForecast = new Subject<ThreeHoursForecast>();
  private placeInfo = new Subject<PlaceInfo>();

  constructor(private httpClent: HttpClient) {
    this.setPlace('Gdańsk');
  }

  setPlace(place: string) {
    const url = this.baseUrl + place;

    this.httpClent.get<Forecast>(url).subscribe(result => {
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

  getPlaceInfo(): Observable<PlaceInfo> {
    return this.placeInfo.asObservable();
  }

}
