using System;
using System.Collections.Generic;
using MediatR;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Definitions.Commands
{
    public class AddResultsCommand : IRequest
    {
        public AddResultsCommand(
            ICollection<Guid> ratingBoardIdsToApply,
            ICollection<ParticipantResult> participantResults,
            DateTime resultTimeUtc,
            Guid correlationId)
        {
            RatingBoardIdsToApply = ratingBoardIdsToApply;
            ParticipantResults = participantResults;
            ResultTimeUtc = resultTimeUtc;
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }

        public ICollection<Guid> RatingBoardIdsToApply { get; }

        public DateTime ResultTimeUtc { get; }

        public ICollection<ParticipantResult> ParticipantResults { get; }
    }
}
