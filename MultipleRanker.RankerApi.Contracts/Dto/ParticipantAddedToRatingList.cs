using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts.Dto
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
