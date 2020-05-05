using System;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IParticipantRepository
    {
        Task<Participant> GetParticipant(Guid participantId);

        Task AddParticipant(Participant participant);

        Task DeleteParticipant(Guid participantId);
    }
}
