import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SupervisorL1Component } from './supervisor-l1.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('SupervisorL1Component', () => {
  let component: SupervisorL1Component;
  let fixture: ComponentFixture<SupervisorL1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        SupervisorL1Component,
        HttpClientTestingModule,
        FormsModule
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SupervisorL1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create SupervisorL1Component', () => {
    expect(component).toBeTruthy();
  });
});
