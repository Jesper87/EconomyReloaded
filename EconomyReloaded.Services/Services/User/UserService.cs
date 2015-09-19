using System.Collections.Generic;
using EconomyReloaded.Core.Repositories.User;

namespace EconomyReloaded.Services.Services.User
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public IEnumerable<Core.Models.User.UserDetails> GetAllUsers()
    {
      var users = _userRepository.GetAllUsers();
      if (users != null)
        return users;
      return null;
    }

    public Core.Models.User.UserDetails GetById(int userId)
    {
      var user = _userRepository.GetUserById(userId);
      if (user != null)
        return user;
      return null;
    }
  }
}
