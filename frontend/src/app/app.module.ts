import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; 
import { MatTableModule } from "@angular/material/table";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { MatIconModule } from "@angular/material/icon";
import { MatSelectModule } from "@angular/material/select";
import { MatRadioModule } from "@angular/material/radio";
import { MatButtonModule } from "@angular/material/button";
import { NgSelectModule } from "@ng-select/ng-select";

import { AppComponent } from './app.component';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { FactsaboutdogsComponent } from './components/factsaboutdogs/factsaboutdogs.component';
import { CountriesnatoComponent } from './components/countriesnato/countriesnato.component';
import { AgebynameComponent } from './components/agebyname/agebyname.component';
import { PricebitcoinComponent } from './components/pricebitcoin/pricebitcoin.component';
import { SeriesbigbangComponent } from './components/seriesbigbang/seriesbigbang.component';
import { MatSortModule } from '@angular/material/sort';

const appRoutes: Routes = [
  { path: '', component: MainpageComponent },
  { path: 'factsaboutdogs', component: FactsaboutdogsComponent },
  { path: 'countriesnato', component: CountriesnatoComponent },
  { path: 'agebyname', component: AgebynameComponent },
  { path: 'pricebitcoin', component: PricebitcoinComponent },
  { path: 'seriestheorybigbang', component: SeriesbigbangComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    MainpageComponent,
    FactsaboutdogsComponent,
    CountriesnatoComponent,
    AgebynameComponent,
    PricebitcoinComponent,
    SeriesbigbangComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatSelectModule,
    MatRadioModule,
    MatButtonModule,
    NgSelectModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
