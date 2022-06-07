import { Component, Input } from "@angular/core";
import { ModelCommodity } from "../../models/model-commodity";

@Component({
  selector: "metrics-detail",
  templateUrl: "./metrics-detail.component.html",
  styleUrls: [],
})
export class MetricsDetailComponent {
  @Input()
  model?: ModelCommodity;
}
