using System;
using System.Collections.Generic;
using MediatR;

namespace MultipleRanker.RankerApi.Definitions.Commands
{
    public class RemoveResultsCommand : IRequest
    {
        public RemoveResultsCommand(Guid resultId,
            ICollection<Guid> ratingBoardIdsToRemoveFrom,
            Guid correlationId)
        {
            ResultId = resultId;
            RatingBoardIdsToRemoveFrom = ratingBoardIdsToRemoveFrom;
            CorrelationId = correlationId;
        }

        public Guid ResultId { get; set; }

        public ICollection<Guid> RatingBoardIdsToRemoveFrom { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
