using System.Data.SqlClient;

namespace EconomyReloaded.Core.Factory.User
{
    public interface IUserFactory
    {
        Models.User.UserDetails CreateUser(SqlDataReader reader);
    }
}