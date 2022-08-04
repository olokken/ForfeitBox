using System.Data;
using ForfeitCase.Entities;
using Dapper;

namespace ForfeitCase.Repository
{
  public class UserRepository : IUserRepository
  {
    private IDbConnection _dbConnection;

    public UserRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection;
    }

    public async Task CreateUser(User user)
    {
      var query = "INSERT INTO user (UserId, Name) values (@UserId, @Name)";
      await _dbConnection.ExecuteAsync(query, user);
    }

    public async Task<User> GetUser(string userId)
    {
      var query = "SELECT UserId, Name from user where UserId = @UserId";
      return await _dbConnection.QueryFirstOrDefaultAsync<User>(query, new { UserId = userId });
    }

    async Task<IEnumerable<User>> IUserRepository.GetUsers()
    {
      var query = "SELECT UserId, Name from user";
      return await _dbConnection.QueryAsync<User>(query);
    }
  }
}

