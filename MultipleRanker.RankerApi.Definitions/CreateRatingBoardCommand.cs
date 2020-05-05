using System;
using MediatR;
using MultipleRanker.RankerApi.Contracts;
using Optional;

namespace MultipleRanker.RankerApi.Definitions
{
    public class CreateRatingBoardCommand : IRequest<Option<string>>
    {
        public CreateRatingBoardCommand(
            Guid correlationId,
            RatingBoard ratingBoard)
        {
            CorrelationId = correlationId;
            RatingBoard = ratingBoard;
        }

        public Guid CorrelationId { get; }

        public RatingBoard RatingBoard { get; }
    }
}
