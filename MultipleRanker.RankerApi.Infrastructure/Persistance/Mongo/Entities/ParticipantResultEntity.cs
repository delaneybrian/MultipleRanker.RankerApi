using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    [DataContract]
    public class ParticipantResultEntity
    {
        [DataMember]
        public string ParticipantId { get; set; }

        [DataMember]
        public double Score { get; set; }
    }
}
