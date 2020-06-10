import { Component, OnInit, ViewChild, ElementRef, NgZone } from '@angular/core';
import { ForecastService } from 'src/app/services/forecast.service';
import { MapsAPILoader } from '@agm/core';
import { } from 'googlemaps';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  place = 'Gdańsk';
  @ViewChild('search') public searchFiled: ElementRef;

  constructor(private forecastServce: ForecastService, private mapsAPILoader: MapsAPILoader, private ngZone: NgZone) { }

  ngOnInit(): void {
    this.mapsAPILoader.load().then(() => {
      const autocomplete = new google.maps.places.Autocomplete(this.searchFiled.nativeElement, { types: ['geocode'] });
    });
  }

  getForecast() {
    this.forecastServce.setPlace(this.searchFiled.nativeElement.value);
  }
}
