import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { CommoditiesService } from "../api/services/commodities.service";
import { ModelCommodity } from "../models/model-commodity";

@Component({
  selector: "app-metrics",
  templateUrl: "./metrics.component.html",
  styleUrls: [],
})
export class MetricsComponent implements OnInit, OnDestroy {
  private _selectedModelName!: string;
  private _selectedCommodityName!: string;

  subscription: Subscription = new Subscription();
  selectedModel?: ModelCommodity;

  modelNames: string[] = [];
  commodityNames: string[] = [];
  models: ModelCommodity[] = [];

  constructor(private commoditiesService: CommoditiesService) {}

  ngOnInit(): void {
    this.subscription = this.commoditiesService
      .init()
      .subscribe((models: ModelCommodity[]) => {
        this.models = models;

        this.modelNames = Array.from(
          new Set(models.map((item) => item.modelName))
        );

        this.commodityNames = Array.from(
          new Set(models.map((item) => item.commodityName))
        );

        this._selectedModelName = this.modelNames[0];
        this._selectedCommodityName = this.commodityNames[0];
        this.selectedModel = this.getModel();
      });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  modelNameChanged(event: string) {
    this._selectedModelName = event;
    this.selectedModel = this.getModel();
  }

  commodityNameChanged(event: string) {
    this._selectedCommodityName = event;
    this.selectedModel = this.getModel();
  }

  private getModel() {
    return this.models.find(
      (x) =>
        x.modelName === this._selectedModelName &&
        x.commodityName === this._selectedCommodityName
    );
  }
}
