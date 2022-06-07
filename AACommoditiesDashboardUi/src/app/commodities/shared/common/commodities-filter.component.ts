import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: 'commodities-filter',
  templateUrl: './commodities-filter.component.html',
  styleUrls: [],
})
export class CommoditiesFilterComponent {
  @Input()
  modelNames: string[] = [];
  @Input()
  commodityNames: string[] = [];

  @Output() modelNameChanged = new EventEmitter<string>();
  @Output() commodityNameChanged = new EventEmitter<string>();

  onModelNameChanged(value: string) {
    this.modelNameChanged.emit(value);
  }

  onCommodityNameChanged(value: string) {
    this.commodityNameChanged.emit(value);
  }
}
