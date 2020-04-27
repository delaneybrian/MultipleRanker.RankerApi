using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.Entities
{
    [DataContract]
    internal class RatingsEntity
    {
        [BsonId]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public ICollection<RatingEntity> PreviousRatings { get; set; }
    }
}
