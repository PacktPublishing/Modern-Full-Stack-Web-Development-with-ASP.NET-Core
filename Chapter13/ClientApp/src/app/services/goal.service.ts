import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface FitnessGoal {
  id: number;
  goalName: string;
  description: string;
  targetDate: Date;
}

@Injectable({
  providedIn: 'root',
})
export class GoalService {
  private apiUrl = 'http://localhost:5124/api/fitnessgoals';

  constructor(private http: HttpClient) {}

  getGoals(): Observable<FitnessGoal[]> {
    return this.http.get<FitnessGoal[]>(this.apiUrl);
  }

  getGoal(id: number): Observable<FitnessGoal> {
    return this.http.get<FitnessGoal>(`${this.apiUrl}/${id}`);
  }

  createGoal(goal: FitnessGoal): Observable<FitnessGoal> {
    return this.http.post<FitnessGoal>(this.apiUrl, goal);
  }

  updateGoal(id: number, goal: FitnessGoal): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, goal);
  }

  deleteGoal(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
