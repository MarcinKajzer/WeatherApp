import { Injectable } from '@angular/core';
import { DisplayParams } from '../Models/DisplayParams';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DisplayService {

  private displayParams = new BehaviorSubject<DisplayParams>(new DisplayParams());

  setParams(displayParams: DisplayParams) {
    this.displayParams.next(displayParams);
  }

  getParams(){
    return this.displayParams.asObservable();
  }
}
