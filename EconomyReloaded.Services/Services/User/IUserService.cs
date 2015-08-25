using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyReloaded.Services.Services.User
{
    public interface IUserService
    {
        IEnumerable<Core.Models.User.UserDetails> GetAllUsers();
        Core.Models.User.UserDetails GetById(int userId);
    }
}
