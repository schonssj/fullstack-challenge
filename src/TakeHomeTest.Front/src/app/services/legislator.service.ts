import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILegislatorVotes } from '../pages/legislator/legislator.component';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LegislatorService {

  private readonly url: string = 'http://localhost:5251/Legislator/';
    
  constructor(private http: HttpClient) {}

  getLegislatorsVotes() {
    return this.http.get<ILegislatorVotes[]>(this.url + 'GetLegislatorsVotes')
                    .pipe(map((response) => response)
    )
  }
}