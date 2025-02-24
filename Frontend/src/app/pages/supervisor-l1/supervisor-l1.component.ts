import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Assignment } from '../../models/assignment';
import { SubEvent } from '../../models/subEvent';
import { Laborer } from '../../models/laborer';

@Component({
  selector: 'app-supervisor-l1',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './supervisor-l1.component.html',
  styleUrls: ['./supervisor-l1.component.css']
})
export class SupervisorL1Component implements OnInit {
  subEvents: SubEvent[] = [];
  laborers: Laborer[] = [];
  errorMessage = '';
  successMessage = '';

  selectedSubEventId: number | null = null;
  selectedLaborerId: number | null = null;

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.loadSubEvents();
    this.loadLaborers();
  }

  loadSubEvents(): void {
    this.api.getSubEvents().subscribe({
      next: data => this.subEvents = data,
      error: err => this.errorMessage = 'Error loading sub-events'
    });
  }

  loadLaborers(): void {
    this.api.getLaborers().subscribe({
      next: data => this.laborers = data.filter(lab => lab.isAvailable),
      error: err => this.errorMessage = 'Error loading laborers'
    });
  }

  assignLaborer(): void {
    if (!this.selectedSubEventId || !this.selectedLaborerId) {
      this.errorMessage = 'Please select both a sub-event and a laborer.';
      return;
    }
    const assignment: Assignment = {
      assignmentId: 0,
      eventId: null,
      subEventId: this.selectedSubEventId,
      supervisorId: null,
      laborerId: this.selectedLaborerId,
      assignedRole: 'Laborer'
    };
    this.api.createAssignment(assignment).subscribe({
      next: () => {
        this.successMessage = 'Laborer assigned successfully!';
        this.errorMessage = '';
        // Optionally, update the laborers list
        this.loadLaborers();
      },
      error: err => this.errorMessage = 'Error assigning laborer'
    });
  }
}
