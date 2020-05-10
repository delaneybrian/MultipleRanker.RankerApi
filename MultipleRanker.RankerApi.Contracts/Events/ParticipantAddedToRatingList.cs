using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts.Events
{
    [DataContract]
    public class ParticipantAddedToRatingList
    {
        [DataMember]
        public Guid ParticipantId { get; set; }

        [DataMember]
        public Guid RatingListId { get; set; }
    }
}
