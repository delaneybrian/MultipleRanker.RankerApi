using System;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class ParticipantResultMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void ParticipantResultMapsCorrectly() =>
            _context
                .SetScore(23)
                .SetParticipantId(Guid.NewGuid().ToString())
                .ArrangeParticipantResult()
                .MapToParticipant();

        [Test]
        public void ParticipantResultEntityMapsCorrectly() =>
            _context
                .SetScore(23)
                .SetParticipantId(Guid.NewGuid())
                .ArrangeParticipantResult()
                .MapToParticipantResultEntity();

        public class TestContext
        {
            private ParticipantResult _participantResult;
            private ParticipantResultEntity _participantResultEntity;

            private string _participantIdString;
            private Guid _participantIdGuid;
            private double _score;
      
            public TestContext SetScore(double score)
            {
                _score = score;

                return this;
            }

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

            public TestContext ArrangeParticipantResult()
            {
                _participantResult = new ParticipantResult
                {
                    ParticipantId = _participantIdGuid,
                    Score = _score
                };

                return this;
            }
            public TestContext ArrangeParticipantResultEntity()
            {
                _participantResultEntity = new ParticipantResultEntity
                {
                    ParticipantId = _participantIdString,
                    Score = _score
                };

                return this;
            }

            public TestContext MapToParticipantResultEntity()
            {
                _participantResultEntity = _participantResult.ToParticipantResultEntity();

                return this;
            }

            public TestContext MapToParticipant()
            {
                _participantResult = _participantResultEntity.ToParticipantResult();

                return this;
            }

            public TestContext AssertAreEqual()
            {
                Assert.AreEqual(_participantResult.ParticipantId.ToString(), _participantResultEntity.ParticipantId);
                Assert.AreEqual(_participantResult.ParticipantId, _participantResultEntity.Score);

                return this;
            }
        }
    }
}
