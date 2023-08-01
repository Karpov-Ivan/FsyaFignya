import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

interface Series {
  seriesName: number;
}

@Component({
  selector: 'app-seriesbigbang',
  templateUrl: './seriesbigbang.component.html',
  styleUrls: ['./seriesbigbang.component.css']
})
export class SeriesbigbangComponent {

  constructor(private http: HttpClient) { }

  public series: Series[] = [];

  getSeriesBigBang() : Observable<Series[]> {
    return this.http.get<Series[]>("http://" + location.hostname + ":7243/api/ListOfSeriesTitlesOfTheBigBangTheory");
  }

  getData() {
    this.getSeriesBigBang().subscribe(series => this.series = series);
  }

}
