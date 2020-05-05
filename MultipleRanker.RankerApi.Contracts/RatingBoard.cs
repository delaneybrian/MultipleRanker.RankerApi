using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class RatingBoard
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public RatingBoardType Type { get; set; }

        [DataMember]
        public RatingBoardSubType SubType { get; set; }

        [DataMember]
        public DateTime CreatedAtUtc { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public ICollection<RatingList> RatingLists { get; set; }

        [DataMember]
        public ICollection<Participant> ParticipantEntities { get; set; }
    }
}
