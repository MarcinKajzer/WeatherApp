import { Component } from '@angular/core';
import { ForecastService } from 'src/app/services/forecast.service';
import { DailyForecast } from 'src/app/Models/DailyForecast';
import { ChartsService } from 'src/app/services/charts.service';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent {

  forecast: DailyForecast;

  selectedDay = 0;

  constructor(private forecastService: ForecastService, private chartsService: ChartsService) {

    this.forecastService.getDailyForecast().subscribe(result => {
      this.forecast = result;
    });
  }

  choseDay(nr: number) {
    this.selectedDay = nr;
    this.chartsService.selectDay(nr);
  }
}
