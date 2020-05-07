using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts.Events
{
    [DataContract]
    public class ResultAdded
    {
        [DataMember]
        public Guid ResultId { get; set; }

        [DataMember]
        public Guid RatingListId { get; set; }

        [DataMember]
        public ICollection<ParticipantResult> ParticipantResults { get; set; }
    }
}
