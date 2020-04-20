using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.Entities;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    public class MongoRatingsRepository : IRatingsRepository
    {
        private readonly IMongoCollection<RatingsEntity> _ratingsCollection;

        public MongoRatingsRepository()
        {
            var client = new MongoClient(
                "mongodb://briandelaney:.$RC2SpD2Zsh!eM@ds016148.mlab.com:16148/multipleranker?retryWrites=false"
            );

            var database = client.GetDatabase("multipleranker");

            _ratingsCollection = database.GetCollection<RatingsEntity>("ratings");
        }

        public async Task AddRating(Guid id, Rating rating)
        {
            try
            {
                var filterDefinitionBuilder = new FilterDefinitionBuilder<RatingsEntity>();

                var updateDefinitionBuilder = new UpdateDefinitionBuilder<RatingsEntity>();

                await _ratingsCollection.FindOneAndUpdateAsync(
                    filterDefinitionBuilder.Eq(x => x.Id, id),
                    updateDefinitionBuilder.Push(x => x.PreviousRatings, rating.ToRatingEntity()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Rating> GetLatestRating(Guid id)
        {
            try
            {
                var ratingEntities = new List<RatingsEntity>();

                var filterDefinitionBuilder = new FilterDefinitionBuilder<RatingsEntity>();

                var ratingsEntityCursor = await _ratingsCollection
                    .FindAsync(filterDefinitionBuilder.Eq(x => x.Id, id));

                await ratingsEntityCursor.ForEachAsync(re => ratingEntities.Add(re));

                var ratingEntity = ratingEntities.Single(x => x.Id == id);

                return ratingEntity
                    .PreviousRatings
                    .OrderByDescending(x => x.CalculatedAtUtc)
                    .First()
                    .ToRating();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Ratings> GetAllRatings(Guid id)
        {
            try
            {
                var ratingEntities = new List<RatingsEntity>();

                var filterDefinitionBuilder = new FilterDefinitionBuilder<RatingsEntity>();

                var ratingsEntityCursor = await _ratingsCollection
                    .FindAsync(filterDefinitionBuilder.Eq(x => x.Id, id));

                await ratingsEntityCursor.ForEachAsync(re => ratingEntities.Add(re));

                var ratingEntity = ratingEntities.Single(x => x.Id == id);

                return ratingEntity.ToRatings();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
