import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TimeSheet } from '../../models/timeSheet';
import { ApiService } from '../../services/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-timesheet-l1',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './timesheet-l1.component.html',
  styleUrls: ['./timesheet-l1.component.css']
})
export class TimesheetL1Component implements OnInit {
  timeSheets: TimeSheet[] = [];
  errorMessage = '';
  newTimeSheet: TimeSheet = {
    timeSheetId: 0,
    assignmentId: 0,
    hoursWorked: 0,
    workDate: new Date().toISOString()
  };

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.loadTimeSheets();
  }

  loadTimeSheets(): void {
    this.api.getTimeSheets().subscribe({
      next: data => this.timeSheets = data,
      error: err => this.errorMessage = 'Error loading timesheets'
    });
  }

  createTimeSheet(): void {
    if (!this.newTimeSheet.assignmentId || !this.newTimeSheet.hoursWorked) {
      this.errorMessage = 'Assignment and Hours are required';
      return;
    }
    this.api.createTimeSheet(this.newTimeSheet).subscribe({
      next: created => {
        this.timeSheets.push(created);
        this.newTimeSheet = { timeSheetId: 0, assignmentId: 0, hoursWorked: 0, workDate: new Date().toISOString() };
        this.errorMessage = '';
      },
      error: err => this.errorMessage = 'Error creating timesheet'
    });
  }

  deleteTimeSheet(id: number): void {
    this.api.deleteTimeSheet(id).subscribe({
      next: () => this.timeSheets = this.timeSheets.filter(ts => ts.timeSheetId !== id),
      error: err => this.errorMessage = 'Error deleting timesheet'
    });
  }
}
