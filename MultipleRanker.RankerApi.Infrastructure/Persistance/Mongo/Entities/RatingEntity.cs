using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.Entities
{
    [DataContract]
    public class RatingEntity
    {
        [BsonId]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime CalculatedAtUtc { get; set; }

        [DataMember]
        public ICollection<ParticipantRatingEntity> ParticipantRatingEntities { get; set; }
    }
}
