using Chapter14.Hubs;
using Chapter14.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chapter14.Services
{
    public class PollService
    {
        private readonly List<Poll> _polls = new();
        private readonly List<Vote> _votes = new();
        private readonly IHubContext<VoteHub> _hubContext;

        public PollService(IHubContext<VoteHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public List<Poll> GetPolls()
        {
            return _polls;
        }

        public Poll GetPoll(int pollId)
        {
            return _polls.FirstOrDefault(p => p.Id == pollId);
        }

        public Poll CreatePoll(string question, List<string> options, DateTime expiresAt)
        {
            var newPoll = new Poll
            {
                Id = _polls.Count > 0 ? _polls.Max(p => p.Id) + 1 : 1,
                Question = question,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = expiresAt
            };

            foreach (var optionText in options)
            {
                newPoll.Options.Add(new Option
                {
                    Id = newPoll.Options.Count > 0 ? newPoll.Options.Max(o => o.Id) + 1 : 1,
                    Text = optionText,
                    PollId = newPoll.Id
                });
            }

            _polls.Add(newPoll);
            return newPoll;
        }

        public bool Vote(int pollId, int optionId, string userId)
        {
            var poll = GetPoll(pollId);

            if (poll == null || poll.ExpiresAt < DateTime.UtcNow)
            {
                return false; 
            }

            var option = poll.Options.FirstOrDefault(o => o.Id == optionId);
            if (option == null)
            {
                return false; 
            }

           
            option.Votes++;
            _votes.Add(new Vote
            {
                Id = _votes.Count > 0 ? _votes.Max(v => v.Id) + 1 : 1,
                PollId = pollId,
                OptionId = optionId,
                UserId = userId,
                VotedAt = DateTime.UtcNow
            });


            _hubContext.Clients.All.SendAsync("ReceiveVoteUpdate", pollId, poll.Options);

            return true;
        }

        public List<Option> GetPollResults(int pollId)
        {
            var poll = GetPoll(pollId);
            return poll?.Options ?? new List<Option>();
        }
    }
}
