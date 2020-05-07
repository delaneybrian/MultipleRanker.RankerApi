using System;
using MediatR;

namespace MultipleRanker.RankerApi.Definitions.Commands
{ 
    public class GenerateRatingsCommand : IRequest
    {
        public GenerateRatingsCommand(
            Guid ratingBoardId,
            Guid correlationId)
        {
            RatingBoardId = ratingBoardId;
            CorrelationId = correlationId;
        }

        public Guid RatingBoardId { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
