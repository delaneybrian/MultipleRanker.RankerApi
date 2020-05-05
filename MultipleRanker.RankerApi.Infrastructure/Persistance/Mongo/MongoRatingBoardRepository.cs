using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    public class MongoRatingBoardRepository : IRatingBoardRepository
    {
        private readonly IMongoCollection<RatingBoardEntity> _ratingBoardCollection;

        public MongoRatingBoardRepository()
        {
            var client = new MongoClient(
                "mongodb://briandelaney:.$RC2SpD2Zsh!eM@ds016148.mlab.com:16148/multipleranker?retryWrites=false"
            );

            var database = client.GetDatabase("multipleranker");

            _ratingBoardCollection = database.GetCollection<RatingBoardEntity>("ratingboards");
        }

        public async Task AddRatingBoard(RatingBoard ratingBoard)
        {
            var ratingBoardEntity = ratingBoard.ToRatingBoardEntity();

            try
            {
                await _ratingBoardCollection.InsertOneAsync(ratingBoardEntity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task AddParticipantToRatingBoard(Guid ratingBoardId, Participant participant)
        {
            var filterDefinitionBuilder = new FilterDefinitionBuilder<RatingBoardEntity>();

            var updateDefinitionBuilder = new UpdateDefinitionBuilder<RatingBoardEntity>();

            await _ratingBoardCollection.FindOneAndUpdateAsync(
                filterDefinitionBuilder.Eq(x => x.Id, ratingBoardId.ToString()),
                updateDefinitionBuilder.Push(x => x.Participants, participant.ToParticipantEntity()));
        }

        public async Task AddRatingListToRatingBoard(Guid ratingBoardId, RatingList ratingList)
        {
            var filterDefinitionBuilder = new FilterDefinitionBuilder<RatingBoardEntity>();

            var updateDefinitionBuilder = new UpdateDefinitionBuilder<RatingBoardEntity>();

            await _ratingBoardCollection.FindOneAndUpdateAsync(
                filterDefinitionBuilder.Eq(x => x.Id, ratingBoardId.ToString()),
                updateDefinitionBuilder.Push(x => x.RatingLists, ratingList.ToRatingListEntity()));
        }

        public async Task<RatingBoard> GetRatingBoard(Guid ratingBoardId)
        {
            var filterDefinitionBuilder = new FilterDefinitionBuilder<RatingBoardEntity>();

            var ratingBoardEntity = await _ratingBoardCollection
                .Find(x => x.Id == ratingBoardId.ToString())
                .SingleAsync();

            return ratingBoardEntity.ToRatingBoard();
        }
    }
}
