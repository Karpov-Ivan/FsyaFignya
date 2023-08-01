import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

interface Price {
  price: number;
  requestDate: string;
}

@Component({
  selector: 'app-pricebitcoin',
  templateUrl: './pricebitcoin.component.html',
  styleUrls: ['./pricebitcoin.component.css']
})
export class PricebitcoinComponent {

  constructor(private http: HttpClient) { }

  public prices: Price[] = [];

  getPriceBitcoin() : Observable<Price[]> {
    return this.http.get<Price[]>("http://" + location.hostname + ":7243/api/InformationAboutBitcoin");
  }

  getData() {
    this.getPriceBitcoin().subscribe(prices => this.prices = prices);
  }
}
