using AutoMapper;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.Entities;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    internal static class MongoRatingsMapper
    {
        internal static IMapper _mapper;

        static MongoRatingsMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RatingsEntity, Ratings>();

                cfg.CreateMap<Ratings, RatingsEntity>();

                cfg.CreateMap<RatingEntity, Rating>();

                cfg.CreateMap<Rating, RatingEntity>();

                cfg.CreateMap<ParticipantRatingEntity, ParticipantRating>();

                cfg.CreateMap<ParticipantRating, ParticipantRatingEntity>();
            });

            config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();
        }

        internal static RatingsEntity ToRatingsEntity(this Ratings ratings)
        {
            return _mapper.Map<RatingsEntity>(ratings);
        }

        internal static Ratings ToRatings(this RatingsEntity ratingsEntity)
        {
            return _mapper.Map<Ratings>(ratingsEntity);
        }

        internal static RatingEntity ToRatingEntity(this Rating rating)
        {
            return _mapper.Map<RatingEntity>(rating);
        }

        internal static Rating ToRating(this RatingEntity ratingEntity)
        {
            return _mapper.Map<Rating>(ratingEntity);
        }
    }
}
