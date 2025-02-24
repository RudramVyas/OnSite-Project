import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SupervisorL2Component } from './supervisor-l2.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('SupervisorL2Component', () => {
  let component: SupervisorL2Component;
  let fixture: ComponentFixture<SupervisorL2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        SupervisorL2Component,
        HttpClientTestingModule,
        FormsModule
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SupervisorL2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create SupervisorL2Component', () => {
    expect(component).toBeTruthy();
  });
});
