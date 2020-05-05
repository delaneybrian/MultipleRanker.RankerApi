using System;
using System.Collections.Generic;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;
using TriggerType = MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.TriggerType;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class HistoricalRatingsEntityMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void HistoricalRatingsMapsCorrectly() =>
            _context
                .SetHistoricalRatingsId(Guid.NewGuid())
                .SetRatingBoardId(Guid.NewGuid())
                .SetRatingListId(Guid.NewGuid())
                .ArrangeHistoricalRating(Contracts.TriggerType.Manual)
                .MapToHistoricalRatingsEntity()
                .AssertHistoricalRatingsMappedCorrectly(TriggerType.Manual);

        [Test]
        public void HistoricalRatingsEntityMapsCorrectly() =>
            _context
                .SetHistoricalRatingsId(Guid.NewGuid().ToString())
                .SetRatingBoardId(Guid.NewGuid().ToString())
                .SetRatingListId(Guid.NewGuid().ToString())
                .ArrangeHistoricalRatingEntity(TriggerType.Manual)
                .MapToHistoricalRatings()
                .AssertHistoricalRatingsEntityMappedCorrectly(Contracts.TriggerType.Manual);

        public class TestContext
        {
            private HistoricalRating _historicalRatings;
            private HistoricalRatingsEntity _historicalRatingsEntity;

            private string _historicalRatingsIdString;
            private Guid _historicalRatingsIdGuid;
            private DateTime _calculatedAtUtc;

            private Guid _ratingBoardIdGuid;
            private string _ratingBoardIdString;
            private Guid _ratingListIdGuid;
            private string _ratingListIdString;

            public TestContext SetCalculatedAtTime(DateTime calculatedAtUtc)
            {
                _calculatedAtUtc = calculatedAtUtc;

                return this;
            }

            public TestContext SetHistoricalRatingsId(string historicalRatingsId)
            {
                _historicalRatingsIdString = historicalRatingsId;

                return this;
            }

            public TestContext SetHistoricalRatingsId(Guid historicalRatingsId)
            {
                _historicalRatingsIdGuid = historicalRatingsId;

                return this;
            }

            public TestContext SetRatingBoardId(string ratingBoardId)
            {
                _ratingBoardIdString = ratingBoardId;

                return this;
            }

            public TestContext SetRatingBoardId(Guid ratingBoardId)
            {
                _ratingBoardIdGuid = ratingBoardId;

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

            public TestContext ArrangeHistoricalRatingEntity(TriggerType triggerType)
            {
                _historicalRatingsEntity = new HistoricalRatingsEntity
                {
                    Id = _historicalRatingsIdString,
                    CalculatedAtUtc = _calculatedAtUtc,
                    TriggerType = triggerType,
                    RatingBoardId = _ratingBoardIdString,
                    RatingListId = _ratingListIdString,
                    ParticipantRatings = new List<ParticipantRatingEntity>
                    {
                        new ParticipantRatingEntity()
                    }
                };

                return this;
            }

            public TestContext ArrangeHistoricalRating(Contracts.TriggerType triggerType)
            {
                _historicalRatings = new HistoricalRating
                {
                    Id = _historicalRatingsIdGuid,
                    CalculatedAtUtc = _calculatedAtUtc,
                    TriggerType = triggerType,
                    RatingListId = _ratingListIdGuid,
                    RatingBoardId = _ratingBoardIdGuid,
                    ParticipantRatings = new List<ParticipantRating>
                    {
                        new ParticipantRating()
                    }
                };

                return this;
            }

            public TestContext MapToHistoricalRatingsEntity()
            {
                _historicalRatingsEntity = MongoRatingsMapper.ToHistoricalRatingsEntity(_historicalRatings);

                return this;
            }

            public TestContext MapToHistoricalRatings()
            {
                _historicalRatings = MongoRatingsMapper.ToHistoricalRatings(_historicalRatingsEntity);

                return this;
            }

            public TestContext AssertHistoricalRatingsMappedCorrectly(TriggerType expectedTriggerType)
            {
                Assert.AreEqual(_historicalRatingsIdGuid.ToString(), _historicalRatingsEntity.Id);
                Assert.AreEqual(_ratingBoardIdGuid.ToString(), _historicalRatingsEntity.RatingBoardId);
                Assert.AreEqual(_ratingListIdGuid.ToString(), _historicalRatingsEntity.RatingListId);
                Assert.AreEqual(1, _historicalRatingsEntity.ParticipantRatings.Count);
                Assert.AreEqual(expectedTriggerType, _historicalRatingsEntity.TriggerType);

                return this;
            }

            public TestContext AssertHistoricalRatingsEntityMappedCorrectly(Contracts.TriggerType expectedTriggerType)
            {
                Assert.AreEqual(Guid.Parse(_historicalRatingsIdString), _historicalRatings.Id);
                Assert.AreEqual(Guid.Parse(_ratingBoardIdString), _historicalRatings.RatingBoardId);
                Assert.AreEqual(Guid.Parse(_ratingListIdString), _historicalRatings.RatingListId);
                Assert.AreEqual(1, _historicalRatings.ParticipantRatings.Count);
                Assert.AreEqual(expectedTriggerType, _historicalRatings.TriggerType);

                return this;
            }
        }
    }
}
