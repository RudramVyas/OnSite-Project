export interface Event {
  eventId: number;
  name: string;
  eventDate: string; // ISO date string
  location?: string;
  quoteDetails?: string;
}
