import { Component } from '@angular/core';
import { ChartsService } from 'src/app/services/charts.service';
import { ChartDataSets } from 'chart.js';


@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.css']
})
export class ChartsComponent {

  xAxes: string[];
  chartData: ChartDataSets[];

  windSpeed: number[];
  windDirection: number[];
  previousDirection: number[] = [0, 0, 0, 0, 0, 0, 0, 0];
  hours: string[];

  constructor(private chartService: ChartsService) {
    this.chartService.getForecast().subscribe(result => {

      this.windSpeed = result.windSpeed;
      this.hours = result.hours;

      if (this.windDirection !== undefined && this.windDirection.length !== 0) {
        this.previousDirection = this.windDirection;
      }

      this.windDirection = result.windDirection;

      this.xAxes = result.hours;

      this.chartData = [
        { data: result.temperature, label: 'Temperatura rzeczywista °C ' },
        { data: result.feelsLikeTemperature, label: 'Temperatura odczuwalna °C' },
        { data: result.cloudinessLevel, label: 'Zachmurzenie %' },
        { data: result.humidity, label: 'Wilgotność %' },
        { data: result.pressure, label: 'Ciśnienie hPs' },
      ];
    });
  }
}

