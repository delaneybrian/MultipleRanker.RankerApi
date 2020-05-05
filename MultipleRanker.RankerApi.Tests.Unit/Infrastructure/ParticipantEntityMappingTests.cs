using System;
using System.Collections.Generic;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class ParticipantEntityMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void ParticipantMapsCorrectly() =>
            _context
                .SetParticipantId(Guid.NewGuid())
                .SetCreatedById(Guid.NewGuid())
                .SetCreatedOnTime(DateTime.UtcNow)
                .SetName("Test")
                .ArrangeParticipant()
                .MapToParticipantEntity()
                .AssertParticipantMappedCorrectly();

        [Test]
        public void ParticipantEntityMapsCorrectly() =>
            _context
                .SetParticipantId(Guid.NewGuid().ToString())
                .SetCreatedById(Guid.NewGuid().ToString())
                .SetCreatedOnTime(DateTime.UtcNow)
                .SetName("Test")
                .ArrangeParticipantEntity()
                .MapToParticipant()
                .AssertParticipantEntityMappedCorrectly();

        public class TestContext
        {
            private Participant _participant;
            private ParticipantEntity _participantEntity;

            private string _name;
            private DateTime _createdOnTime;
            private string _participantIdString;
            private Guid _participantIdGuid;
            private string _createdByIdString;
            private Guid _createdByIdGuid;

            public TestContext SetName(string name)
            {
                _name = name;

                return this;
            }

            public TestContext SetCreatedOnTime(DateTime createdOnTime)
            {
                _createdOnTime = createdOnTime;

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

            public TestContext SetCreatedById(string createdBy)
            {
                _createdByIdString = createdBy;

                return this;
            }

            public TestContext SetCreatedById(Guid createdBy)
            {
                _createdByIdGuid = createdBy;

                return this;
            }

            public TestContext ArrangeParticipantEntity()
            {
                _participantEntity = new ParticipantEntity
                {
                    Id = _participantIdString,
                    Name = _name,
                    CreatedOnUtc = _createdOnTime,
                    CreatedByUserId = _createdByIdString,
                    RatingListIds = new List<string>
                    {
                        Guid.NewGuid().ToString()
                    }
                };

                return this;
            }

            public TestContext ArrangeParticipant()
            {
                _participant = new Participant
                {
                    Id = _participantIdGuid,
                    Name = _name,
                    CreatedOnUtc = _createdOnTime,
                    CreatedByUserId = _createdByIdGuid,
                    RatingListIds = new List<Guid>
                    {
                        Guid.NewGuid()
                    }
                };

                return this;
            }

            public TestContext MapToParticipantEntity()
            {
                _participantEntity = _participant.ToParticipantEntity();

                return this;
            }

            public TestContext MapToParticipant()
            {
                _participant = _participantEntity.ToParticipant();

                return this;
            }

            public TestContext AssertParticipantMappedCorrectly()
            {
                Assert.AreEqual(_participantIdGuid.ToString(), _participantEntity.Id);
                Assert.AreEqual(_createdByIdGuid.ToString(), _participantEntity.CreatedByUserId);
                Assert.AreEqual(1, _participantEntity.RatingListIds.Count);
                Assert.AreEqual(_name, _participantEntity.Name);
                Assert.AreEqual(_createdOnTime, _participant.CreatedOnUtc);

                return this;
            }

            public TestContext AssertParticipantEntityMappedCorrectly()
            {
                Assert.AreEqual(Guid.Parse(_participantIdString), _participant.Id);
                Assert.AreEqual(_createdByIdString, _participantEntity.CreatedByUserId);
                Assert.AreEqual(1, _participant.RatingListIds.Count);
                Assert.AreEqual(_name, _participant.Name);
                Assert.AreEqual(_createdOnTime, _participant.CreatedOnUtc);

                return this;
            }
        }
    }
}
