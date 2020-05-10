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
    public class RatingListController : Controller
    {
        private readonly IMediator _mediator;

        public RatingListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRatingList(
         [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId,
         [FromBody] CreateRatingListDto createRatingListDto)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Send(new CreateRatingListCommand(
                ratingBoardId,
                createRatingListDto.RatingType,
                createRatingListDto.RatingAggregation,
                correlationId));

            return Created(new Uri(""), null);
        }

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> RemoveRatingList(
            [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId,
            [FromQuery(Name = "ratingListId")] Guid ratingListId)
        {
            var correlationId = Guid.NewGuid();

            await _mediator.Send(new DeleteRatingListCommand(
                ratingBoardId,
                ratingListId,
                correlationId));

            return Ok();
        }
    }
}
