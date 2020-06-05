import { Component, OnInit, ViewChild, Input, OnChanges, OnDestroy } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Label, Color, BaseChartDirective } from 'ng2-charts';
import * as pluginAnnotations from 'chartjs-plugin-annotation';
import { DisplayService } from 'src/app/services/display.service';
import { Subscriber, Subscription } from 'rxjs';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnChanges, OnDestroy {

  @Input()
  data: {};
  @Input()
  xAxes: string[];
  @Input()
  optionalData: {};

  sub: Subscription;

  public lineChartData: ChartDataSets[] = [];
  public lineChartLabels: Label[] = [];

  public lineChartOptions: ChartOptions = {
    responsive: true,
    scales: {
      xAxes: [{}],
      yAxes: [
        {
          id: 'y-axis-0',
          position: 'left',
        },
      ]
    },
  };

  public lineChartColors: Color[] = [
    {
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    {
      backgroundColor: 'rgba(77,83,96,0.2)',
      borderColor: 'rgba(77,83,96,1)',
      pointBackgroundColor: 'rgba(77,83,96,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)'
    }
  ];

  public lineChartLegend = true;
  public lineChartType = 'line';
  public lineChartPlugins = [pluginAnnotations];

  @ViewChild(BaseChartDirective, { static: true }) chart: BaseChartDirective;

  constructor(private displayService: DisplayService) {
    this.sub = this.displayService.displayParamsObs.subscribe(result => {
      if (this.lineChartData[1] !== undefined) {
        this.chart.hideDataset(1, !result.feelsLikeTemp);
      }
    });
  }

  ngOnChanges(): void {
    this.lineChartData = [];
    this.lineChartData.push(this.data);

    if (this.optionalData !== undefined) {
      this.lineChartData.push(this.optionalData);
    }

    this.lineChartLabels = [];
    this.lineChartLabels = this.xAxes;

  }

  public hideOne(nr: number) {
    const isHidden = this.chart.isDatasetHidden(nr);
    this.chart.hideDataset(nr, !isHidden);
  }

  public changeChartType(): void {
    this.lineChartType = this.lineChartType === 'bar' ? 'line' : 'bar';
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
