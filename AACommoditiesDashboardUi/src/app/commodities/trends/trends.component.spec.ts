import { HttpClientTestingModule } from "@angular/common/http/testing";
import { CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { ComponentFixture, TestBed } from "@angular/core/testing";
import { of } from "rxjs";
import { CommoditiesService } from "../api/services/commodities.service";
import { ModelCommodity } from "../models/model-commodity";

import { TrendsComponent } from "./trends.component";

describe("TrendsComponent", () => {
  let component: TrendsComponent;
  let fixture: ComponentFixture<TrendsComponent>;
  let commoditiesService: CommoditiesService;

  const modelCommodities: ModelCommodity[] = [
    {
      id: 1,
      modelName: "S&P",
      commodityName: "Gold",
      position: 1,
      price: 5000,
      varAllocation: 10000,
      pnLDaily: 1,
      pnlLTD: 1,
    },
  ];

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TrendsComponent],
      imports: [HttpClientTestingModule],
      providers: [CommoditiesService],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrendsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    commoditiesService = TestBed.inject(CommoditiesService);
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });

  describe("On init", () => {
    it("should call getModelCommodities", () => {
      jest
        .spyOn(commoditiesService, "getModelCommodities")
        .mockReturnValue(of(modelCommodities) as any);
      component.ngOnInit();

      expect(commoditiesService.getModelCommodities).toHaveBeenCalled();
    });
  });
});
