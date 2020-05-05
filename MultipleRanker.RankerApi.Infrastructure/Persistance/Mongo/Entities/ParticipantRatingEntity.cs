using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    [DataContract]
    public class ParticipantRatingEntity
    {
        [DataMember]
        public string ParticipantId { get; set; }

        [DataMember]
        public double Rating { get; set; }
    }
}
