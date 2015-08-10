using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using EconomyReloaded.Data;
using EconomyReloaded.Factory;
using EconomyReloaded.Models;

namespace EconomyReloaded.Repository
{
    public class UserRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        private readonly UserFactory _userFactory;

        public UserRepository()
        {
            _databaseConnection = new DatabaseConnection();
            _userFactory = new UserFactory();
        }

        public UserRepository(DatabaseConnection databaseConnection, UserFactory userFactory)
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
                        var test = command.ExecuteNonQuery();              

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