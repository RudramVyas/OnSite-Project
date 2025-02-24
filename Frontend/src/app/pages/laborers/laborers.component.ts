import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Laborer } from '../../models/laborer';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-laborers',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './laborers.component.html',
  styleUrls: ['./laborers.component.css']
})
export class LaborersComponent implements OnInit {
  laborers: Laborer[] = [];
  errorMessage = '';
  newLaborer: Laborer = {
    laborerId: 0,
    name: '',
    isAvailable: true
  };

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.loadLaborers();
  }

  loadLaborers(): void {
    this.api.getLaborers().subscribe({
      next: data => this.laborers = data,
      error: err => this.errorMessage = 'Error loading laborers'
    });
  }

  createLaborer(): void {
    if (!this.newLaborer.name) {
      this.errorMessage = 'Name is required';
      return;
    }
    this.api.createLaborer(this.newLaborer).subscribe({
      next: created => {
        this.laborers.push(created);
        this.newLaborer = { laborerId: 0, name: '', isAvailable: true };
        this.errorMessage = '';
      },
      error: err => this.errorMessage = 'Error creating laborer'
    });
  }

  deleteLaborer(id: number): void {
    this.api.deleteLaborer(id).subscribe({
      next: () => this.laborers = this.laborers.filter(l => l.laborerId !== id),
      error: err => this.errorMessage = 'Error deleting laborer'
    });
  }
}
