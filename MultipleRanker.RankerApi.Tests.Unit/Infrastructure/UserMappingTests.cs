using System;
using System.Collections.Generic;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using NUnit.Framework;

namespace MultipleRanker.RankerApi.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class UserMappingTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void UserMapsCorrectly() =>
            _context
                .ArrangeUser()
                .MapToUserEntity();

        public class TestContext
        {
            private User _user;
            private UserEntity _userEntity;

            public TestContext ArrangeUser()
            {
                _user = new User
                {
                    Id = Guid.NewGuid(),
                    ParticipantIds = new List<Guid>
                    {
                        Guid.NewGuid()
                    },
                    Name = "Test",
                    RatingBoardIds = new List<Guid>
                    {
                        Guid.NewGuid()
                    }
                };

                return this;
            }

            public TestContext MapToUserEntity()
            {
                _userEntity = MongoRatingsMapper.ToUserEntity(_user);

                return this;
            }
        }
    }
}
