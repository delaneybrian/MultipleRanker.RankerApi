using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts.Events
{
    [DataContract]
    public class GenerateRatings
    {
        [DataMember]
        public Guid RatingListId { get; set; }
    }
}
