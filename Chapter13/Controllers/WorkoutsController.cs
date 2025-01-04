using Chapter13.Models;
using Chapter13.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chapter13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly WorkoutService _workoutService;

        public WorkoutsController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Workout>> GetWorkouts()
        {
            return Ok(_workoutService.GetWorkouts());
        }

        [HttpGet("{id}")]
        public ActionResult<Workout> GetWorkout(int id)
        {
            var workout = _workoutService.GetWorkoutById(id);

            if (workout == null)
                return NotFound();
            return Ok(workout);
        }

        [HttpPost]
        public ActionResult<Workout> CreateWorkout(Workout workout)
        {
            _workoutService.AddWorkout(workout);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWorkout(int id, Workout updatedWorkout)
        {
            var workout = _workoutService.GetWorkoutById(id);

            if (workout == null)
                return NotFound();

            _workoutService.UpdateWorkout(id, updatedWorkout);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkout(int id)
        {
            var workout = _workoutService.GetWorkoutById(id);


            if (workout == null)
                return NotFound();

            _workoutService.DeleteWorkout(id);

            return NoContent();
        }
    }
}
