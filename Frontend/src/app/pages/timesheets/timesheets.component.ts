import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TimeSheet } from '../../models/timeSheet';
import { ApiService } from '../../services/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-timesheets',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './timesheets.component.html',
  styleUrls: ['./timesheets.component.css']
})
export class TimesheetsComponent implements OnInit {
  timeSheets: TimeSheet[] = [];
  errorMessage = '';

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
}
