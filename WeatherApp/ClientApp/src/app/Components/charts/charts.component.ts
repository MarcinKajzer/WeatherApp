import { Component } from '@angular/core';

import { ChartsService } from 'src/app/services/charts.service';
import { ExtractedWeatherProperties } from 'src/app/Models/ExtractedWeatherProperties';
import { ChartDataSets } from 'chart.js';


@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.css']
})
export class ChartsComponent {

  xAxes: string[];
  chartData: ChartDataSets[];

  constructor(private chartService: ChartsService) {
    this.chartService.extractedPropsObs.subscribe(result => {

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

