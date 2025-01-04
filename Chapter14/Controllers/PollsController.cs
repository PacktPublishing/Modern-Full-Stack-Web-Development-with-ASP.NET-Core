using Chapter14.Models;
using Chapter14.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chapter14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PollsController : ControllerBase
    {
        private readonly PollService _pollService;

        public PollsController(PollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet]
        public ActionResult<List<Poll>> GetAllPolls()
        {
            var polls = _pollService.GetPolls();
            return Ok(polls);
        }

        [HttpGet("{pollId}")]
        public ActionResult<Poll> GetPoll(int pollId)
        {
            var poll = _pollService.GetPoll(pollId);
            if (poll == null)
            {
                return NotFound(new { Message = "Poll not found" });
            }
            return Ok(poll);
        }

        [HttpPost]
        public ActionResult<Poll> CreatePoll([FromBody] CreatePollRequest request)
        {
            if (string.IsNullOrEmpty(request.Question) || request.Options == null || request.Options.Count < 2)
            {
                return BadRequest(new { Message = "Invalid poll data. A poll must have a question and at least two options." });
            }

            var poll = _pollService.CreatePoll(request.Question, request.Options, request.ExpiresAt);
            return CreatedAtAction(nameof(GetPoll), new { pollId = poll.Id }, poll);
        }

        [HttpPost("{pollId}/vote")]
        public ActionResult SubmitVote(int pollId, [FromBody] VoteRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId) || request.OptionId <= 0)
            {
                return BadRequest(new { Message = "Invalid vote data. UserId and OptionId are required." });
            }

            var result = _pollService.Vote(pollId, request.OptionId, request.UserId);
            if (!result)
            {
                return BadRequest(new { Message = "Unable to cast vote. Either the poll has expired, the option is invalid, or the user has already voted." });
            }

            return Ok(new { Message = "Vote successfully cast." });
        }

        [HttpGet("{pollId}/results")]
        public ActionResult<List<Option>> GetPollResults(int pollId)
        {
            var results = _pollService.GetPollResults(pollId);
            if (results == null || results.Count == 0)
            {
                return NotFound(new { Message = "Poll not found or no votes have been cast yet." });
            }
            return Ok(results);
        }

        [HttpPut("{pollId}")]
        public ActionResult UpdatePoll(int pollId, [FromBody] UpdatePollRequest request)
        {
            var poll = _pollService.GetPoll(pollId);
            if (poll == null)
            {
                return NotFound(new { Message = "Poll not found." });
            }

            poll.ExpiresAt = request.ExpiresAt;
            return Ok(poll);
        }
    }
}
