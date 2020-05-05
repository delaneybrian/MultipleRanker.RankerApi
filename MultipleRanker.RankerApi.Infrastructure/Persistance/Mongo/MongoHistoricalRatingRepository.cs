using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    public class MongoHistoricalRatingRepository : IHistoricalRatingsRepository
    {
        private readonly IMongoCollection<HistoricalRatingsEntity> _historicalRatingsCollection;

        public MongoHistoricalRatingRepository()
        {
            var client = new MongoClient(
                "mongodb://briandelaney:.$RC2SpD2Zsh!eM@ds016148.mlab.com:16148/multipleranker?retryWrites=false"
            );

            var database = client.GetDatabase("multipleranker");

            _historicalRatingsCollection = database.GetCollection<HistoricalRatingsEntity>("historicalratings");
        }

        public async Task AddHistoricalRating(HistoricalRating historicalRating)
        {
            var historicalRatingEntity = historicalRating.ToHistoricalRatingsEntity();

            await _historicalRatingsCollection.InsertOneAsync(historicalRatingEntity);
        }

        public async Task<IEnumerable<HistoricalRating>> GetAllHistoricalRatingsForRatingList(Guid ratingListId)
        {
            var historicalRatings = new List<HistoricalRating>();

            var filterDefinitionBuilder = new FilterDefinitionBuilder<HistoricalRatingsEntity>();

            var historicalRatingsEntityCursor = await _historicalRatingsCollection
                .FindAsync(filterDefinitionBuilder.Eq(x => Guid.Parse(x.Id), ratingListId));

            await historicalRatingsEntityCursor
                .ForEachAsync(re => historicalRatings.Add(re.ToHistoricalRatings()));

            return historicalRatings;
        }
    }
}
