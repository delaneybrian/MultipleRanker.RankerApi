using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.Contracts.Messages;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application
{
    public class RatingsGeneratedHandler : AsyncRequestHandler<RatingsGenerated>
    {
        private readonly IRatingsRepository _ratingsRepository;

        public RatingsGeneratedHandler(IRatingsRepository ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }

        protected override async Task Handle(RatingsGenerated request, CancellationToken cancellationToken)
        {
            //todo move to extension method
            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                ParticipantRatingEntities = request
                    .ParticipantRatings
                    .Select(x => new ParticipantRating
                    {
                        Id = x.ParticipantId,
                        Rating = x.Rating
                    })
                    .ToList()
            };

            await _ratingsRepository.AddRating(request.RatingBoardId, rating);
        }
    }
}
