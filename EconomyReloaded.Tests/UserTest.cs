using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factories.User;
using EconomyReloaded.Core.Models.User;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Services.User;
using NUnit.Framework;

namespace EconomyReloaded.Tests
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void GetAllReturnsAllUsers()
        {
            var service = new FakeUserService();

            var result = service.GetAllUsers();

            Assert.IsNotNull(result);
        }
    }

    class FakeUserService : IUserService
    {
        public IEnumerable<UserDetails> GetAllUsers()
        {
            MockUserRepository repo = new MockUserRepository();
            return repo.GetAllUsers();
        }

        public UserDetails GetById(int userId)
        {
            throw new NotImplementedException();
        }
    }

    class MockUserRepository : IUserRepository
    {
        private List<UserDetails> _db = new List<UserDetails> { new UserDetails { FirstName = "jesper", LastName = "dahlberg", UserId = 1, Email = "jesdah@test.com" } };

        public IEnumerable<UserDetails> GetAllUsers()
        {
            return _db.ToList();
        }

        public UserDetails GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }


}
