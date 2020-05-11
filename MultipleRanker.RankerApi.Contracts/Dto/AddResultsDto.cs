using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class AddResultsDto
    {
        [DataMember]
        public ICollection<Guid> RatingBoardIdsToApply { get; set; }

        [DataMember]
        public DateTime ResultTimeUtc { get; set; }

        [DataMember]
        public ICollection<ParticipantResult> ParticipantResults { get; set; }
    }
}
