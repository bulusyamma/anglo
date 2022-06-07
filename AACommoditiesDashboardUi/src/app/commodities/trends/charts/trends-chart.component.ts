import { Component, Input, OnDestroy } from "@angular/core";
import { CommoditiesService } from "../../api/services/commodities.service";
import { Chart } from "angular-highcharts";
import { Subscription } from "rxjs";
import { ChartPoint } from "../../models/chart-point";

@Component({
  selector: "trends-chart",
  templateUrl: "./trends-chart.component.html",
  styleUrls: [],
})
export class TrendsChartComponent implements OnDestroy {
  @Input()
  set modelId(value: any) {
    if (value !== null) {
      this.subscription = this.commoditiesService
        .getChartData(value)
        .subscribe((chartData: ChartPoint[]) => {
          console.log(chartData);
          this.chartData = chartData;
          this.chart = new Chart({
            chart: {
              type: "spline",
            },
            title: {
              text: "Historical PnL",
            },
            credits: {
              enabled: false,
            },
            xAxis: {
              type: "datetime",
              dateTimeLabelFormats: {
                day: "%e/%b",
                week: "%e/%b",
                month: "%b/%y",
                year: "%Y",
              },
              title: {
                text: "Date",
              },
            },
            yAxis: {
              title: {
                text: "Value (£)",
              },
            },
            tooltip: {
              headerFormat: "<b>{series.name}</b><br>",
              pointFormat: "{point.x:%e/%b/%y}: {point.y:.2f} m",
            },
            series: [
              {
                name: "PnL",
                type: "spline",
                data: this.chartData.map((x) => {
                  const date = new Date(x.date);
                  console.log([
                    Date.UTC(date.getFullYear(), date.getMonth(), date.getDay()),
                    x.pnl,
                  ]);
                  return [
                    Date.UTC(date.getFullYear(), date.getMonth(), date.getDay()),
                    x.pnl,
                  ];
                }),
              },
            ],
          });
        });
    }
  }

  subscription: Subscription = new Subscription();
  
  chart: Chart = new Chart();
  chartData: ChartPoint[] = [];

  constructor(private commoditiesService: CommoditiesService) {}

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
