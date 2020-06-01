import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchComponent } from './Components/search/search.component';
import { SearchSettingsComponent } from './Components/search-settings/search-settings.component';
import { ForecastComponent } from './Components/forecast/forecast.component';
import { DailyForecastComponent } from './Components/daily-forecast/daily-forecast.component';
import { DisplayDirective } from './Shared/display.directive';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';
import { CapitalizeFirstPipe } from './Shared/capitalize-first.pipe';

registerLocaleData(localePl);

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    SearchSettingsComponent,
    ForecastComponent,
    DailyForecastComponent,
    DisplayDirective,
    CapitalizeFirstPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
