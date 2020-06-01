import { Directive, Input, ElementRef, Renderer2, OnInit, DoCheck, OnDestroy } from '@angular/core';
import { ForecastService } from '../services/forecast.service';
import { Subscriber, Subscription } from 'rxjs';
import { DisplayParams } from '../Models/DisplayParams';
import { DisplayService } from '../services/display.service';

@Directive({
  selector: '[appDisplay]'
})
export class DisplayDirective implements DoCheck, OnDestroy, OnInit {

  @Input() param: string;
  paramValue: boolean;

  subscription: Subscription;

  constructor(private displayService: DisplayService, private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit(){
    this.subscription = this.displayService.displayParamsObs.subscribe(params => {
      this.paramValue = params[this.param];
    });
  }

  ngDoCheck(): void {
    const elm = this.el.nativeElement;
    if (this.paramValue) {
      this.renderer.setStyle(elm, 'display', 'block');
    }
    else {
      this.renderer.setStyle(elm, 'display', 'none');
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
