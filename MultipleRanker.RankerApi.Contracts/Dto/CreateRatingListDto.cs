using System.Runtime.Serialization;

namespace MultipleRanker.RankerApi.Contracts
{
    [DataContract]
    public class CreateRatingListDto
    {
        [DataMember]
        public RatingType RatingType { get; set; }

        [DataMember]
        public RatingAggregationType RatingAggregation { get; set; }
    }
}
