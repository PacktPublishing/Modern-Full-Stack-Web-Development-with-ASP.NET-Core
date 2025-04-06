namespace Chapter13.Models;

public class Workout
{
    public int Id { get; set; }
    public string Exercise { get; set; } = default!;
    public int Duration { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; } = default!;
}
