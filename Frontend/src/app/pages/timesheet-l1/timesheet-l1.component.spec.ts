import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimesheetL1Component } from './timesheet-l1.component';

describe('TimesheetL1Component', () => {
  let component: TimesheetL1Component;
  let fixture: ComponentFixture<TimesheetL1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TimesheetL1Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimesheetL1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
