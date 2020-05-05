using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IParticipantValidator
    {
        bool CanBeDeleted(Participant participant);

        bool IsValid(Participant participant);
    }
}
