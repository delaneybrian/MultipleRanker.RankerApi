using System;
using MediatR;

namespace MultipleRanker.RankerApi.Definitions
{
    public class AddParticipantToRatingBoardCommand : IRequest
    {
        public AddParticipantToRatingBoardCommand(
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
