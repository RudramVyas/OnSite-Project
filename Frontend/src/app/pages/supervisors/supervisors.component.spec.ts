import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SupervisorsComponent } from './supervisors.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('SupervisorsComponent', () => {
  let component: SupervisorsComponent;
  let fixture: ComponentFixture<SupervisorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        SupervisorsComponent,
        HttpClientTestingModule,
        FormsModule
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SupervisorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create SupervisorsComponent', () => {
    expect(component).toBeTruthy();
  });
});
