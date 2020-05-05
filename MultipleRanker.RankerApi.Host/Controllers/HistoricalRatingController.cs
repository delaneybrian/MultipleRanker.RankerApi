using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class HistoricalRatingController : Controller
    {
        private readonly IHistoricalRatingsRepository _historicalRatingsRepository;

        public HistoricalRatingController(
            IHistoricalRatingsRepository historicalRatingsRepository)
        {
            _historicalRatingsRepository = historicalRatingsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoricalRatingsForRatingList(
            [FromQuery] Guid ratingListId)
        {
            var historicalRatings = _historicalRatingsRepository
                .GetAllHistoricalRatingsForRatingList(ratingListId);

            return Ok(historicalRatings);
        }
    }
}
