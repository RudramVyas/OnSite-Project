import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LaborersComponent } from './laborers.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('LaborersComponent', () => {
  let component: LaborersComponent;
  let fixture: ComponentFixture<LaborersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        LaborersComponent,
        HttpClientTestingModule,
        FormsModule
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LaborersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the LaborersComponent', () => {
    expect(component).toBeTruthy();
  });
});
