using MongoDB.Driver;
using MultipleRanker.RankerApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    public class MongoResultRespository : IResultRepository
    {  
        private readonly IMongoCollection<RatingBoardEntity> _ratingBoardCollection;

        public MongoResultRespository()
        {
            var client = new MongoClient(
                "mongodb://briandelaney:.$RC2SpD2Zsh!eM@ds016148.mlab.com:16148/multipleranker?retryWrites=false"
            );

            var database = client.GetDatabase("multipleranker");

            _ratingBoardCollection = database.GetCollection<RatingBoardEntity>("results");
        }
    }
}
