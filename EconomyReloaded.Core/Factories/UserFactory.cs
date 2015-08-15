using System;
using System.Data.SqlClient;
using EconomyReloaded.Core.Models;

namespace EconomyReloaded.Core.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(SqlDataReader reader)
        {
            var user = new User
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                Email = reader["Email"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString()
            };

            return user;
        }
    }
}