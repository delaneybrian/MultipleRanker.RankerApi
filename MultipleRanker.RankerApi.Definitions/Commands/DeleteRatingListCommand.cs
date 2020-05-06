using System;
using MediatR;

namespace MultipleRanker.RankerApi.Definitions
{
    public class DeleteRatingListCommand : IRequest
    {
        public DeleteRatingListCommand(
            Guid ratingBoardId,
            Guid ratingListId,
            Guid correlationId)
        {
            RatingBoardId = ratingBoardId;
            RatingListId = ratingListId;
            CorrelationId = correlationId;
        }
        public Guid CorrelationId { get; }

        public Guid RatingBoardId { get; }

        public Guid RatingListId { get; }
    }
}
