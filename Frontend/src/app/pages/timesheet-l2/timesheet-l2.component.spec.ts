import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimesheetL2Component } from './timesheet-l2.component';

describe('TimesheetL2Component', () => {
  let component: TimesheetL2Component;
  let fixture: ComponentFixture<TimesheetL2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TimesheetL2Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimesheetL2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
