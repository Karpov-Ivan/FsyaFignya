import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PricebitcoinComponent } from './pricebitcoin.component';

describe('PricebitcoinComponent', () => {
  let component: PricebitcoinComponent;
  let fixture: ComponentFixture<PricebitcoinComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PricebitcoinComponent]
    });
    fixture = TestBed.createComponent(PricebitcoinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
