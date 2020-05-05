using System;
using System.Runtime.Serialization;
using MediatR;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Definitions
{
    public class CreateParticipantCommand : IRequest
    {
        public CreateParticipantCommand(
            Guid correlationId,
            Participant participant)
        {
            CorrelationId = correlationId;
            Participant = participant;
        }

        [DataMember]
        public Guid CorrelationId { get; }

        [DataMember]
        public Participant Participant { get; }
    }
}
