import { ComponentFixture, TestBed } from '@angular/core/testing';
import { QuoteComponent } from './quote.component';
import { FormsModule } from '@angular/forms';

describe('QuoteComponent', () => {
  let component: QuoteComponent;
  let fixture: ComponentFixture<QuoteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuoteComponent, FormsModule]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create QuoteComponent', () => {
    expect(component).toBeTruthy();
  });

  it('should calculate quote correctly', () => {
    component.numAttendees = 100;
    component.boothCount = 5;
    component.hours = 8;
    component.baseRate = 20;
    component.calculateQuote();
    expect(component.calculatedQuote).toBeGreaterThan(0);
  });
});
