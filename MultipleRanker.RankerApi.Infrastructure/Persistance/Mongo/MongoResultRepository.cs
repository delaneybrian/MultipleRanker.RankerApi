using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    public class MongoResultRepository : IResultRepository
    {  
        private readonly IMongoCollection<ResultEntity> _resultsCollection;

        public MongoResultRepository()
        {
            var client = new MongoClient(
                "mongodb://briandelaney:.$RC2SpD2Zsh!eM@ds016148.mlab.com:16148/multipleranker?retryWrites=false"
            );

            var database = client.GetDatabase("multipleranker");

            _resultsCollection = database.GetCollection<ResultEntity>("results");
        }

        public async Task AddResult(Result result)
        {
            await _resultsCollection
                .InsertOneAsync(result.ToResultEntity());
        }

        public async Task RemoveResult(Guid resultId)
        {
            await _resultsCollection
                .DeleteOneAsync(x => x.Id == resultId.ToString());
        }

        public async Task AddRatingBoardToResult(Guid resultId, Guid ratingBoardId)
        {
            var filterDefinitionBuilder = new FilterDefinitionBuilder<ResultEntity>();

            var updateDefinitionBuilder = new UpdateDefinitionBuilder<ResultEntity>();

            await _resultsCollection
                .FindOneAndUpdateAsync(
                    filterDefinitionBuilder.Eq(x => x.Id,resultId.ToString()),
                    updateDefinitionBuilder.Push(x => x.RatingBoardIdsAppliedTo, ratingBoardId.ToString()));
        }

        public async Task RemoveRatingBoardFromResult(Guid resultId, Guid ratingBoardId)
        {
            var filterDefinitionBuilder = new FilterDefinitionBuilder<ResultEntity>();

            var updateDefinitionBuilder = new UpdateDefinitionBuilder<ResultEntity>();

            await _resultsCollection
                .FindOneAndUpdateAsync(
                    filterDefinitionBuilder.Eq(x => x.Id, resultId.ToString()),
                    updateDefinitionBuilder.Pull(x=> x.RatingBoardIdsAppliedTo, ratingBoardId.ToString()));
        }

        public async Task<ICollection<Result>> GetResultsForRatingBoard(Guid ratingBoardId)
        {
            var results = new List<Result>();

            var filterDefinitionBuilder = new FilterDefinitionBuilder<ResultEntity>();

            var items = await _resultsCollection
                .FindAsync(
                    filterDefinitionBuilder.AnyEq(x => x.RatingBoardIdsAppliedTo, ratingBoardId.ToString()));

            await items.ForEachAsync(i => results.Add(i.ToResult()));

            return results;
        }
    }
}
