import { ComponentFixture, TestBed } from "@angular/core/testing";
import { CommoditiesFilterComponent } from "./commodities-filter.component";
import { CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

describe("CommoditiesFilterComponent", () => {
  let component: CommoditiesFilterComponent;
  let fixture: ComponentFixture<CommoditiesFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CommoditiesFilterComponent],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommoditiesFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
