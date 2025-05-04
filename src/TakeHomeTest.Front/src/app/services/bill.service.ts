import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IBillResults } from '../pages/bills/bills.component';

@Injectable({
  providedIn: 'root'
})
export class BillService {
  
  private readonly url: string = 'http://localhost:5251/Bill/';
  
  constructor(private http: HttpClient) { }
  
  getBillResults() {
    return this.http.get<IBillResults[]>(this.url + 'GetBillsResults')
                    .pipe(map((response) => response)
    )
  }
}