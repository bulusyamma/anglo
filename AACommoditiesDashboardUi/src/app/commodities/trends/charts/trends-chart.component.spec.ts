import { HttpClientTestingModule } from "@angular/common/http/testing";
import { CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { ComponentFixture, TestBed } from "@angular/core/testing";
import { ChartModule } from "angular-highcharts";

import { TrendsChartComponent } from "./trends-chart.component";

describe("TrendsChartComponent", () => {
  let component: TrendsChartComponent;
  let fixture: ComponentFixture<TrendsChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TrendsChartComponent],
      imports: [HttpClientTestingModule, ChartModule],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrendsChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
