using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleRanker.Contracts;
using MultipleRanker.Contracts.Messages;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class MatchUpController : Controller
    {
        private readonly IMessagePublisher _messagePublisher;

        public MatchUpController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost]
        public async Task<IActionResult> Something(
            [FromQuery] Guid rankingBoardId,
            [FromBody] ICollection<MatchUpParticipantScore> participantScores)
        {
            //todo move this logic somewhere else
            var correlationId = Guid.NewGuid();

            var matchUpCompleted = new MatchUpCompleted
            {
                RatingBoardId = rankingBoardId,
                ParticipantScores = participantScores
            };

            _messagePublisher.Publish(matchUpCompleted, correlationId);

            //todo this is clearly not correct!
            return Created(new Uri("http://www.google.com"), null);
        }
    }
}
