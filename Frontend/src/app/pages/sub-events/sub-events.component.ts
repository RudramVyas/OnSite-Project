import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SubEvent } from '../../models/subEvent';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-sub-events',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sub-events.component.html',
  styleUrls: ['./sub-events.component.css']
})
export class SubEventsComponent implements OnInit {
  subEvents: SubEvent[] = [];
  errorMessage = '';
  newSubEvent: SubEvent = {
    subEventId: 0,
    eventId: 0,
    name: '',
    description: ''
  };

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.loadSubEvents();
  }

  loadSubEvents(): void {
    this.api.getSubEvents().subscribe({
      next: data => this.subEvents = data,
      error: err => this.errorMessage = 'Error loading sub-events'
    });
  }

  createSubEvent(): void {
    if (!this.newSubEvent.eventId || !this.newSubEvent.name) {
      this.errorMessage = 'Event and Name are required';
      return;
    }
    this.api.createSubEvent(this.newSubEvent).subscribe({
      next: created => {
        this.subEvents.push(created);
        this.newSubEvent = { subEventId: 0, eventId: 0, name: '', description: '' };
        this.errorMessage = '';
      },
      error: err => this.errorMessage = 'Error creating sub-event'
    });
  }

  deleteSubEvent(id: number): void {
    this.api.deleteSubEvent(id).subscribe({
      next: () => this.subEvents = this.subEvents.filter(s => s.subEventId !== id),
      error: err => this.errorMessage = 'Error deleting sub-event'
    });
  }
}
