import { Component, OnDestroy, OnInit } from "@angular/core";
import { ColDef, GridApi } from "ag-grid-community";
import { Subscription } from "rxjs";
import { CommoditiesService } from "../api/services/commodities.service";
import { TradeAction } from "../models/trade-action";

@Component({
  selector: "app-history",
  templateUrl: "./history.component.html",
  styleUrls: [],
})
export class HistoryComponent implements OnInit, OnDestroy {
  data: any[] = [];
  subscription: Subscription = new Subscription();

  gridOptions = {
    pagination: true,
    rowModelType: 'infinite',
    cacheBlockSize: 10,
    paginationPageSize: 10
  };

  constructor(private commoditiesService: CommoditiesService) {}

  ngOnInit(): void {
    this.subscription = this.commoditiesService
      .getTradeActions()
      .subscribe((tradeActions: TradeAction[]) => (this.data = tradeActions));
  }

  columns: ColDef[] = [
    { field: "modelName", sortable: true, filter: true },
    { field: "commodityName", sortable: true, filter: true },
    { field: "newTradeAction", sortable: true, filter: true },
  ];

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
