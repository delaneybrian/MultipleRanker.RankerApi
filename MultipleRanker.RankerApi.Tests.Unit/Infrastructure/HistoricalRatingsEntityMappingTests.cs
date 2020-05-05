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
                .ArrangeHistoricalRating(Contracts.TriggerType.Manual)
                .MapToHistoricalRatingsEntity()
                .AssertHistoricalRatingsMappedCorrectly(TriggerType.Manual);

        [Test]
        public void HistoricalRatingsEntityMapsCorrectly() =>
            _context
                .SetHistoricalRatingsId(Guid.NewGuid().ToString())
                .ArrangeHistoricalRatingEntity(TriggerType.Manual)
                .MapToHistoricalRatings()
                .AssertHistoricalRatingsEntityMappedCorrectly(Contracts.TriggerType.Manual);

        public class TestContext
        {
            private HistoricalRatings _historicalRatings;
            private HistoricalRatingsEntity _historicalRatingsEntity;

            private string _historicalRatingsIdString;
            private Guid _historicalRatingsIdGuid;
            private DateTime _calculatedAtUtc;

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

            public TestContext ArrangeHistoricalRatingEntity(TriggerType triggerType)
            {
                _historicalRatingsEntity = new HistoricalRatingsEntity
                {
                    Id = _historicalRatingsIdString,
                    CalculatedAtUtc = _calculatedAtUtc,
                    TriggerType = triggerType,
                    ParticipantRatings = new List<ParticipantRatingEntity>
                    {
                        new ParticipantRatingEntity()
                    }
                };

                return this;
            }

            public TestContext ArrangeHistoricalRating(Contracts.TriggerType triggerType)
            {
                _historicalRatings = new HistoricalRatings
                {
                    Id = _historicalRatingsIdGuid,
                    CalculatedAtUtc = _calculatedAtUtc,
                    TriggerType = triggerType,
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
                Assert.AreEqual(1, _historicalRatingsEntity.ParticipantRatings.Count);
                Assert.AreEqual(expectedTriggerType, _historicalRatingsEntity.TriggerType);

                return this;
            }

            public TestContext AssertHistoricalRatingsEntityMappedCorrectly(Contracts.TriggerType expectedTriggerType)
            {
                Assert.AreEqual(Guid.Parse(_historicalRatingsIdString), _historicalRatings.Id);
                Assert.AreEqual(1, _historicalRatings.ParticipantRatings.Count);
                Assert.AreEqual(expectedTriggerType, _historicalRatings.TriggerType);

                return this;
            }
        }
    }
}
