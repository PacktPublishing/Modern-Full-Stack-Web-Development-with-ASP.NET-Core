import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router'; 
import { GoalService, FitnessGoal } from '../../services/goal.service';

@Component({
  selector: 'app-goal-list',
  standalone: true,
  templateUrl: './goal-list.component.html',
  imports: [CommonModule],
})
export class GoalListComponent implements OnInit {
  goals: FitnessGoal[] = [];

  constructor(private goalService: GoalService, private router: Router) {} 

  ngOnInit(): void {
    this.loadGoals();
  }

  loadGoals(): void {
    this.goalService.getGoals().subscribe(data => {
      this.goals = data;
    });
  }

  goToAddGoal(): void {
    this.router.navigate(['/add-goal']);
  }

  goToEditGoal(id: number): void {
    this.router.navigate([`/edit-goal/${id}`]);
  }

  deleteGoal(id: number): void {
    if (confirm('Are you sure you want to delete this goal?')) {
      this.goalService.deleteGoal(id).subscribe(() => {
        this.loadGoals();  
      });
    }
  }
}
