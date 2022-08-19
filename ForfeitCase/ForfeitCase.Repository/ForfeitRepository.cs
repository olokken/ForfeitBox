using Dapper;
using ForfeitBox.Entities;
using System.Data;

namespace ForfeitBox.Repository
{
  public class ForfeitRepository : IForfeitRepository
  {
    private IDbConnection _dbConnection;
    public ForfeitRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection; 
    }

    public async Task CreateForfeit(Forfeit forfeit, string executorId)
    {
      var sql = "INSERT INTO forfeit (ForfeitId, Name, Description, Sum, CaseId) values (@ForfeitId, @Name, @Description, @Sum, @CaseId)";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, forfeit.BoxId);
      if(isAdmin)
      {
        await _dbConnection.ExecuteAsync(sql, forfeit); 
      }
    }

    public async Task DeleteForfeit(string forfeitId, string executorId, string caseId)
    {
      var sql = "DELETE FROM forfeit where ForfeitId = @ForfeitId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, caseId);
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(sql, new {ForfeitId = forfeitId});
      }
    }

    public async Task EditForfeit(Forfeit forfeit, string executorId)
    {
      var sql = "UPDATE forfeit SET Name = @Name, Sum = @Sum, Description = @Description where ForfeitId = @ForfeitId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, forfeit.BoxId);
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(sql, forfeit);
      }
    }
  }
}

