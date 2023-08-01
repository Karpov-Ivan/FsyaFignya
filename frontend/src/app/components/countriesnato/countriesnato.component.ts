import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

interface CountriesNato {
  countryName: string;
  dateOfEntry: number;
}

@Component({
  selector: 'app-countriesnato',
  templateUrl: './countriesnato.component.html',
  styleUrls: ['./countriesnato.component.css']
})

export class CountriesnatoComponent {

  constructor(private http: HttpClient) { }

  public countries: CountriesNato[] = [];

  getCountryNato() : Observable<CountriesNato[]> {
    return this.http.get<CountriesNato[]>("http://" + location.hostname + ":7243/api/CountryNato");
  }

  getData() {
    this.getCountryNato().subscribe(countries => this.countries = countries);
  }
}