namespace Chapter12.Models;

public class LogisticsItem
{
    public int Id { get; set; }
    public string ItemName { get; set; } = default!;
    public int Quantity { get; set; }
    public string Location { get; set; } = default!;
}
