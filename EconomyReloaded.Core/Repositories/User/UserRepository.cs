using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factories;
using EconomyReloaded.Core.Factories.User;

namespace EconomyReloaded.Core.Repositories.User
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

        public IEnumerable<Models.User.UserDetails> GetAllUsers()
        {
            var users = new List<Models.User.UserDetails>();

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

        public Models.User.UserDetails GetUserById(int userId)
        {
            var selectedUser = new Models.User.UserDetails();

            if (!string.IsNullOrEmpty(_databaseConnection.ConnectionString))
            {
                try
                {
                    using (var connection = new SqlConnection(_databaseConnection.ConnectionString))
                    {
                        connection.Open();
                        var command = new SqlCommand("SELECT [UserId],[Email],[FirstName],[LastName] FROM [dbo].[Users] WHERE UserId = @userId", connection);
                        command.Parameters.Add("userId", SqlDbType.Int).Value = userId;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    selectedUser = _userFactory.CreateUser(reader);
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
            return selectedUser;
        }
    }
}