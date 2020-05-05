using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    [DataContract]
    public class RatingBoardEntity
    {
        [BsonId]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public RatingBoardType Type { get; set; }

        [DataMember]
        public RatingBoardSubType SubType { get; set; }

        [DataMember]
        public DateTime CreatedAtUtc { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public ICollection<RatingListEntity> RatingLists { get; set; }

        [DataMember]
        public ICollection<ParticipantEntity> Participants { get; set; }

        //[DataMember]
        //public ICollection<ResultEntity> AppliedResults { get; set; }
    }
}
