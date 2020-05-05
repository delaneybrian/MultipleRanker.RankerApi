using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    [DataContract]
    public class HistoricalRatingsEntity
    {
        [BsonId]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public DateTime CalculatedAtUtc { get; set; }

        [DataMember]
        public TriggerType TriggerType { get; set; }

        [DataMember]
        public ICollection<ParticipantRatingEntity> ParticipantRatings { get; set; }
    }
}
