import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { EventsComponent } from './pages/events/events.component';
import { SubEventsComponent } from './pages/sub-events/sub-events.component';
import { SupervisorsComponent } from './pages/supervisors/supervisors.component';
import { LaborersComponent } from './pages/laborers/laborers.component';
import { TimesheetsComponent } from './pages/timesheets/timesheets.component';
import { QuoteComponent } from './pages/quote/quote.component';
import { SupervisorL2Component } from './pages/supervisor-l2/supervisor-l2.component';
import { SupervisorL1Component } from './pages/supervisor-l1/supervisor-l1.component';
import { TimesheetL2Component } from './pages/timesheet-l2/timesheet-l2.component';
import { TimesheetL1Component } from './pages/timesheet-l1/timesheet-l1.component';
import { TimesheetLaborerComponent } from './pages/timesheet-laborer/timesheet-laborer.component';
import { assignmentsComponent } from './pages/assignment/assignment.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'events', component: EventsComponent },
  { path: 'sub-events', component: SubEventsComponent },
  { path: 'supervisors', component: SupervisorsComponent },
  { path: 'laborers', component: LaborersComponent },
  { path: 'quote', component: QuoteComponent },
  { path: 'supervisor-l2', component: SupervisorL2Component },
  { path: 'supervisor-l1', component: SupervisorL1Component },
  { path: 'timesheets-l1', component: TimesheetL1Component },
  { path: 'timesheets-l2', component: TimesheetL2Component },
  { path: 'timesheets-lab', component: TimesheetLaborerComponent },
  { path: 'timesheets', component: TimesheetsComponent },
  { path: 'assignments', component: assignmentsComponent },
  // fall back route:
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];
