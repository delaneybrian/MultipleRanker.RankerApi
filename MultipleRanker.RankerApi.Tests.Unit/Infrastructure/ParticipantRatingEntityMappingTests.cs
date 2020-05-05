using System;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class ParticipantRatingEntityMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void ParticipantRatingMapsCorrectly() =>
            _context
                .SetParticipantId(Guid.NewGuid())
                .SetRating(100)
                .ArrangeParticipantRating()
                .MapToParticipantRatingEntity()
                .AssertParticipantRatingMappedCorrectly();

        [Test]
        public void ParticipantRatingEntityMapsCorrectly() =>
            _context
                .SetParticipantId(Guid.NewGuid().ToString())
                .SetRating(100)
                .ArrangeParticipantRatingEntity()
                .MapToParticipantRating()
                .AssertParticipantRatingEntityMappedCorrectly();

        public class TestContext
        {
            private ParticipantRating _participantRating;
            private ParticipantRatingEntity _participantRatingEntity;

            private string _participantIdString;
            private Guid _participantIdGuid;
            private double _rating;

            public TestContext SetParticipantId(string participantId)
            {
                _participantIdString = participantId;

                return this;
            }

            public TestContext SetParticipantId(Guid participantId)
            {
                _participantIdGuid = participantId;

                return this;
            }

            public TestContext SetRating(double rating)
            {
                _rating = rating;

                return this;
            }

            public TestContext ArrangeParticipantRatingEntity()
            {
                _participantRatingEntity = new ParticipantRatingEntity
                {
                    ParticipantId = _participantIdString,
                    Rating = _rating
                };

                return this;
            }

            public TestContext ArrangeParticipantRating()
            {
                _participantRating = new ParticipantRating
                {
                    ParticipantId = _participantIdGuid,
                    Rating = _rating
                };

                return this;
            }

            public TestContext MapToParticipantRatingEntity()
            {
                _participantRatingEntity = MongoRatingsMapper.ToParticipantRatingEntity(_participantRating);

                return this;
            }

            public TestContext MapToParticipantRating()
            {
                _participantRating = MongoRatingsMapper.ToParticipantRating(_participantRatingEntity);

                return this;
            }

            public TestContext AssertParticipantRatingMappedCorrectly()
            {
                Assert.AreEqual(_participantIdGuid.ToString(), _participantRatingEntity.ParticipantId);
                Assert.AreEqual(_rating, _participantRatingEntity.Rating);

                return this;
            }

            public TestContext AssertParticipantRatingEntityMappedCorrectly()
            {
                Assert.AreEqual(Guid.Parse(_participantIdString), _participantRating.ParticipantId);
                Assert.AreEqual(_rating, _participantRating.Rating);

                return this;
            }
        }
    }
}
