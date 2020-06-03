import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { ChartsModule } from 'ng2-charts';


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
import { ChartsComponent } from './Components/charts/charts.component';
import { LineChartComponent } from './Components/line-chart/line-chart.component';

registerLocaleData(localePl);

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    SearchSettingsComponent,
    ForecastComponent,
    DailyForecastComponent,
    DisplayDirective,
    CapitalizeFirstPipe,
    ChartsComponent,
    LineChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ChartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
