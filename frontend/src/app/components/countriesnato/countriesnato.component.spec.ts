import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountriesnatoComponent } from './countriesnato.component';

describe('CountriesnatoComponent', () => {
  let component: CountriesnatoComponent;
  let fixture: ComponentFixture<CountriesnatoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CountriesnatoComponent]
    });
    fixture = TestBed.createComponent(CountriesnatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
