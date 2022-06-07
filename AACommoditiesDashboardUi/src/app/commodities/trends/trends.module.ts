import { NgModule } from "@angular/core";
import { CommoditiesFilterModule } from "../shared/common/commodities-filter.module";
import { TrendsComponent } from "./trends.component";
import { TrendsChartModule } from "./charts/trends-chart.component.module";

@NgModule({
  imports: [
    CommoditiesFilterModule,
    TrendsChartModule,
  ],
  declarations: [TrendsComponent],
  exports: [TrendsComponent],
})
export class TrendsModule {}
