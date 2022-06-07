import { NgModule } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { ChartModule } from "angular-highcharts";
import { TrendsChartComponent } from "./trends-chart.component";

@NgModule({
  imports: [ChartModule, MatCardModule],
  declarations: [TrendsChartComponent],
  exports: [TrendsChartComponent],
})
export class TrendsChartModule {}
