using System.Data.SqlClient;

namespace EconomyReloaded.Core.Factories.User
{
    public interface IUserFactory
    {
        Models.User.UserDetails CreateUser(SqlDataReader reader);
    }
}