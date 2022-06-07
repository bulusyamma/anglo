import { NgModule } from "@angular/core";
import { HistoryComponent } from "./history.component";
import { AgGridModule } from "ag-grid-angular";
import { MatCardModule } from "@angular/material/card";

@NgModule({
  imports: [AgGridModule, MatCardModule],
  declarations: [HistoryComponent],
})
export class HistoryModule {}
