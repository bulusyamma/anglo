import { NgModule } from "@angular/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MetricsComponent } from "./metrics.component";
import { CommoditiesFilterModule } from "../shared/common/commodities-filter.module";
import { MetricsDetailComponent } from "./detail/metrics-detail.component";
import { MatCardModule } from "@angular/material/card";

@NgModule({
  imports: [BrowserAnimationsModule, MatCardModule, CommoditiesFilterModule],
  declarations: [MetricsDetailComponent, MetricsComponent],
})
export class MetricsModule {}
