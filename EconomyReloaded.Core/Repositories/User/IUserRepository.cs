using System.Collections.Generic;

namespace EconomyReloaded.Core.Repositories.User
{
    public interface IUserRepository
    {
        IEnumerable<Models.User.UserDetails> GetAllUsers();
        Models.User.UserDetails GetUserById(int userId);
    }
}