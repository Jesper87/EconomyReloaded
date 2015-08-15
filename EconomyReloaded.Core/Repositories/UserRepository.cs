using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factories;
using EconomyReloaded.Core.Models;

namespace EconomyReloaded.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnection _databaseConnection;
        private readonly IUserFactory _userFactory;

        public UserRepository(IDatabaseConnection databaseConnection, IUserFactory userFactory)
        {
            this._databaseConnection = databaseConnection;
            this._userFactory = userFactory;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();

            if (!string.IsNullOrEmpty(_databaseConnection.ConnectionString))
            {
                try
                {
                    using (var connection = new SqlConnection(_databaseConnection.ConnectionString))
                    {
                        connection.Open();
                        var command = new SqlCommand("SELECT [UserId],[Email],[FirstName],[LastName] FROM [dbo].[Users]", connection);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var user = _userFactory.CreateUser(reader);
                                    users.Add(user);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return users;
        }
    }
}