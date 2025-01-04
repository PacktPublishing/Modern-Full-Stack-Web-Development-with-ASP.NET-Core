using Chapter13.Models;

namespace Chapter13.Services
{
    public class FitnessGoalService
    {
        private readonly List<FitnessGoal> _goals = new List<FitnessGoal>();

        public IEnumerable<FitnessGoal> GetGoals() => _goals;

        public FitnessGoal GetGoalById(int id) => _goals.FirstOrDefault(g => g.Id == id);

        public void AddGoal(FitnessGoal goal)
        {
            goal.Id = _goals.Count + 1;
            _goals.Add(goal);
        }

        public void UpdateGoal(int id, FitnessGoal updatedGoal)
        {
            var goal = _goals.FirstOrDefault(g => g.Id == id);
            if (goal != null)
            {
                goal.GoalName = updatedGoal.GoalName;
                goal.Description = updatedGoal.Description;
                goal.TargetDate = updatedGoal.TargetDate;
            }
        }

        public void DeleteGoal(int id)
        {
            var goal = _goals.FirstOrDefault(g => g.Id == id);
            if (goal != null)
            {
                _goals.Remove(goal);
            }
        }
    }

}
