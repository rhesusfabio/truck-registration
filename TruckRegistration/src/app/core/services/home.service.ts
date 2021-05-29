import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable()
export class HomeService {

    baseApi: string;

    constructor(private http: Http) {

        this.baseApi = "http://localhost:63996";

    }


    GetHomeMessage(): Observable<any[]> {
        return this.http.get(`${this.baseApi}/api/default`)
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'))
    }

    GetTruckList(): Observable<any[]> {
        return this.http.get(`api/truck`)
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'))
    }

    CreateTruck(truck: any): Observable<any[]> {
        return this.http.post(`api/truck`, truck)
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error))
    }

    EditTruck(truck: any): Observable<any[]> {
        return this.http.put(`api/truck/${truck.Id}`, truck)
            .catch((error: any) => Observable.throw(error))
    }

    RemoveTruck(truck: any): Observable<any[]> {
        return this.http.delete(`api/truck/${truck}`, truck)
            .catch((error: any) => Observable.throw(error))
    }

}