import { Component, OnInit } from '@angular/core';
import { ForecastService } from 'src/app/services/forecast.service';
import { PlaceInfo } from 'src/app/Models/PlaceInfo';

@Component({
  selector: 'app-place-info',
  templateUrl: './place-info.component.html',
  styleUrls: ['./place-info.component.css']
})
export class PlaceInfoComponent implements OnInit {

  placeInfo: PlaceInfo;
  currentDate = new Date();

  constructor(private forecastService: ForecastService) {
    this.forecastService.getPlaceInfo().subscribe(result => {
      this.placeInfo = result;
      this.currentDate = new Date();
    });
  }

  ngOnInit(): void {
  }

}
