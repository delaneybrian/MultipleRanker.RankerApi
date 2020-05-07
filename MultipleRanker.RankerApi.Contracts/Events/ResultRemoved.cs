using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts.Events
{
    [DataContract]
    public class ResultRemoved
    {
        [DataMember]
        public Guid ResultId { get; set; }

        [DataMember]
        public Guid RatingListId { get; set; }
    }
}
