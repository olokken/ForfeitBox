using Dapper;
using System.Data;

namespace ForfeitBox.Repository
{
  public class UserCaseRepository : IUserCaseRepository
  {
    private readonly IDbConnection _dbConnection;
    public UserCaseRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection;
    }

    public async Task AddUser(string userId, string code)
    {
      var query =
        "INSERT INTO user_box (UserId, BoxId, IsAdmin) VALUES(@UserId, (SELECT BoxId FROM  WHERE box where Code = @Code),0)"; 
      await _dbConnection.ExecuteAsync(query, new { UserId = userId, Code = code });
    }

    public static async Task<bool> IsAdmin(IDbConnection connection, string userId, string boxId)
    {
      var isAdminQuery = "SELECT isAdmin from user_box where UserId = @UserId, BoxId = @BoxId";
      bool isAdmin = await connection.QueryFirstOrDefaultAsync<bool>(isAdminQuery, new { UserId = userId, BoxId = boxId });
      if (isAdmin)
      {
        return true;
      }
      //Could possibly just return false. Checking if this will exception will create HttpStatus 401 | 403
      throw new UnauthorizedAccessException();
    }
    
    public static async Task<bool> IsMember(IDbConnection connection, string userId, string boxId)
    {
      var isAdminQuery = "SELECT UserId from user_box where UserId = @UserId, BoxId = @BoxId";
      List<string> ids = (List<string>)await connection.QueryAsync<string>(isAdminQuery, new { UserId = userId, BoxId = boxId });
      if (ids.Count >= 1)
      {
        return true;
      }
      return false; 
    }

    public async Task RemoveUser(string userId, string boxId, string executorId)
    {
      var removeUserQuery = "DELETE from user_box where UserId = @UserId and BoxId = @BoxId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, userId, boxId);
      if (isAdmin || userId == executorId)
      {
        await _dbConnection.ExecuteAsync(removeUserQuery, new { UserId = userId, BoxId = boxId });
      }
    }

    public async Task UpdateCredentials(string userId, string boxId, bool credentials, string executorId)
    {
      var updateAdminQuery = "UPDATE user_box SET IsAdmin = @IsAdmin where UserId = @UserId, BoxId = @BoxId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, boxId);
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(updateAdminQuery, new { IsAdmin = credentials, UserId = userId, BoxId = boxId });
      }
    }
  }
}

