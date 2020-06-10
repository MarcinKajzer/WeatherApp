import { Injectable, OnChanges } from '@angular/core';
import * as moment from 'moment';
import 'moment/locale/pl';
import { ThreeHoursForecast } from '../Models/ThreeHoursForecast';
import { ThreeHoursDetails } from '../Models/ThreeHoursDetails';
import { ForecastService } from './forecast.service';
import { ExtractedWeatherProperties } from '../Models/ExtractedWeatherProperties';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChartsService {

  private selectedDay = 0;

  private forecast: ThreeHoursForecast;
  private dailyForecast = new Array<ThreeHoursDetails[]>();

  private selectedDayForecast = new BehaviorSubject<ExtractedWeatherProperties>(new ExtractedWeatherProperties());

  constructor(private forecastService: ForecastService) {
    this.forecastService.getThreeHoursForecast().subscribe(result => {
      this.forecast = result;
      this.splitDataIntoDays();
      this.extractSelectedDayForecast();
    });
  }

  selectDay(nr: number): void {
    this.selectedDay = nr;
    this.extractSelectedDayForecast();
  }

  splitDataIntoDays(): void {
    this.dailyForecast.length = 0;
    this.dailyForecast.push(this.forecast.details.slice(0, 8));

    let secondDayBeginingIndex;

    for (let i = 0; i < 8; i++) {
      const currentPeriodDate = moment.unix(this.forecast.details[i].date).format('L');
      const nextPeriodDate = moment.unix(this.forecast.details[i + 1].date).format('L');

      if (currentPeriodDate !== nextPeriodDate) {
        secondDayBeginingIndex = i + 1;
        break;
      }
    }

    for (let j = 0; j < 4; j++) {
      const beginingIndex = j * 8 + secondDayBeginingIndex;
      const endingIndex = j * 8 + secondDayBeginingIndex + 8;

      this.dailyForecast.push(this.forecast.details.slice(beginingIndex, endingIndex));
    }
  }

  extractSelectedDayForecast(): void {

    const extractedProps = new ExtractedWeatherProperties();

    for (let i = 0; i < 8; i++) {

      const singlePeriod = this.dailyForecast[this.selectedDay][i];

      extractedProps.hours.push(moment.unix(singlePeriod.date).format('LT'));
      extractedProps.temperature.push(singlePeriod.temperature);
      extractedProps.feelsLikeTemperature.push(singlePeriod.feelsLikeTemperature);
      extractedProps.windSpeed.push(singlePeriod.windSpeed);
      extractedProps.windDirection.push(singlePeriod.windDirection);
      extractedProps.cloudinessLevel.push(singlePeriod.cloudinessLevel);
      extractedProps.humidity.push(singlePeriod.humidity);
      extractedProps.pressure.push(singlePeriod.pressure);
    }

    this.selectedDayForecast.next(extractedProps);
  }

  getForecast(): Observable<ExtractedWeatherProperties> {
    return this.selectedDayForecast.asObservable();
  }

}
