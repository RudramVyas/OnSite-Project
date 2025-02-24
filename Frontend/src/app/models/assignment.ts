export interface Assignment {
  assignmentId: number;
  eventId?: number | null;
  subEventId?: number | null;
  supervisorId?: number | null;
  laborerId?: number | null;
  assignedRole: string;
}
