import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeriesbigbangComponent } from './seriesbigbang.component';

describe('SeriesbigbangComponent', () => {
  let component: SeriesbigbangComponent;
  let fixture: ComponentFixture<SeriesbigbangComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeriesbigbangComponent]
    });
    fixture = TestBed.createComponent(SeriesbigbangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
