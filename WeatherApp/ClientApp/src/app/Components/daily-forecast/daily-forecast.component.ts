import { Component, OnInit, Input } from '@angular/core';
import { DailyForecast } from 'src/app/Models/DailyForecast';
import { DailyDetails } from 'src/app/Models/DailyDetails';

@Component({
  selector: 'app-daily-forecast',
  templateUrl: './daily-forecast.component.html',
  styleUrls: ['./daily-forecast.component.css']
})
export class DailyForecastComponent implements OnInit {

  @Input()
  forecast: DailyDetails;

  constructor() { }

  ngOnInit(): void {
  }

}
