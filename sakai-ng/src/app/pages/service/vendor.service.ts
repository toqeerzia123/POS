import { Injectable } from '@angular/core';
import { AbpResponse } from './categories.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VendorService {

constructor(private http: HttpClient) { }
   getallVendors():Observable< AbpResponse<any[]>> {
        debugger
       return this.http.get<AbpResponse<any[]>>('https://localhost:44311/api/services/app/Vendor/GetAll');
      
    }
}
