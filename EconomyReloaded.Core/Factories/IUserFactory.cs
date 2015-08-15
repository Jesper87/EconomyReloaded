using System.Data.SqlClient;
using EconomyReloaded.Core.Models;

namespace EconomyReloaded.Core.Factories
{
    public interface IUserFactory
    {
        User CreateUser(SqlDataReader reader);
    }
}