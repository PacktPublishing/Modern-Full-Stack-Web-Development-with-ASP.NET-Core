import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FitnessGoal, GoalService } from '../../services/goal.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router'; 

@Component({
  selector: 'app-goal-form',
  standalone: true,
  templateUrl: './goal-form.component.html',
  imports: [FormsModule, RouterModule] 
})
export class GoalFormComponent implements OnInit {
  goal: FitnessGoal = { id: 0, goalName: '', description: '', targetDate: new Date() };
  isEditMode: boolean = false;

  constructor(
    private goalService: GoalService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.goalService.getGoal(Number(id)).subscribe(data => {
        this.goal = data;
      });
    }
  }

  saveGoal(): void {
    if (this.isEditMode) {
      this.goalService.updateGoal(this.goal.id, this.goal).subscribe(() => {
        this.router.navigate(['/goals']);
      });
    } else {
      this.goalService.createGoal(this.goal).subscribe(() => {
        this.router.navigate(['/goals']);
      });
    }
  }
}
