using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factory.User;
using EconomyReloaded.Core.Logging;
using EconomyReloaded.Core.Models.User;

namespace EconomyReloaded.Core.Repositories.User
{
  public class UserRepository : IUserRepository
  {
    private readonly IDatabaseConnection _databaseConnection;
    private readonly IUserFactory _userFactory;

    protected string ConnectionString => _databaseConnection.ConnectionString;

    public UserRepository(IDatabaseConnection databaseConnection, IUserFactory userFactory)
    {
      this._databaseConnection = databaseConnection;
      this._userFactory = userFactory;
    }

    public IEnumerable<UserDetails> GetAllUsers()
    {
      try
      {
        using (var connection = new SqlConnection(ConnectionString))
        {
          var users = new List<UserDetails>();

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
          return users;
        }
      }
      catch (Exception ex)
      {
        CustomLogger.Log(ex);
        return null;
      }
    }

    public UserDetails GetUserById(int userId)
    {
      try
      {
        using (var connection = new SqlConnection(ConnectionString))
        {
          var selectedUser = new UserDetails();

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
          return selectedUser;
        }
      }
      catch (Exception ex)
      {
        CustomLogger.Log(ex);
        return null;
      }
    }
  }
}