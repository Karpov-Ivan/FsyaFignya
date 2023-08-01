import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

interface FactsAboutDogs {
  factAboutDogs: string;
}

@Component({
  selector: 'app-factsaboutdogs',
  templateUrl: './factsaboutdogs.component.html',
  styleUrls: ['./factsaboutdogs.component.css']
})

export class FactsaboutdogsComponent {

  constructor(private http: HttpClient) { }

  public facts: FactsAboutDogs[] = [];

  getFactsAboutDogs() : Observable<FactsAboutDogs[]> {
    return this.http.get<FactsAboutDogs[]>("http://" + location.hostname + ":7243/api/FactsAboutDogs/5");
  }

  getData() {
    this.getFactsAboutDogs().subscribe(facts => this.facts = facts);
  }
}
