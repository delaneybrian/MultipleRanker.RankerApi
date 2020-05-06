using System;
using MediatR;

namespace MultipleRanker.RankerApi.Definitions
{
    public class DeleteRatingBoardCommand : IRequest
    {
        public DeleteRatingBoardCommand(
            Guid ratingBoardId,
            Guid correlationId)
        {
            RatingBoardId = ratingBoardId;
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }

        public Guid RatingBoardId { get; }
    }
}
