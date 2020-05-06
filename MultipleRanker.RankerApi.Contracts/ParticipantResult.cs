using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class ParticipantResult
    {
        [DataMember] 
        public Guid ParticipantId { get; set; }

        [DataMember]
        public double Score { get; set; }
    }
}
