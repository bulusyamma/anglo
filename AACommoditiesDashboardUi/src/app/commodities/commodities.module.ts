import { NgModule } from "@angular/core";
import { CommoditiesRoutingModule } from "./commodities-routing.module";
import { CommoditiesService } from "./api/services/commodities.service";
import { CommoditiesFilterModule } from "./shared/common/commodities-filter.module";
import { HistoryModule } from "./history/history.component.module";
import { MetricsModule } from "./metrics/metrics.module";
import { TrendsModule } from "./trends/trends.module";

@NgModule({
  imports: [
    CommoditiesRoutingModule,
    CommoditiesFilterModule,
    HistoryModule,
    MetricsModule,
    TrendsModule,
  ],
  declarations: [],
  providers: [CommoditiesService],
})
export class CommoditiesModule {}
