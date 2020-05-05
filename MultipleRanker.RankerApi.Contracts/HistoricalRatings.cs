using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class HistoricalRatings
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime CalculatedAtUtc { get; set; }

        [DataMember]
        public TriggerType TriggerType { get; set; }

        [DataMember]
        public ICollection<ParticipantRating> ParticipantRatings { get; set; }
    }
}
