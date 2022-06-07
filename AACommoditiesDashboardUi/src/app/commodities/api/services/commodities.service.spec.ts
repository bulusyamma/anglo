import { TestBed } from "@angular/core/testing";
import {
  HttpTestingController,
  HttpClientTestingModule,
} from "@angular/common/http/testing";

import { CommoditiesService } from "./commodities.service";
import { HttpClient } from "@angular/common/http";
import { ModelCommodity } from "../../models/model-commodity";
import { environment } from "src/environments/environment";

describe("CommoditiesService", () => {
  let service: CommoditiesService;
  let httpMock: HttpTestingController;
  let httpClient: HttpClient;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CommoditiesService],
    });
    service = TestBed.inject(CommoditiesService);
    httpMock = TestBed.inject(HttpTestingController);
    httpClient = TestBed.inject(HttpClient);
  });

  it("be able to retrieve model commodities from the API via GET", () => {
    const mockData: ModelCommodity[] = [
      {
        id: 1,
        modelName: "S&P",
        commodityName: "Gold",
        position: 1,
        varAllocation: 1000,
        price: 1234.5,
        pnlLTD: 10,
        pnLDaily: 10,
      },
    ];

    service
      .getModelCommodities()
      .subscribe((result) => expect(result).toBeTruthy());

    httpClient.get(environment.commoditiesApi).subscribe(() => {});
    const request = httpMock.expectOne(environment.commoditiesApi);

    expect(request.request.method).toBe("GET");
    request.flush(mockData);
  });

  afterEach(() => {
    httpMock.verify();
  });
});
