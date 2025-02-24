import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimesheetLaborerComponent } from './timesheet-laborer.component';

describe('TimesheetLaborerComponent', () => {
  let component: TimesheetLaborerComponent;
  let fixture: ComponentFixture<TimesheetLaborerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TimesheetLaborerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimesheetLaborerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
