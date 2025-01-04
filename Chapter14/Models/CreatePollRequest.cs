namespace Chapter14.Models
{
    public class CreatePollRequest
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
