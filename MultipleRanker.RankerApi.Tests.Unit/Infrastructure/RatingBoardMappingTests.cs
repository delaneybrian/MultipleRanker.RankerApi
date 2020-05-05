using System;
using System.Collections.Generic;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;
using RatingBoardSubType = MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.RatingBoardSubType;
using RatingBoardType = MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo.RatingBoardType;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class RatingBoardMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void RatingBoardMapsCorrectly() =>
            _context
                .SetRatingBoardId(Guid.NewGuid())
                .SetCreatedOnAtTime(DateTime.UtcNow)
                .SetCreatedBy(Guid.NewGuid())
                .ArrangeratingBoard(Contracts.RatingBoardType.Sport, Contracts.RatingBoardSubType.Rugby)
                .MapToRatingBoardEntity()
                .AssertRatingBoardMappedCorrectly(RatingBoardType.Sport, RatingBoardSubType.Rugby);

        [Test]
        public void RatingBoardEntityMapsCorrectly() =>
            _context
                .SetRatingBoardId(Guid.NewGuid().ToString())
                .SetCreatedOnAtTime(DateTime.UtcNow)
                .SetCreatedBy(Guid.NewGuid().ToString())
                .ArrangeRatingBoardEntity(RatingBoardType.Sport, RatingBoardSubType.Rugby)
                .MapToRatingBoard()
                .AssertRatingBoardEntityMappedCorrectly(Contracts.RatingBoardType.Sport, Contracts.RatingBoardSubType.Rugby);

        public class TestContext
        {
            private RatingBoard _ratingBoard;
            private RatingBoardEntity _ratingBoardEntity;

            private string _ratingBoardIdString;
            private Guid _ratingBoardIdGuid;

            private string _createdByIdString;
            private Guid _createdByIdGuid;

            private DateTime _createdOnUtc;

            public TestContext SetCreatedOnAtTime(DateTime createdOnUtc)
            {
                _createdOnUtc = createdOnUtc;

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

            public TestContext SetCreatedBy(string createdById)
            {
                _createdByIdString = createdById;

                return this;
            }

            public TestContext SetCreatedBy(Guid createdById)
            {
                _createdByIdGuid = createdById;

                return this;
            }

            public TestContext ArrangeRatingBoardEntity(
                RatingBoardType ratingBoardType,
                RatingBoardSubType ratingBoardSubType)
            {
                _ratingBoardEntity = new RatingBoardEntity
                {
                    Id = _ratingBoardIdString,
                    Type = ratingBoardType,
                    SubType = ratingBoardSubType,
                    CreatedAtUtc = _createdOnUtc,
                    CreatedBy = _createdByIdString,
                    ParticipantEntities = new List<ParticipantEntity>
                    {
                        new ParticipantEntity()
                    },
                    RatingLists = new List<RatingListEntity>
                    {
                        new RatingListEntity()
                    }
                };

                return this;
            }

            public TestContext ArrangeratingBoard(
                Contracts.RatingBoardType ratingBoardType,
                Contracts.RatingBoardSubType ratingBoardSubType)
            {
                _ratingBoard = new RatingBoard
                {
                    Id = _ratingBoardIdGuid,
                    Type = ratingBoardType,
                    SubType = ratingBoardSubType,
                    CreatedAtUtc = _createdOnUtc,
                    CreatedBy = _createdByIdGuid,
                    ParticipantEntities = new List<Participant>
                    {
                        new Participant()
                    },
                    RatingLists = new List<RatingList>
                    {
                        new RatingList()
                    }
                };

                return this;
            }

            public TestContext MapToRatingBoardEntity()
            {
                _ratingBoardEntity = _ratingBoard.ToRatingBoardEntity();

                return this;
            }

            public TestContext MapToRatingBoard()
            {
                _ratingBoard = _ratingBoardEntity.ToRatingBoard();

                return this;
            }

            public TestContext AssertRatingBoardMappedCorrectly(
                RatingBoardType expectedRatingBoardType,
                RatingBoardSubType expectedRatingBoardSubType)
            {
                Assert.AreEqual(_createdOnUtc, _ratingBoardEntity.CreatedAtUtc);
                Assert.AreEqual(_ratingBoardIdGuid.ToString(), _ratingBoardEntity.Id);
                Assert.AreEqual(_createdByIdGuid.ToString(), _ratingBoardEntity.CreatedBy);
                Assert.AreEqual(1, _ratingBoardEntity.RatingLists.Count);
                Assert.AreEqual(1, _ratingBoardEntity.ParticipantEntities.Count);
                Assert.AreEqual(expectedRatingBoardType, _ratingBoardEntity.Type);
                Assert.AreEqual(expectedRatingBoardSubType, _ratingBoardEntity.SubType);

                return this;
            }

            public TestContext AssertRatingBoardEntityMappedCorrectly(
                Contracts.RatingBoardType expectedRatingBoardType,
                Contracts.RatingBoardSubType expectedRatingBoardSubType)
            {
                Assert.AreEqual(_createdOnUtc, _ratingBoard.CreatedAtUtc);
                Assert.AreEqual(Guid.Parse(_createdByIdString), _ratingBoard.CreatedBy);
                Assert.AreEqual(Guid.Parse(_ratingBoardIdString), _ratingBoard.Id);
                Assert.AreEqual(1, _ratingBoard.RatingLists.Count);
                Assert.AreEqual(1, _ratingBoardEntity.ParticipantEntities.Count);
                Assert.AreEqual(expectedRatingBoardType, _ratingBoard.Type);
                Assert.AreEqual(expectedRatingBoardSubType, _ratingBoard.SubType);

                return this;
            }
        }
    }
}
