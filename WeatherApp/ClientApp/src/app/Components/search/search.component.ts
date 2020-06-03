import { Component, OnInit } from '@angular/core';
import { ForecastService } from 'src/app/services/forecast.service';
import { ChartsService } from 'src/app/services/charts.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  place = 'Gdańsk';

  constructor(private forecastServce: ForecastService, private chartsService: ChartsService) { }

  ngOnInit(): void {
  }

  getForecast() {
    this.forecastServce.setPlace(this.place);
    this.chartsService.selectDay(0);
  }



}
