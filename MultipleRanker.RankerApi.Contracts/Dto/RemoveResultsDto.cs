using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class RemoveResultsDto
    {
        [DataMember]
        public Guid ResultId { get; set; }

        [DataMember]
        public ICollection<Guid> RatingBoardIdsToRemove { get; set; }
    }
}
