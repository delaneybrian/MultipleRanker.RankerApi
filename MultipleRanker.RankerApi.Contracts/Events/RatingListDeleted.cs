using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts.Events
{
    [DataContract]
    public class RatingListDeleted
    {
        [DataMember]
        public Guid RatingListId { get; set; }

        [DataMember]
        public Guid RatingBoardId { get; set; }
    }
}
