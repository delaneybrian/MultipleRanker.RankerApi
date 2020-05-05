using System;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;
using RatingType = MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.RatingType;
using RatingAggregationType = MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.RatingAggregationType;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class RatingListMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void RatingListMapsCorrectly() =>
            _context
                .SetRatingListId(Guid.NewGuid())
                .SetCreatedOnAtTime(DateTime.UtcNow)
                .ArrangeRatingList(Contracts.RatingType.Elo, Contracts.RatingAggregationType.ScoreDifference)
                .MapToRatingListEntity()
                .AssertRatingListMappedCorrectly(RatingType.Elo, RatingAggregationType.ScoreDifference);

        [Test]
        public void RatingListEntityMapsCorrectly() =>
            _context
                .SetRatingListId(Guid.NewGuid().ToString())
                .SetCreatedOnAtTime(DateTime.UtcNow)
                .ArrangeRatingListEntity(RatingType.Elo, RatingAggregationType.ScoreDifference)
                .MapToRatingList()
                .AssertRatingListEntityMappedCorrectly(Contracts.RatingType.Elo, Contracts.RatingAggregationType.ScoreDifference);

        public class TestContext
        {
            private RatingList _ratingList;
            private RatingListEntity _ratingListEntity;

            private string _ratingListIdString;
            private Guid _ratingListIdGuid;
            private DateTime _createdOnUtc;

            public TestContext SetCreatedOnAtTime(DateTime createdOnUtc)
            {
                _createdOnUtc = createdOnUtc;

                return this;
            }

            public TestContext SetRatingListId(string ratingListId)
            {
                _ratingListIdString = ratingListId;

                return this;
            }

            public TestContext SetRatingListId(Guid ratingListId)
            {
                _ratingListIdGuid = ratingListId;

                return this;
            }

            public TestContext ArrangeRatingListEntity(
                RatingType ratingType,
                RatingAggregationType ratingAggregationType)
            {
                _ratingListEntity = new RatingListEntity
                {
                    Id = _ratingListIdString,
                    CreatedOnUtc = _createdOnUtc,
                    RatingType = ratingType,
                    RatingAggregation = ratingAggregationType,
                    LatestRating = new HistoricalRatingsEntity()
                };

                return this;
            }

            public TestContext ArrangeRatingList(
                Contracts.RatingType ratingType,
                Contracts.RatingAggregationType ratingAggregationType)
            {
                _ratingList = new RatingList
                {
                    Id = _ratingListIdGuid,
                    CreatedOnUtc = _createdOnUtc,
                    RatingType = ratingType,
                    RatingAggregation = ratingAggregationType,
                    LatestRating = new HistoricalRating()
                };

                return this;
            }

            public TestContext MapToRatingListEntity()
            {
                _ratingListEntity = MongoRatingsMapper.ToRatingListEntity(_ratingList);

                return this;
            }

            public TestContext MapToRatingList()
            {
                _ratingList = MongoRatingsMapper.ToRatingList(_ratingListEntity);

                return this;
            }

            public TestContext AssertRatingListMappedCorrectly(
                RatingType expectedRatingType,
                RatingAggregationType expectedRatingAggregationType)
            {
                Assert.AreEqual(_createdOnUtc, _ratingListEntity.CreatedOnUtc);
                Assert.AreEqual(_ratingListIdGuid.ToString(), _ratingListEntity.Id);
                Assert.AreEqual(expectedRatingType, _ratingListEntity.RatingType);
                Assert.AreEqual(expectedRatingAggregationType, _ratingListEntity.RatingAggregation);

                return this;
            }

            public TestContext AssertRatingListEntityMappedCorrectly(
                Contracts.RatingType expectedRatingType,
                Contracts.RatingAggregationType expectedRatingAggregationType)
            {
                Assert.AreEqual(_createdOnUtc, _ratingList.CreatedOnUtc);
                Assert.AreEqual(Guid.Parse(_ratingListIdString), _ratingList.Id);
                Assert.AreEqual(expectedRatingType, _ratingList.RatingType);
                Assert.AreEqual(expectedRatingAggregationType, _ratingList.RatingAggregation);

                return this;
            }
        }
    }
}
