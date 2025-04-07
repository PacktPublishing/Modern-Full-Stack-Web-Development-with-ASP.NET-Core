namespace Chapter13.Models;

public class FitnessGoal
{
    public int Id { get; set; }
    public string GoalName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime TargetDate { get; set; }
}
