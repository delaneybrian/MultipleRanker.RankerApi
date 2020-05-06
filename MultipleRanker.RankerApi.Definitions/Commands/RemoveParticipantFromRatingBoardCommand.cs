using MediatR;
using System;

namespace MultipleRanker.RankerApi.Definitions.Commands
{
    public class RemoveParticipantFromRatingBoardCommand : IRequest
    {
        public RemoveParticipantFromRatingBoardCommand(
            Guid correlationId,
            Guid ratingBoardId,
            Guid participantId)
        {
            CorrelationId = correlationId;
            RatingBoardId = ratingBoardId;
            ParticipantId = participantId;
        }

        public Guid CorrelationId { get; }

        public Guid RatingBoardId { get; }

        public Guid ParticipantId { get; }
    }
}
