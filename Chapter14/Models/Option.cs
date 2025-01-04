namespace Chapter14.Models
{
    public class Option
    {
        public int Id { get; set; } 
        public string Text { get; set; } 
        public int PollId { get; set; } 
        public int Votes { get; set; } = 0; 
    }

}
