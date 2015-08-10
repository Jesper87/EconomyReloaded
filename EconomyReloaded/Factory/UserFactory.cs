using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EconomyReloaded.Models;

namespace EconomyReloaded.Factory
{
    public class UserFactory
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