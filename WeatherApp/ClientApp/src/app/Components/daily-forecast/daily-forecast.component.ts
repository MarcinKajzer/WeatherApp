import { Component, OnInit, Input } from '@angular/core';
import { DailyDetails } from 'src/app/Models/DailyDetails';

@Component({
  selector: 'app-daily-forecast',
  templateUrl: './daily-forecast.component.html',
  styleUrls: ['./daily-forecast.component.css']
})
export class DailyForecastComponent {

  @Input()
  forecast: DailyDetails;

  currentDate = new Date();

  constructor() { }



}
