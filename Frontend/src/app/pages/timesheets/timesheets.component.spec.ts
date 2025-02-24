import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TimesheetsComponent } from './timesheets.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('TimesheetsComponent', () => {
  let component: TimesheetsComponent;
  let fixture: ComponentFixture<TimesheetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        TimesheetsComponent,
        HttpClientTestingModule,
        FormsModule
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimesheetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create TimesheetsComponent', () => {
    expect(component).toBeTruthy();
  });
});
