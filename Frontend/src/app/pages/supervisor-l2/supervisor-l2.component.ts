import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Event } from '../../models/event';
import { Supervisor } from '../../models/supervisor';
import { Assignment } from '../../models/assignment';

@Component({
  selector: 'app-supervisor-l2',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './supervisor-l2.component.html',
  styleUrls: ['./supervisor-l2.component.css']
})
export class SupervisorL2Component implements OnInit {
  events: Event[] = [];
  supervisorsL2: Supervisor[] = [];
  selectedEventId: number | null = null;
  selectedSupervisorId: number | null = null;
  errorMessage = '';
  successMessage = '';

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.loadEvents();
    this.loadSupervisors();
  }

  loadEvents(): void {
    this.api.getEvents().subscribe({
      next: data => this.events = data,
      error: err => this.errorMessage = 'Error loading events'
    });
  }

  loadSupervisors(): void {
    this.api.getSupervisors().subscribe({
      next: data => {
        // Filter to only L2 supervisors
        this.supervisorsL2 = data.filter(sup => sup.level === 2);
      },
      error: err => this.errorMessage = 'Error loading supervisors'
    });
  }

  assignSupervisor(): void {
    if (!this.selectedEventId || !this.selectedSupervisorId) {
      this.errorMessage = 'Select both an event and a supervisor.';
      return;
    }
    const assignment: Assignment = {
      assignmentId: 0,
      eventId: this.selectedEventId,
      subEventId: null,
      supervisorId: this.selectedSupervisorId,
      laborerId: null,
      assignedRole: 'L2 Supervisor'
    };
    this.api.createAssignment(assignment).subscribe({
      next: () => {
        this.successMessage = 'Supervisor assigned successfully!';
        this.errorMessage = '';
      },
      error: err => this.errorMessage = 'Error assigning supervisor'
    });
  }
}
