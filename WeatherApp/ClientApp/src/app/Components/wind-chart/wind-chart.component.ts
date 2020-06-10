import { Component, Input } from '@angular/core';

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
}
