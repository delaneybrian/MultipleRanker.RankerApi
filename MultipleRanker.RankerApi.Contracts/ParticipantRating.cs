using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class ParticipantRating
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public double Rating { get; set; }
    }
}
