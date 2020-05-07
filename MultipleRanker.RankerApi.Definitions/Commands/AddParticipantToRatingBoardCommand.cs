using System;
using MediatR;

namespace MultipleRanker.RankerApi.Definitions
{
    public class AddParticipantToRatingBoardCommand : IRequest
    {
        public AddParticipantToRatingBoardCommand(
            Guid ratingBoardId,
            Guid participantId,
            Guid correlationId)
        {
            RatingBoardId = ratingBoardId;
            ParticipantId = participantId;
            CorrelationId = correlationId;
        }

        public Guid RatingBoardId { get; }

        public Guid ParticipantId { get; }

        public Guid CorrelationId { get; }

    }
}