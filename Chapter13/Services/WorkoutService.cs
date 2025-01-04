using Chapter13.Models;

namespace Chapter13.Services
{
    public class WorkoutService
    {
        private readonly List<Workout> _workouts = new List<Workout>();

        public IEnumerable<Workout> GetWorkouts() => _workouts;

        public Workout GetWorkoutById(int id) => _workouts.FirstOrDefault(w => w.Id == id);

        public void AddWorkout(Workout workout)
        {
            workout.Id = _workouts.Count + 1;
            _workouts.Add(workout);
        }

        public void UpdateWorkout(int id, Workout updatedWorkout)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
            if (workout != null)
            {
                workout.Exercise = updatedWorkout.Exercise;
                workout.Duration = updatedWorkout.Duration;
                workout.Date = updatedWorkout.Date;
                workout.Notes = updatedWorkout.Notes;
            }
        }

        public void DeleteWorkout(int id)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
            if (workout != null)
            {
                _workouts.Remove(workout);
            }
        }
    }

}
