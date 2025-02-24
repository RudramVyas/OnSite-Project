import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';  // Import FormsModule
import { ApiService } from '../../services/api.service';
import { Supervisor } from '../../models/supervisor';

@Component({
  selector: 'app-supervisors',
  standalone: true,
  imports: [CommonModule, FormsModule],  // Add FormsModule here
  templateUrl: './supervisors.component.html',
  styleUrls: ['./supervisors.component.css']
})
export class SupervisorsComponent implements OnInit {
  supervisors: Supervisor[] = [];
  errorMessage = '';
  newSupervisor: Supervisor = {
    supervisorId: 0,
    name: '',
    level: 2
  };

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.loadSupervisors();
  }

  loadSupervisors(): void {
    this.api.getSupervisors().subscribe({
      next: data => this.supervisors = data,
      error: err => this.errorMessage = 'Error loading supervisors'
    });
  }

  createSupervisor(): void {
    if (!this.newSupervisor.name) {
      this.errorMessage = 'Name is required';
      return;
    }
    this.api.createSupervisor(this.newSupervisor).subscribe({
      next: created => {
        this.supervisors.push(created);
        this.newSupervisor = { supervisorId: 0, name: '', level: 2 };
        this.errorMessage = '';
      },
      error: err => this.errorMessage = 'Error creating supervisor'
    });
  }

  deleteSupervisor(id: number): void {
    this.api.deleteSupervisor(id).subscribe({
      next: () => this.supervisors = this.supervisors.filter(s => s.supervisorId !== id),
      error: err => this.errorMessage = 'Error deleting supervisor'
    });
  }
}
