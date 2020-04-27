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
        private readonly IRatingsRepository _ratingsRepository;

        public RatingsGeneratedHandler(IRatingsRepository ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }

        public async Task HandleAsync(RatingsGenerated evt)
        {
            //todo move to extension method
            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                ParticipantRatings = evt
                    .ParticipantRatings
                    .Select(x => new ParticipantRating
                    {
                        Id = x.ParticipantId,
                        Rating = x.Rating
                    })
                    .ToList()
            };

            await _ratingsRepository.AddRating(evt.RatingBoardId, rating);
        }
    }
}
