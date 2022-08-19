using System.Data;
using Dapper;
using ForfeitBox.Entities;

namespace ForfeitBox.Repository
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
      var caseQuery = "SELECT b.BoxId, b.Name from box b join user_box ub on b.BoxId = ub.BoxId where ub.UserId = @UserId";
      User user = await _dbConnection.QueryFirstOrDefaultAsync<User>(userQuery, new { UserId = userId });
      IEnumerable<Box> boxes = await _dbConnection.QueryAsync<Box>(caseQuery, new {UserId = userId});
      user.Boxes = boxes; 
      return user; 
    }

    async Task<IEnumerable<User>> IUserRepository.GetUsers()
    {
      var query = "SELECT UserId, Name from user";
      return await _dbConnection.QueryAsync<User>(query);
    }
  }
}

