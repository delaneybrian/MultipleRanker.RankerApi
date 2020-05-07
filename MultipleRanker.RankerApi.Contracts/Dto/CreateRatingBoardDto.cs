using System;
using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class CreateRatingBoardDto
    {
        [DataMember]
        public string Name { get; }

        [DataMember]
        public RatingBoardType Type { get; set; }

        [DataMember]
        public RatingBoardSubType SubType { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }
    }
}
