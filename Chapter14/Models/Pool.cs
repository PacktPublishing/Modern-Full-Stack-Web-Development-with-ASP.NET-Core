namespace Chapter14.Models;

public class Poll
{
    public int Id { get; set; }
    public string Question { get; set; } = default!;
    public List<Option> Options { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}
