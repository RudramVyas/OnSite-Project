export interface SubEvent {
  subEventId: number;
  eventId: number; // Foreign key referencing an Event
  name: string;
  description?: string;
}
