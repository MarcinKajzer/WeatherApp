import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { CssVarsModule } from 'ngx-css-variables';
import { AgmCoreModule} from '@agm/core';

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
import { WindChartComponent } from './Components/wind-chart/wind-chart.component';
import { WindArrowComponent } from './Components/wind-arrow/wind-arrow.component';
import { PlaceInfoComponent } from './Components/place-info/place-info.component';

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
    LineChartComponent,
    WindChartComponent,
    WindArrowComponent,
    PlaceInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ChartsModule,
    CssVarsModule.forRoot(),
    AgmCoreModule.forRoot({
      apiKey : 'YOUR_GOOGLE_API_KEY',
      libraries: ['places']
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
