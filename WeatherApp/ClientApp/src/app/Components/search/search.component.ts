import { Component, OnInit } from '@angular/core';
import { ForecastService } from 'src/app/services/forecast.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  place = 'Gdańsk';

  constructor(private forecastServce: ForecastService) { }

  ngOnInit(): void {
  }

  getForecast() {
    this.forecastServce.setPlace(this.place);
  }



}
