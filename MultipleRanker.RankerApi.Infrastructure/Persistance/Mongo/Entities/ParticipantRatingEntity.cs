using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.Entities
{
    [DataContract]
    public class ParticipantRatingEntity
    {
        [BsonId]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public double Rating { get; set; }
    }
}
