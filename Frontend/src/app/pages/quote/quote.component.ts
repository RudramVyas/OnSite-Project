import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-quote',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent {
  numAttendees: number = 0;
  boothCount: number = 0;
  hours: number = 0;
  baseRate: number = 20;
  calculatedQuote: number | null = null;

  calculateQuote(): void {
    // Example calculation: (attendees * 0.1 + booths * 2) * hours * baseRate
    this.calculatedQuote = (this.numAttendees * 0.1 + this.boothCount * 2) * this.hours * this.baseRate;
  }
}
