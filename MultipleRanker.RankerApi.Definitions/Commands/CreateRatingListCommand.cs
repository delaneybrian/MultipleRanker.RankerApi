using System;
using MediatR;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Definitions
{
    public class CreateRatingListCommand : IRequest
    {
        public CreateRatingListCommand(
            Guid ratingBoardId,
            RatingType ratingType,
            RatingAggregationType ratingAggregationType,
            Guid correlationId
            )
        {
            RatingBoardId = ratingBoardId;
            RatingType = ratingType;
            RatingAggregationType = ratingAggregationType;
            CorrelationId = correlationId;
        }

        public Guid RatingBoardId { get; }

        public RatingType RatingType { get; set; }

        public RatingAggregationType RatingAggregationType { get; set; }

        public Guid CorrelationId { get; }
    }
}
