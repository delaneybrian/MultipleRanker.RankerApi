using System.Linq;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.Validation
{
    public class ParticipantFluentValidator : IParticipantValidator
    {
        public bool CanBeDeleted(Participant participant)
        {
            return !participant.RatingListIds.Any();
        }

        public bool IsValid(Participant participant)
        {
            throw new System.NotImplementedException();
        }
    }
}
