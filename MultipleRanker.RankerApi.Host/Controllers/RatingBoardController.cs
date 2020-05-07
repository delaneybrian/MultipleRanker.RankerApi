using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Definitions.Commands;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class RatingBoardController : Controller
    {
        private readonly IMediator _mediator;

        public RatingBoardController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRatingBoard(
            [FromBody] CreateRatingBoardDto createRatingBoardDto)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Send(createRatingBoardDto.ToCommand(correlationId));

            return Created(new Uri(""), null);
        }

        [HttpPost]
        [Route("addparticipant")]
        public async Task<IActionResult> AddParticipantToRatingBoard(
            [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId,
            [FromQuery(Name = "participantId")] Guid participantId
            )
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Send(
                new AddParticipantToRatingBoardCommand(
                    ratingBoardId, 
                    participantId, 
                    correlationId));

            return Created(new Uri(""), null);
        }


        [HttpPost]
        [Route("generate")]
        public async Task<IActionResult> GenerateRatingsForRatingBoard(
            [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Send(new GenerateRatingsCommand(ratingBoardId, correlationId));
         
            return Created(new Uri(""), null);
        }
    }
}
