using System;
using System.Linq;
using System.Threading.Tasks;
using MultipleRanker.Contracts.Messages;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application
{
    public class RatingsGeneratedHandler : IHandler<RatingsGenerated>
    {
        private readonly IRatingBoardRepository _ratingsRepository;

        public RatingsGeneratedHandler(IRatingBoardRepository ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }

        public async Task HandleAsync(RatingsGenerated evt)
        {
            ////todo move to extension method
            //var rating = new Rating
            //{
            //    Id = Guid.NewGuid(),
            //    CalculatedAtUtc = evt.CalculatedAtUtc,
            //    ParticipantRatings = evt
            //        .ParticipantRatings
            //        .Select(x => new ParticipantRating
            //        {
            //            Id = x.ParticipantId,
            //            Rating = x.Rating
            //        })
            //        .ToList()
            //};

            //await _ratingsRepository.AddRating(evt.RatingBoardId, rating);
        }
    }
}
