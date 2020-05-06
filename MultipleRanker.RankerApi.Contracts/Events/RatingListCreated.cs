using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts.Events
{
    [DataContract]
    public class RatingListCreated
    {
        [DataMember]
        public Guid RatingListId { get; set; }

        [DataMember]
        public Guid RatingBoardId { get; set; }

        [DataMember]
        public DateTime CreatedOnUtc { get; set; }

        [DataMember]
        public RatingType RatingType { get; set; }

        [DataMember]
        public RatingAggregationType RatingAggregation { get; set; }
    }
}
