import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { CssVars } from 'ngx-css-variables';

@Component({
  selector: 'app-wind-chart',
  templateUrl: './wind-chart.component.html',
  styleUrls: ['./wind-chart.component.css']
})
export class WindChartComponent {

  @Input()
  windSpeed: number[];
  @Input()
  windDirection: number[];
  @Input()
  previousDirection: number[];
  @Input()
  hours: string[];

  constructor() { }

}
