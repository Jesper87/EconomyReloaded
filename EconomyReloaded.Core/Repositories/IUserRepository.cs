using System.Collections.Generic;
using EconomyReloaded.Core.Models;

namespace EconomyReloaded.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
    }
}