import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Event } from '../models/event';
import { SubEvent } from '../models/subEvent';
import { Supervisor } from '../models/supervisor';
import { Laborer } from '../models/laborer';
import { Assignment } from '../models/assignment';
import { TimeSheet } from '../models/timeSheet';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  // Hardcoded base URL for your backend API
  private baseUrl = 'https://localhost:7112';

  constructor(private http: HttpClient) {}

  // Helper to extract array data if wrapped in a $values property
  private unwrapArray<T>(response: any): T[] {
    return response && response.$values ? response.$values : response;
  }

  // Event Endpoints
  getEvents(): Observable<Event[]> {
    return this.http.get<any>(`${this.baseUrl}/api/Event`).pipe(
      map(response => this.unwrapArray<Event>(response))
    );
  }
  getEvent(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.baseUrl}/api/Event/${id}`);
  }
  createEvent(evt: Event): Observable<Event> {
    return this.http.post<Event>(`${this.baseUrl}/api/Event`, evt);
  }
  updateEvent(id: number, evt: Event): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/Event/${id}`, evt);
  }
  deleteEvent(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/Event/${id}`);
  }

  // SubEvent Endpoints
  getSubEvents(): Observable<SubEvent[]> {
    return this.http.get<any>(`${this.baseUrl}/api/SubEvent`).pipe(
      map(response => this.unwrapArray<SubEvent>(response))
    );
  }
  getSubEvent(id: number): Observable<SubEvent> {
    return this.http.get<SubEvent>(`${this.baseUrl}/api/SubEvent/${id}`);
  }
  createSubEvent(subEvt: SubEvent): Observable<SubEvent> {
    return this.http.post<SubEvent>(`${this.baseUrl}/api/SubEvent`, subEvt);
  }
  updateSubEvent(id: number, subEvt: SubEvent): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/SubEvent/${id}`, subEvt);
  }
  deleteSubEvent(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/SubEvent/${id}`);
  }

  // Supervisor Endpoints
  getSupervisors(): Observable<Supervisor[]> {
    return this.http.get<any>(`${this.baseUrl}/api/Supervisor`).pipe(
      map(response => this.unwrapArray<Supervisor>(response))
    );
  }
  getSupervisor(id: number): Observable<Supervisor> {
    return this.http.get<Supervisor>(`${this.baseUrl}/api/Supervisor/${id}`);
  }
  createSupervisor(sup: Supervisor): Observable<Supervisor> {
    return this.http.post<Supervisor>(`${this.baseUrl}/api/Supervisor`, sup);
  }
  updateSupervisor(id: number, sup: Supervisor): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/Supervisor/${id}`, sup);
  }
  deleteSupervisor(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/Supervisor/${id}`);
  }

  // Laborer Endpoints
  getLaborers(): Observable<Laborer[]> {
    return this.http.get<any>(`${this.baseUrl}/api/Laborer`).pipe(
      map(response => this.unwrapArray<Laborer>(response))
    );
  }
  getLaborer(id: number): Observable<Laborer> {
    return this.http.get<Laborer>(`${this.baseUrl}/api/Laborer/${id}`);
  }
  createLaborer(lab: Laborer): Observable<Laborer> {
    return this.http.post<Laborer>(`${this.baseUrl}/api/Laborer`, lab);
  }
  updateLaborer(id: number, lab: Laborer): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/Laborer/${id}`, lab);
  }
  deleteLaborer(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/Laborer/${id}`);
  }

  // Assignment Endpoints
  getAssignments(): Observable<Assignment[]> {
    return this.http.get<any>(`${this.baseUrl}/api/Assignment`).pipe(
      map(response => this.unwrapArray<Assignment>(response))
    );
  }
  getAssignment(id: number): Observable<Assignment> {
    return this.http.get<Assignment>(`${this.baseUrl}/api/Assignment/${id}`);
  }
  createAssignment(assign: Assignment): Observable<Assignment> {
    return this.http.post<Assignment>(`${this.baseUrl}/api/Assignment`, assign);
  }
  updateAssignment(id: number, assign: Assignment): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/Assignment/${id}`, assign);
  }
  deleteAssignment(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/Assignment/${id}`);
  }

  // TimeSheet Endpoints
  getTimeSheets(): Observable<TimeSheet[]> {
    return this.http.get<any>(`${this.baseUrl}/api/TimeSheet`).pipe(
      map(response => this.unwrapArray<TimeSheet>(response))
    );
  }
  getTimeSheet(id: number): Observable<TimeSheet> {
    return this.http.get<TimeSheet>(`${this.baseUrl}/api/TimeSheet/${id}`);
  }
  createTimeSheet(ts: TimeSheet): Observable<TimeSheet> {
    return this.http.post<TimeSheet>(`${this.baseUrl}/api/TimeSheet`, ts);
  }
  updateTimeSheet(id: number, ts: TimeSheet): Observable<any> {
    return this.http.put(`${this.baseUrl}/api/TimeSheet/${id}`, ts);
  }
  deleteTimeSheet(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/TimeSheet/${id}`);
  }
}
