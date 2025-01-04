using Chapter13.Models;
using Chapter13.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chapter13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessGoalsController : ControllerBase
    {

        private readonly FitnessGoalService _fitnessGoalService;

        public FitnessGoalsController(FitnessGoalService fitnessGoalService)
        {
            _fitnessGoalService = fitnessGoalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FitnessGoal>> GetGoals()
        {
            return Ok(_fitnessGoalService.GetGoals());
        }

        [HttpGet("{id}")]
        public ActionResult<FitnessGoal> GetGoal(int id)
        {
            var goal = _fitnessGoalService.GetGoalById(id);

            if (goal == null)
                return NotFound();
            return Ok(goal);
        }

        [HttpPost]
        public ActionResult<FitnessGoal> CreateGoal(FitnessGoal goal)
        {
            _fitnessGoalService.AddGoal(goal);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGoal(int id, FitnessGoal updatedGoal)
        {
            var goal = _fitnessGoalService.GetGoalById(id);

            if (goal == null)
                return NotFound();

            _fitnessGoalService.UpdateGoal(id, updatedGoal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGoal(int id)
        {
            var goal = _fitnessGoalService.GetGoalById(id);

            if (goal == null)
                return NotFound();

            _fitnessGoalService.DeleteGoal(id);

            return NoContent();
        }
    }
}
