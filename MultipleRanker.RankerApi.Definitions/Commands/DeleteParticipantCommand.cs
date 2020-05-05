using System;
using System.Runtime.Serialization;
using MediatR;

namespace MultipleRanker.RankerApi.Definitions
{
    public class DeleteParticipantCommand : IRequest
    {
        public DeleteParticipantCommand(
            Guid correlationId,
            Guid participantId)
        {
            CorrelationId = correlationId;
            ParticipantId = participantId;
        }

        [DataMember]
        public Guid CorrelationId { get; }

        [DataMember]
        public Guid ParticipantId { get; }
    }
}
