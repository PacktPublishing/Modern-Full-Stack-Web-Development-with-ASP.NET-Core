import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Workout {
  id: number;
  exercise: string;
  duration: number;
  date: Date;
  notes: string;
}

@Injectable({
  providedIn: 'root',
})
export class WorkoutService {
  private apiUrl = 'http://localhost:5124/api/workouts';

  constructor(private http: HttpClient) {}

  getWorkouts(): Observable<Workout[]> {
    return this.http.get<Workout[]>(this.apiUrl);
  }

  getWorkout(id: number): Observable<Workout> {
    return this.http.get<Workout>(`${this.apiUrl}/${id}`);
  }

  createWorkout(workout: Workout): Observable<Workout> {
    return this.http.post<Workout>(this.apiUrl, workout);
  }

  updateWorkout(id: number, workout: Workout): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, workout);
  }

  deleteWorkout(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
