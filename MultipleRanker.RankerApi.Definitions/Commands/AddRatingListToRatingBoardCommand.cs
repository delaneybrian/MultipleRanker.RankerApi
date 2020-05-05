using System;
using MediatR;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Definitions
{
    public class AddRatingListToRatingBoardCommand : IRequest
    {
        public AddRatingListToRatingBoardCommand(
            Guid correlationId,
            Guid ratingBoardId,
            RatingList ratingList)
        {
            CorrelationId = correlationId;
            RatingBoardId = ratingBoardId;
            RatingList = ratingList;
        }

        public Guid CorrelationId { get; }

        public Guid RatingBoardId { get; }

        public RatingList RatingList { get; }
    }
}
