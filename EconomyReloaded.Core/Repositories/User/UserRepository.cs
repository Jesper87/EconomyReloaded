using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Http.ExceptionHandling;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factory;
using EconomyReloaded.Core.Factory.User;
using EconomyReloaded.Core.Logging;

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

    public IEnumerable<Models.User.UserDetails> GetAllUsers()
    {
      try
      {
        using (var connection = new SqlConnection(ConnectionString))
        {
          var users = new List<Models.User.UserDetails>();

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

    public Models.User.UserDetails GetUserById(int userId)
    {
      try
      {
        using (var connection = new SqlConnection(ConnectionString))
        {
          var selectedUser = new Models.User.UserDetails();

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