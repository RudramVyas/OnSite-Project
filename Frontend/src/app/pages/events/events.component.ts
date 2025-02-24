import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Event } from '../../models/event';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-events',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  events: Event[] = [];
  errorMessage: string = '';

  // Initialize newEvent with default values
  newEvent: Event = {
    eventId: 0,
    name: '',
    eventDate: new Date().toISOString(),
    location: '',
    quoteDetails: ''
  };

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents(): void {
    this.api.getEvents().subscribe({
      next: (data) => {
        this.events = data;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Error loading events.';
      }
    });
  }

  createEvent(): void {
    if (!this.newEvent.name || !this.newEvent.eventDate) {
      this.errorMessage = 'Please provide valid event details.';
      return;
    }

    this.api.createEvent(this.newEvent).subscribe({
      next: (createdEvent) => {
        this.events.push(createdEvent);
        // Reset the newEvent form
        this.newEvent = {
          eventId: 0,
          name: '',
          eventDate: new Date().toISOString(),
          location: '',
          quoteDetails: ''
        };
        this.errorMessage = '';
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Error creating event.';
      }
    });
  }

  deleteEvent(id: number): void {
    this.api.deleteEvent(id).subscribe({
      next: () => {
        this.events = this.events.filter(e => e.eventId !== id);
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Error deleting event.';
      }
    });
  }
}
