using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public ICollection<ParticipantResult> ParticipantResults { get; set; }

        [DataMember]
        public DateTime ResultTimeUtc { get; set; }

        [DataMember]
        public ICollection<Guid> RatingBoardIdsAppliedTo { get; set; }
    }
}
