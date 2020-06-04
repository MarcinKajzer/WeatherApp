import { Component, OnInit, DoCheck, KeyValueDiffers, HostListener } from '@angular/core';
import { DisplayParams } from 'src/app/Models/DisplayParams';
import { DisplayService } from 'src/app/services/display.service';

@Component({
  selector: 'app-search-settings',
  templateUrl: './search-settings.component.html',
  styleUrls: ['./search-settings.component.css']
})
export class SearchSettingsComponent implements DoCheck, OnInit {

  isColapsed = true;
  displayParams = new DisplayParams();
  windowWidth = window.innerWidth;

  constructor(private displayService: DisplayService) { }

  ngOnInit(){
    this.colapse();
  }

  ngDoCheck(): void {
    this.displayService.changeDisplay(this.displayParams);
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.colapse();
  }

  private colapse() {
    if (window.innerWidth > 1200) {
      this.isColapsed = false;
    }
    else {
      this.isColapsed = true;
    }
    this.windowWidth = window.innerWidth;
  }
}
