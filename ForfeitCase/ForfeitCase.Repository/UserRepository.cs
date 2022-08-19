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
      var userQuery = "SELECT UserId, Name from user where UserId = @UserId";
      var caseQuery = "SELECT c.CaseId, c.Name from case c join user_case uc on c.CaseId = uc.CaseId where UserId = @UserId";
      User user = await _dbConnection.QueryFirstOrDefaultAsync<User>(userQuery, new { UserId = userId });
      IEnumerable<Case> cases = await _dbConnection.QueryAsync<Case>(caseQuery, new {UserId = userId});
      user.Cases = cases; 
      return user; 
    }

    async Task<IEnumerable<User>> IUserRepository.GetUsers()
    {
      var query = "SELECT UserId, Name from user";
      return await _dbConnection.QueryAsync<User>(query);
    }
  }
}

