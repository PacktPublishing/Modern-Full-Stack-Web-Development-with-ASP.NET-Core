import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { WorkoutService, Workout } from '../../services/workout.service'
import { ActivatedRoute, Router, RouterModule } from '@angular/router';  // Import RouterModule

@Component({
  selector: 'app-workout-form',
  standalone: true,
  templateUrl: './workout-form.component.html',
  imports: [FormsModule, RouterModule],  // Add RouterModule to imports
})
export class WorkoutFormComponent implements OnInit {
  workout: Workout = { id: 0, exercise: '', duration: 0, date: new Date(), notes: '' };
  isEditMode: boolean = false;

  constructor(
    private workoutService: WorkoutService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.workoutService.getWorkout(Number(id)).subscribe(data => {
        this.workout = data;
      });
    }
  }

  saveWorkout(): void {
    if (this.isEditMode) {
      this.workoutService.updateWorkout(this.workout.id, this.workout).subscribe(() => {
        this.router.navigate(['/workouts']);
      });
    } else {
      this.workoutService.createWorkout(this.workout).subscribe(() => {
        this.router.navigate(['/workouts']);
      });
    }
  }
}
