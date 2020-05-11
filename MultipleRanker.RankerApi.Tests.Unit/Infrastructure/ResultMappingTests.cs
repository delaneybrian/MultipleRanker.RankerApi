using System;
using System.Collections.Generic;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class ResultMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void ResultMapsCorrectly() =>
            _context
                .SetResultId(Guid.NewGuid())
                .ArrangeResult()
                .MapToResultEntity()
                .AssertAreEqual();

        [Test]
        public void ResultEntityMapsCorrectly() =>
            _context
                .SetResultId(Guid.NewGuid().ToString())
                .ArrangeResultEntity()
                .MapToResult()
                .AssertAreEqual();

        public class TestContext
        {
            private Result _result;
            private ResultEntity _resultEntity;

            private string _resultIdString;
            private Guid _resultIdGuid;
            private DateTime _resultTimeUtc;

            public TestContext SetResultId(string result)
            {
                _resultIdString = result;

                return this;
            }

            public TestContext SetResultTime(DateTime resultTimeUtc)
            {
                _resultTimeUtc = resultTimeUtc;

                return this;
            }

            public TestContext SetResultId(Guid result)
            {
                _resultIdGuid = result;

                return this;
            }

            public TestContext ArrangeResult()
            {
                _result = new Result
                {
                    Id = _resultIdGuid,
                    ParticipantResults = new List<ParticipantResult>
                    {
                        new ParticipantResult()
                    },
                    RatingBoardIdsAppliedTo = new List<Guid>
                    {
                        Guid.NewGuid()
                    },
                    ResultTimeUtc = _resultTimeUtc
                };

                return this;
            }
            public TestContext ArrangeResultEntity()
            {
                _resultEntity = new ResultEntity
                {
                    Id = _resultIdString,
                    ParticipantResults = new List<ParticipantResultEntity>
                    {
                        new ParticipantResultEntity()
                    },
                    RatingBoardIdsAppliedTo = new List<string>
                    {
                        Guid.NewGuid().ToString()
                    },
                    ResultTimeUtc = _resultTimeUtc
                };

                return this;
            }

            public TestContext MapToResultEntity()
            {
                _resultEntity = _result.ToResultEntity();

                return this;
            }

            public TestContext MapToResult()
            {
                _result = _resultEntity.ToResult();

                return this;
            }

            public TestContext AssertAreEqual()
            {
                Assert.AreEqual(_result.Id.ToString(), _resultEntity.Id);
                Assert.AreEqual(_result.ParticipantResults.Count, _resultEntity.ParticipantResults.Count);
                Assert.AreEqual(_result.RatingBoardIdsAppliedTo.Count, _resultEntity.RatingBoardIdsAppliedTo.Count);
                Assert.AreEqual(_result.ResultTimeUtc, _resultEntity.ResultTimeUtc);

                return this;
            }        
        }
    }
}
