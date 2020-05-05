using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Definitions;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]

    public class ParticipantController : Controller
    {
        private readonly IMediator _mediator;

        public ParticipantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant(
            [FromQuery] Participant participant)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Publish(new CreateParticipantCommand(correlationId, participant));

            return Created(new Uri(""), null);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParticipant(
            [FromQuery] Guid participantId)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Publish(new DeleteParticipantCommand(correlationId, participantId));

            //todo what is correct here?
            return Ok();
        }
    }
}
