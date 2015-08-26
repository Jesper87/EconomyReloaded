using System;
using System.Data.SqlClient;

namespace EconomyReloaded.Core.Factories.User
{
    public class UserFactory : IUserFactory
    {
        public Models.User.UserDetails CreateUser(SqlDataReader reader)
        {
            
            var user = new Models.User.UserDetails
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