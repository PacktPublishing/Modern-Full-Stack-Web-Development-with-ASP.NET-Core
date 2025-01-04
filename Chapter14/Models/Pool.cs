namespace Chapter14.Models
{
    public class Poll
    {
        public int Id { get; set; } 
        public string Question { get; set; } 
        public List<Option> Options { get; set; } = new List<Option>(); 
        public DateTime CreatedAt { get; set; } 
        public DateTime ExpiresAt { get; set; } 
    }
}
