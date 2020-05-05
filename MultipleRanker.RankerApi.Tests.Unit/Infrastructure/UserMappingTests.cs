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
                .SetName("Test")
                .SetUserId(Guid.NewGuid().ToString())
                .ArrangeUser()
                .MapToUserEntity();

        [Test]
        public void UserEntityMapsCorrectly() =>
            _context
                .SetName("Test")
                .SetUserId(Guid.NewGuid())
                .ArrangeUser()
                .MapToUserEntity();

        public class TestContext
        {
            private User _user;
            private UserEntity _userEntity;

            private string _userIdString;
            private Guid _userIdGuid;
            private string _name;

            public TestContext SetUserId(string userId)
            {
                _userIdString = userId;

                return this;
            }

            public TestContext SetUserId(Guid userId)
            {
                _userIdGuid = userId;

                return this;
            }

            public TestContext SetName(string name)
            {
                _name = name;

                return this;
            }

            public TestContext ArrangeUser()
            {
                _user = new User
                {
                    Id = _userIdGuid,
                    ParticipantIds = new List<Guid>
                    {
                        Guid.NewGuid()
                    },
                    Name = _name,
                    RatingBoardIds = new List<Guid>
                    {
                        Guid.NewGuid()
                    }
                };

                return this;
            }
            public TestContext ArrangeUserEntity()
            {
                _userEntity = new UserEntity
                {
                    Id = _userIdString,
                    ParticipantIds = new List<string>
                    {
                        Guid.NewGuid().ToString()
                    },
                    Name = _name,
                    RatingBoardIds = new List<string>
                    {
                        Guid.NewGuid().ToString()
                    }
                };

                return this;
            }

            public TestContext MapToUserEntity()
            {
                _userEntity = _user.ToUserEntity();

                return this;
            }

            public TestContext MapToUser()
            {
                _user = _userEntity.ToUser();

                return this;
            }

            public TestContext AssertUserMapsCorrectly()
            {
                Assert.AreEqual(_userIdString, _userEntity.Id);
                Assert.AreEqual(_name, _userEntity.Name);
                Assert.AreEqual(1, _userEntity.ParticipantIds.Count);
                Assert.AreEqual(1, _userEntity.RatingBoardIds.Count);

                return this;
            }

            public TestContext AssertUserEntityMapsCorrectly()
            {
                Assert.AreEqual(_userIdGuid, _user.Id);
                Assert.AreEqual(_name, _user.Name);
                Assert.AreEqual(1, _user.ParticipantIds.Count);
                Assert.AreEqual(1, _user.RatingBoardIds.Count);

                return this;
            }
        }
    }
}
