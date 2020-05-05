using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<Guid> ParticipantIds { get; set; }

        [DataMember]
        public ICollection<Guid> RatingBoardIds { get; set; }
    }
}
