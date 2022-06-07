import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { of, Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ModelCommodity } from 'src/app/commodities/models/model-commodity';
import { ChartPoint } from 'src/app/commodities/models/chart-point';
import { TradeAction } from 'src/app/commodities/models/trade-action';

@Injectable({
    providedIn: 'root'
})
export class CommoditiesService {
    private baseUrl = environment.commoditiesApi;

    private commodityModels = new BehaviorSubject<ModelCommodity[]>([]);

    private httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
        })
    };

    constructor(private http: HttpClient) { }

    init(): Observable<ModelCommodity[]> {
        var observable =this.http.get<ModelCommodity[]>(this.baseUrl, this.httpOptions)
        .pipe(
            tap(_ => console.log('CommoditiesService: get model commodities')),
            catchError(this.handleError<ModelCommodity[]>('getCommodityModels', []))
        );
        observable.subscribe(x => this.commodityModels.next(x));
        return observable;
    }

    getModelCommodities(): Observable<ModelCommodity[]> {
        return this.commodityModels.asObservable();
    }

    getChartData(id: number): Observable<ChartPoint[]> {
        return this.http.get<ChartPoint[]>(this.baseUrl + '/chartData/' + id, this.httpOptions)
            .pipe(
                tap(_ => console.log('CommoditiesService: get chart data')),
                catchError(this.handleError<ChartPoint[]>('getChartData', []))
            );
    }

    getTradeActions(): Observable<TradeAction[]> {
        return this.http.get<TradeAction[]>(this.baseUrl + '/tradeActions', this.httpOptions)
            .pipe(
                tap(_ => console.log('CommoditiesService: get trade action')),
                catchError(this.handleError<TradeAction[]>('getTradeActions', []))
            );
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            return of(result as T);
        };
    }
} 