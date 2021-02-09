import { Component, Input, OnChanges } from '@angular/core';
import { DailyDetails } from 'src/app/Models/DailyDetails';
import { CssVars } from 'ngx-css-variables';

@Component({
  selector: 'app-daily-forecast',
  templateUrl: './daily-forecast.component.html',
  styleUrls: ['./daily-forecast.component.css']
})
export class DailyForecastComponent implements OnChanges {

  @Input() forecast: DailyDetails;

  currentDate = new Date();

  customCssVars: CssVars;

  ngOnChanges() {
    this.customCssVars = {
      '--direction': this.forecast.windDirection + 'deg'
    };
  }
}
