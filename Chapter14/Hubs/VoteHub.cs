using Chapter14.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chapter14.Hubs
{
    public class VoteHub : Hub
    {
        public async Task BroadcastVoteUpdate(int pollId, List<Option> options)
        {
            await Clients.All.SendAsync("ReceiveVoteUpdate", pollId, options);
        }
    }
}
