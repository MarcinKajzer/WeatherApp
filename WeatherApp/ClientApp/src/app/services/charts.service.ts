import { Injectable, OnChanges } from '@angular/core';
import * as moment from 'moment';
import 'moment/locale/pl';
import { ThreeHoursForecast } from '../Models/ThreeHoursForecast';
import { ThreeHoursDetails } from '../Models/ThreeHoursDetails';
import { ForecastService } from './forecast.service';
import { ExtractedWeatherProperties } from '../Models/ExtractedWeatherProperties';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChartsService {

  private selectedDay = 0;

  forecast: ThreeHoursForecast;

  dailyForecast = new Array<ThreeHoursDetails[]>();

  secondDayBeginingIndex: number;

  private extractedProps = new ExtractedWeatherProperties();
  extractedPropsObs = new BehaviorSubject<ExtractedWeatherProperties>(this.extractedProps);

  constructor(private forecastService: ForecastService) {
    this.forecastService.getThreeHoursForecast().subscribe(result => {
      this.forecast = result;
      this.splitData();
      this.extractProperties(this.selectedDay);
    });
  }

  selectDay(nr: number) {
    this.selectedDay = nr;
    this.extractProperties(this.selectedDay);
  }

  splitData() {
    this.dailyForecast.length = 0;
    this.dailyForecast.push(this.forecast.details.slice(0, 8));

    for (let i = 0; i < 8; i++) {
      if (moment.unix(this.forecast.details[i].date).format('L') !== moment.unix(this.forecast.details[i + 1].date).format('L')) {
        this.secondDayBeginingIndex = i + 1;
        break;
      }
    }

    for (let j = 0; j < 4; j++) {
      this.dailyForecast.push(this.forecast.details.
        slice(j * 8 + this.secondDayBeginingIndex, j * 8 + this.secondDayBeginingIndex + 8));
    }
  }

  extractProperties(selectedDay: number): void {

    this.extractedProps = new ExtractedWeatherProperties();
    for (let i = 0; i < 8; i++) {

      this.extractedProps.hours.push(moment.unix(this.dailyForecast[selectedDay][i].date).format('LT'));
      this.extractedProps.temperature.push(this.dailyForecast[selectedDay][i].temperature);
      this.extractedProps.feelsLikeTemperature.push(this.dailyForecast[selectedDay][i].feelsLikeTemperature);
      this.extractedProps.windSpeed.push(this.dailyForecast[selectedDay][i].windSpeed);
      this.extractedProps.windDirection.push(this.dailyForecast[selectedDay][i].windDirection);
      this.extractedProps.cloudinessLevel.push(this.dailyForecast[selectedDay][i].cloudinessLevel);
      this.extractedProps.humidity.push(this.dailyForecast[selectedDay][i].humidity);
      this.extractedProps.pressure.push(this.dailyForecast[selectedDay][i].pressure);
    }

    this.extractedPropsObs.next(this.extractedProps);

  }
}
