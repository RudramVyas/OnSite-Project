import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SubEventsComponent } from './sub-events.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('SubEventsComponent', () => {
  let component: SubEventsComponent;
  let fixture: ComponentFixture<SubEventsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        SubEventsComponent,
        HttpClientTestingModule,
        FormsModule
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubEventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create SubEventsComponent', () => {
    expect(component).toBeTruthy();
  });
});
