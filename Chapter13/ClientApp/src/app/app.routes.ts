import { Routes } from '@angular/router';
import { WorkoutListComponent } from './components/workout-list/workout-list.component';
import { WorkoutFormComponent } from './components/workout-form/workout-form.component';
import { GoalListComponent } from './components/goal-list/goal-list.component';
import { GoalFormComponent } from './components/goal-form/goal-form.component';

export const routes: Routes = [
  { path: 'workouts', component: WorkoutListComponent },   
  { path: 'add-workout', component: WorkoutFormComponent }, 
  { path: 'edit-workout/:id', component: WorkoutFormComponent }, 
  { path: 'goals', component: GoalListComponent },         
  { path: 'add-goal', component: GoalFormComponent },       
  { path: 'edit-goal/:id', component: GoalFormComponent },  
  { path: '', redirectTo: '/workouts', pathMatch: 'full' }, 
];
