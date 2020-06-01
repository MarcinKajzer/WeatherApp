import { Injectable } from '@angular/core';
import { DisplayParams } from '../Models/DisplayParams';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DisplayService {

  displayParamsObs = new BehaviorSubject<DisplayParams>(new DisplayParams());

  constructor() {
  }

  changeDisplay(displayParams: DisplayParams) {
    this.displayParamsObs.next(displayParams);
  }




}
