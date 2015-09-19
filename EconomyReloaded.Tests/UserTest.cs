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
    //  [Test]
    //  public void EnsureUserIdsAreIncrementedBy100()
    //  {
    //    var mock = new MockUserRepository();
    //    var service = new UserService(mock);

    //    var incrementedUsers = service.Increment();

    //    Assert.AreEqual(101, incrementedUsers.First().UserId);
    //  }
    //}

    //public class MockUserRepository : IUserRepository
    //{
    //  public IEnumerable<UserDetails> GetAllUsers()
    //  {
    //     return new List<UserDetails>() { new UserDetails {Email = "test", FirstName = "test", UserId = 1, LastName = "test"} };
    //  }

    //  public UserDetails GetUserById(int userId)
    //  {
    //    throw new NotImplementedException();
    //  }
    //}
  }
}
