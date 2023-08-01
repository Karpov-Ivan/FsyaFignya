import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { FormBuilder, FormGroup } from '@angular/forms';

interface AgeByName {
  name: string;
  age: number;
  country: string;
}

interface Country {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-agebyname',
  templateUrl: './agebyname.component.html',
  styleUrls: ['./agebyname.component.css']
})

export class AgebynameComponent {

  public dataForm: FormGroup; 

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.dataForm = this.fb.group({
      firstname: '',
      country: [null]
    });
   }

  public ages: AgeByName[] = [];

  getAgeByName() : Observable<AgeByName[]> {
    const firstname: string = this.dataForm.get('firstname')?.value;
    var country: string = this.dataForm.get('country')?.value;

    if (firstname == '' || country == null) {
      alert('Введите значения');
    }

    if (country == '1') {
      country = "ru";
    } else if (country == '2') {
      country = "us";
    } else if (country == '3') {
      country = "fr";
    } else if (country == '4') {
      country = "it";
    } else if (country == '5') {
      country = "es";
    } else if (country == '6') {
      country = "ir";
    } else if (country == '7') {
      country = "by";
    } else if (country == '8') {
      country = "ar";
    }

    const link: string = "http://" + location.hostname + ":7243/api/AgeByNameOrCountry/" + firstname + '/' + country;
    return this.http.get<AgeByName[]>(link);
  }

  getData() {
    this.getAgeByName().subscribe(ages => this.ages = ages);
  }

  countries = [
    { id: 1, name: "ru" },
    { id: 2, name: "us" },
    { id: 3, name: "fr" },
    { id: 4, name: "it" },
    { id: 5, name: "es" },
    { id: 6, name: "ir" },
    { id: 7, name: "by" },
    { id: 8, name: "ar" },
  ];

  selected = [{ id: 1, name: "ru" }];
}
