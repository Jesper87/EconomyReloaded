using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Exceptions;

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
            return Enumerable.Empty<Core.Models.User.UserDetails>();
        }

        public Core.Models.User.UserDetails GetById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user != null)
                return user;
            throw new UserNotFoundException("No user found on userId");
        }
    }
}
