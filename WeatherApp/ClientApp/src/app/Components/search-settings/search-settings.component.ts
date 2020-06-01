import { Component, OnInit, DoCheck, KeyValueDiffers } from '@angular/core';
import { ForecastService } from 'src/app/services/forecast.service';
import { DisplayParams } from 'src/app/Models/DisplayParams';
import { DisplayService } from 'src/app/services/display.service';

@Component({
  selector: 'app-search-settings',
  templateUrl: './search-settings.component.html',
  styleUrls: ['./search-settings.component.css']
})
export class SearchSettingsComponent implements DoCheck {

  displayParams = new DisplayParams();

  constructor(private displayService: DisplayService) { }

  ngDoCheck(): void {
    this.displayService.changeDisplay(this.displayParams);
  }

}
