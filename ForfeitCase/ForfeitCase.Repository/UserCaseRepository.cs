using Dapper;
using System.Data;

namespace ForfeitCase.Repository
{
  public class UserCaseRepository : IUserCaseRepository
  {
    private IDbConnection _dbConnection;
    public UserCaseRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection;
    }

    public async Task AddUser(string userId, string caseId)
    {
      var addUserQuery = "INSERT INTO user_case (UserId, CaseId, IsAdmin) values (@UserId, @CaseId, false)";
      await _dbConnection.ExecuteAsync(addUserQuery, new { UserId = userId, CaseId = caseId });
    }

    public static async Task<bool> IsAdmin(IDbConnection connection, string userId, string caseId)
    {
      var isAdminQuery = "SELECT isAdmin from user_case where UserId = @UserId, CaseId = @CaseId";
      bool isAdmin = await connection.QueryFirstOrDefaultAsync<bool>(isAdminQuery, new { UserId = userId, CaseId = caseId });
      if (isAdmin)
      {
        return true;
      }
      //Could possibly just return false. Checking if this will exception will create HttpStatus 401 | 403
      throw new UnauthorizedAccessException();
    }
    
    public static async Task<bool> IsMember(IDbConnection connection, string userId, string caseId)
    {
      var isAdminQuery = "SELECT UserId from user_case where UserId = @UserId, CaseId = @CaseId";
      List<string> ids = (List<string>)await connection.QueryAsync<string>(isAdminQuery, new { UserId = userId, CaseId = caseId });
      if (ids.Count >= 1)
      {
        return true;
      }
      return false; 
    }

    public async Task RemoveUser(string userId, string caseId, string executorId)
    {
      var removeUserQuery = "DELETE from user_case where UserId = @UserId and CaseId = @CaseId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, userId, caseId);
      if (isAdmin || userId == executorId)
      {
        await _dbConnection.ExecuteAsync(removeUserQuery, new { UserId = userId, CaseId = caseId });
      }
    }

    public async Task UpdateCredentials(string userId, string caseId, bool credentials, string executorId)
    {
      var updateAdminQuery = "UPDATE user_case SET IsAdmin = @IsAdmin where UserId = @UserId, CaseId = @CaseId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, caseId);
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(updateAdminQuery, new { IsAdmin = credentials, UserId = userId, CaseId = caseId });
      }
    }
  }
}

