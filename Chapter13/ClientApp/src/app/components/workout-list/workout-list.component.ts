import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { WorkoutService, Workout } from '../../services/workout.service';

@Component({
  selector: 'app-workout-list',
  standalone: true,
  templateUrl: './workout-list.component.html',
  imports: [CommonModule],  // Add HttpClientModule here
})
export class WorkoutListComponent implements OnInit {
  workouts: Workout[] = [];

  constructor(private workoutService: WorkoutService, private router: Router) {}

  ngOnInit(): void {
    this.loadWorkouts();
  }

  loadWorkouts(): void {
    this.workoutService.getWorkouts().subscribe(data => {
      this.workouts = data;
    });
  }

  goToAddWorkout(): void {
    this.router.navigate(['/add-workout']);
  }

  goToEditWorkout(id: number): void {
    this.router.navigate([`/edit-workout/${id}`]);
  }

  deleteWorkout(id: number): void {
    if (confirm('Are you sure you want to delete this workout?')) {
      this.workoutService.deleteWorkout(id).subscribe(() => {
        this.loadWorkouts();
      });
    }
  }
}
