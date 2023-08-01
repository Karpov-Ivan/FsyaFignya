import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgebynameComponent } from './agebyname.component';

describe('AgebynameComponent', () => {
  let component: AgebynameComponent;
  let fixture: ComponentFixture<AgebynameComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgebynameComponent]
    });
    fixture = TestBed.createComponent(AgebynameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
