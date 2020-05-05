using AutoMapper;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    internal static class MongoRatingsMapper
    {
        internal static IMapper _mapper;

        static MongoRatingsMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RatingBoardEntity, RatingBoard>();

                cfg.CreateMap<RatingBoard, RatingBoardEntity>();

                cfg.CreateMap<RatingListEntity, RatingList>();

                cfg.CreateMap<RatingList, RatingListEntity>();

                cfg.CreateMap<HistoricalRatingsEntity, HistoricalRatings>();

                cfg.CreateMap<HistoricalRatings, HistoricalRatingsEntity>();

                cfg.CreateMap<ParticipantRatingEntity, ParticipantRating>();

                cfg.CreateMap<ParticipantRating, ParticipantRatingEntity>();

                cfg.CreateMap<UserEntity, User>();
                
                cfg.CreateMap<User, UserEntity>();

                cfg.CreateMap<ParticipantEntity, Participant>();

                cfg.CreateMap<Participant, ParticipantEntity>();
            });

            config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();
        }

        internal static UserEntity ToUserEntity(this User user)
        {
            return _mapper.Map<UserEntity>(user);
        }

        internal static User ToUser(this UserEntity userEntity)
        {
            return _mapper.Map<User>(userEntity);
        }

        internal static ParticipantRatingEntity ToParticipantRatingEntity(this ParticipantRating participantRating)
        {
            return _mapper.Map<ParticipantRatingEntity>(participantRating);
        }

        internal static ParticipantRating ToParticipantRating(this ParticipantRatingEntity participantRatingEntity)
        {
            return _mapper.Map<ParticipantRating>(participantRatingEntity);
        }

        internal static HistoricalRatingsEntity ToHistoricalRatingsEntity(this HistoricalRatings historicalRatings)
        {
            return _mapper.Map<HistoricalRatingsEntity>(historicalRatings);
        }

        internal static HistoricalRatings ToHistoricalRatings(this HistoricalRatingsEntity historicalRatingsEntity)
        {
            return _mapper.Map<HistoricalRatings>(historicalRatingsEntity);
        }
    }
}
