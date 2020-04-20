using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class Ratings
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public ICollection<Rating> PreviousRatings { get; set; }
    }
}
