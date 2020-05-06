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

                cfg.CreateMap<HistoricalRatingsEntity, HistoricalRating>();

                cfg.CreateMap<HistoricalRating, HistoricalRatingsEntity>();

                cfg.CreateMap<ParticipantRatingEntity, ParticipantRating>();

                cfg.CreateMap<ParticipantRating, ParticipantRatingEntity>();

                cfg.CreateMap<UserEntity, User>();

                cfg.CreateMap<User, UserEntity>();

                cfg.CreateMap<ParticipantEntity, Participant>();

                cfg.CreateMap<Participant, ParticipantEntity>();

                cfg.CreateMap<ParticipantResultEntity, ParticipantResult>();

                cfg.CreateMap<ParticipantResult, ParticipantResultEntity>();

                cfg.CreateMap<ResultEntity, Result>();

                cfg.CreateMap<Result, ResultEntity>();
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

        internal static HistoricalRatingsEntity ToHistoricalRatingsEntity(this HistoricalRating historicalRatings)
        {
            return _mapper.Map<HistoricalRatingsEntity>(historicalRatings);
        }

        internal static HistoricalRating ToHistoricalRatings(this HistoricalRatingsEntity historicalRatingsEntity)
        {
            return _mapper.Map<HistoricalRating>(historicalRatingsEntity);
        }

        internal static RatingListEntity ToRatingListEntity(this RatingList ratingList)
        {
            return _mapper.Map<RatingListEntity>(ratingList);
        }

        internal static RatingList ToRatingList(this RatingListEntity ratingListEntity)
        {
            return _mapper.Map<RatingList>(ratingListEntity);
        }

        internal static RatingBoardEntity ToRatingBoardEntity(this RatingBoard ratingBoard)
        {
            return _mapper.Map<RatingBoardEntity>(ratingBoard);
        }

        internal static RatingBoard ToRatingBoard(this RatingBoardEntity ratingBoardEntity)
        {
            return _mapper.Map<RatingBoard>(ratingBoardEntity);
        }

        internal static ParticipantEntity ToParticipantEntity(this Participant participant)
        {
            return _mapper.Map<ParticipantEntity>(participant);
        }

        internal static Participant ToParticipant(this ParticipantEntity participantEntity)
        {
            return _mapper.Map<Participant>(participantEntity);
        }

        internal static ParticipantResultEntity ToParticipantResultEntity(this ParticipantResult participantResult)
        {
            return _mapper.Map<ParticipantResultEntity>(participantResult);
        }

        internal static ParticipantResult ToParticipantResult(this ParticipantResultEntity participantResultEntity)
        {
            return _mapper.Map<ParticipantResult>(participantResultEntity);
        }

        internal static ResultEntity ToResultEntity(this Result result)
        {
            return _mapper.Map<ResultEntity>(result);
        }

        internal static Result ToResult(this ResultEntity resultEntity)
        {
            return _mapper.Map<Result>(resultEntity);
        }
    }
}
