import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HistoryComponent } from "./history/history.component";
import { MetricsComponent } from "./metrics/metrics.component";
import { TrendsComponent } from "./trends/trends.component";

const routes: Routes = [
  { path: "history", component: HistoryComponent },
  { path: "metrics", component: MetricsComponent },
  { path: "trends", component: TrendsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class CommoditiesRoutingModule {}
