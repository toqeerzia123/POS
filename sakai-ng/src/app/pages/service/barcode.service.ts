import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BarcodeService {

   constructor(private http: HttpClient) {}
   getBarcodeData():Observable<any> {
       return this.http.get<any>('https://localhost:44311/api/services/app/BarCode/GetBarcodesGrouped');
      
    }

 generateBarcode(productName: string, productCode: string, price: number) {
    const headers = new HttpHeaders({
      'accept': 'text/plain',
      // Add a real auth token if needed, or remove if null
      'Authorization': 'Bearer YOUR_TOKEN_HERE',
      // Replace this with your actual token or use HttpClientXsrfModule
      'X-XSRF-TOKEN': 'CfDJ8D7GyOLBABtAovsj4AYofb9o95sCJyHdg6WoUjxB3uYkS7v9KdxhkCPzRmbnc26rHQAtI4kRp5Ocrz2SXnB6Mo_fFHDq4Id0DY8-CZm6V0GzXeSn8nvrjWYkO_R5EluCPcqyJLMIiB4UhnSEllxkdZA',
    });

    const url = `https://localhost:44311/api/services/app/BarCode/GenerateBarcodeWithDetails?productName=${productName}&productCode=${productCode}&price=${price}`;
    return this.http.post(url, '', { headers});
  }
      
}
