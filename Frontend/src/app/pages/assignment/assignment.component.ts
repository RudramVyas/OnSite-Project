import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Assignment } from '../../models/assignment';
import { SubEvent } from '../../models/subEvent';
import { Laborer } from '../../models/laborer';
import { Supervisor } from '../../models/supervisor';
import { Event } from '../../models/event';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-assignment',
  imports: [CommonModule, FormsModule],
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.css']
})
export class assignmentsComponent implements OnInit {
  constructor(private api: ApiService) { }

  assignments: Assignment[] = [];
  events: Event[] = [];
  subEvents: SubEvent[] = [];
  laborers: Laborer[] = [];
  supervisors: Supervisor[] = [];
  
  display: {
    id: number;
    event: string | null;
    subEvent: string | null;
    role: string;
    laborer: string | null;
    supervisor: string | null;
  }[] = [];

  errorMessage = '';
  successMessage = '';

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    forkJoin({
      assignments: this.api.getAssignments(),
      events: this.api.getEvents(),
      subEvents: this.api.getSubEvents(),
      laborers: this.api.getLaborers(),
      supervisors: this.api.getSupervisors()
    }).subscribe({
      next: (data) => {
        this.assignments = data.assignments;
        this.events = data.events;
        this.subEvents = data.subEvents;
        this.laborers = data.laborers;
        this.supervisors = data.supervisors;
        
        this.setDisplay();
      },
      error: (err) => {
        this.errorMessage = 'Error loading data';
        console.error('Data load error:', err);
      }
    });
  }
  setDisplay(): void {
    this.display = this.assignments.map(assignment => ({
      id: assignment.assignmentId,
      event: this.events.find(event => event.eventId === assignment.eventId)?.name || null,
      subEvent: this.subEvents.find(subEvent => subEvent.subEventId === assignment.subEventId)?.name || null,
      role: assignment.assignedRole,
      laborer: this.laborers.find(laborer => laborer.laborerId === assignment.laborerId)?.name || null,
      supervisor: this.supervisors.find(supervisor => supervisor.supervisorId === assignment.supervisorId)?.name || null
    }));
  }
  deleteAssignment(assignmentId: number): void {
    if (confirm('Are you sure you want to delete this assignment?')) {
      this.api.deleteAssignment(assignmentId).subscribe({
        next: () => {
          this.successMessage = 'Assignment deleted successfully!';
          this.errorMessage = '';
          // Reload data to refresh the display
          this.loadData();
        },
        error: (err) => {
          this.errorMessage = 'Error deleting assignment';
          console.error('Delete error:', err);
        }
      });
    }
  }
}
