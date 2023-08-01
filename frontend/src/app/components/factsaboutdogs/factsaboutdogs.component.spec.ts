import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FactsaboutdogsComponent } from './factsaboutdogs.component';

describe('FactsaboutdogsComponent', () => {
  let component: FactsaboutdogsComponent;
  let fixture: ComponentFixture<FactsaboutdogsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FactsaboutdogsComponent]
    });
    fixture = TestBed.createComponent(FactsaboutdogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
