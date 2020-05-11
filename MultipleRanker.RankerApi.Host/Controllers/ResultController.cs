using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Definitions.Commands;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/add")]
        public async Task AddResults(
            [FromBody] AddResultsDto addResultsDto)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Send(
                new AddResultsCommand(
                    addResultsDto.RatingBoardIdsToApply, 
                    addResultsDto.ParticipantResults, 
                    addResultsDto.ResultTimeUtc,
                    correlationId));
        }

        [HttpPost]
        [Route("/remove")]
        public async Task RemoveResults(
            [FromBody] RemoveResultsDto removeResultsDto)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Send(
                new RemoveResultsCommand(
                    removeResultsDto.ResultId, 
                    removeResultsDto.RatingBoardIdsToRemove, 
                    correlationId));
        }
    }
}
