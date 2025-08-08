import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbpResponse } from './categories.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocationsService {

constructor(private http: HttpClient) { }
   getallLocations():Observable< AbpResponse<any[]>> {
        debugger
       return this.http.get<AbpResponse<any[]>>('https://localhost:44311/api/services/app/Location/GetAll');
      
    }
}
