using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class RatingList
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime CreatedOnUtc { get; set; }

        [DataMember]
        public RatingType RatingType { get; set; }

        [DataMember]
        public RatingAggregationType RatingAggregation { get; set; }

        [DataMember]
        public HistoricalRating LatestRating { get; set; }
    }
}

