using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    [DataContract]
    public class ResultEntity
    {
        [BsonId]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public ICollection<ParticipantResultEntity> ParticipantResults { get; set; }

        [DataMember]
        public ICollection<string> RatingBoardIdsAppliedTo { get; set; }
    }
}
