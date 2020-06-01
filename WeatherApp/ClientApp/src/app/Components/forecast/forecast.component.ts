import { Component, OnInit } from '@angular/core';
import { Forecast } from 'src/app/Models/Forecast';
import { ForecastService } from 'src/app/services/forecast.service';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent implements OnInit {

  forecast: Forecast;

  constructor(private forecastService: ForecastService) {

    this.forecastService.getForecast().subscribe(result => {
      this.forecast = result;
    });

  }

  aaa(){
    console.log(this.forecast);
  }


  ngOnInit(): void {
  }

}
