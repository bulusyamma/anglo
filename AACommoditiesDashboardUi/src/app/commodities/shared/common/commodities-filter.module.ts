import { NgModule } from "@angular/core";
import { NoopAnimationsModule } from "@angular/platform-browser/animations";
import { MatSelectModule } from "@angular/material/select";
import { CommoditiesFilterComponent } from "./commodities-filter.component";

@NgModule({
  imports: [MatSelectModule, NoopAnimationsModule],
  declarations: [CommoditiesFilterComponent],
  exports: [CommoditiesFilterComponent],
})
export class CommoditiesFilterModule {}
