import { Component, Input, OnChanges } from '@angular/core';
import { CssVars } from 'ngx-css-variables';

@Component({
  selector: 'app-wind-arrow',
  templateUrl: './wind-arrow.component.html',
  styleUrls: ['./wind-arrow.component.css']
})
export class WindArrowComponent implements OnChanges {

  customCssVars: CssVars;

  @Input()
  previousDirection: number;
  @Input()
  speed: number;
  @Input()
  currentDirection: number;

  ngOnChanges() {
    this.customCssVars = {
      '--begin': this.previousDirection.toString() + 'deg',
      '--end': this.currentDirection.toString() + 'deg'
    };
  }
}
