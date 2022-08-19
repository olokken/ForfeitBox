using Dapper;
using System.Data;
using ForfeitCase.Entities;

namespace ForfeitCase.Repository
{
  public class CaseRepository : ICaseRepository
  {
    private IDbConnection _dbConnection;
    public CaseRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection; 
    }

    public async Task CreateCase(Case ca, string creatorId)
    {
      var insertCaseQuery = "INSERT INTO case(CaseId, Name) values (@CaseId, @Name)";
      var insertAdminQuery = "INSERT INTO user_case(UserId, CaseId, IsAdmin) values (@UserId, @CaseId, @IsAdmin)";
      using(IDbTransaction transaction = _dbConnection.BeginTransaction())
      {
        await _dbConnection.ExecuteAsync(insertCaseQuery, ca);
        await _dbConnection.ExecuteAsync(insertAdminQuery, new { UserId = creatorId, CaseId = ca.CaseId, isAdmin = true });
        transaction.Commit(); 
      }
    }

    public async Task DeleteCase(string caseId, string executorId)
    {
      var deleteQuery = "DELETE FROM case where CaseId = @CaseId"; 
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, caseId);
      if(isAdmin)
      {
        await _dbConnection.ExecuteAsync(deleteQuery, new { CaseId = caseId }); 
      }
    }

    public async Task<Case> GetCase(string caseId, string executorId)
    {
      if (await UserCaseRepository.IsMember(_dbConnection, executorId, caseId))
      {
        var caseQuery = "SELECT CaseId, Name from case where CaseId = @CaseId";
        var membersQuery = "SELECT u.UserId, u.Name from user u " +
          "join user_case uc on u.UserId = uc.UserId " +
          "where uc.CaseId = @CaseId and uc.IsAdmin = false";
        var adminsQuery = "SELECT u.UserId, u.Name from user u " +
          "join user_case uc on u.UserId = uc.UserId " +
          "where uc.CaseId = @CaseId and uc.IsAdmin = true";
        var paymentsQuery = "SELECT p.PaymentId, p.Sum, p.ExecutorId from payment where CaseId = @CaseId";
        var allocationsQuery = "SELECT a.AllocationId, a.RecieverId, a.ForfeitId where CaseId = @CaseId";

        Case ca = await _dbConnection.QueryFirstOrDefaultAsync<Case>(caseQuery, new { CaseId = caseId });
        IEnumerable<User> members = await _dbConnection.QueryAsync<User>(membersQuery, new { CaseId = caseId });
        IEnumerable<User> admins = await _dbConnection.QueryAsync<User>(adminsQuery, new { CaseId = caseId });
        IEnumerable<Payment> payments = await _dbConnection.QueryAsync<Payment>(paymentsQuery, new { CaseId = caseId });
        IEnumerable<Allocation> allocations = await _dbConnection.QueryAsync<Allocation>(allocationsQuery, new { CaseId = caseId });
        ca.Members = members;
        ca.Admins = admins;
        ca.Payments = payments;
        ca.Allocations = allocations;
        return ca;
      }
      throw new UnauthorizedAccessException($"User with UserId : {executorId} is not member of Case with ID : {caseId}"); 
    }

    public async Task UpdateCase(Case ca, string executorId)
    {
      var deleteQuery = "UPDATE case SET Name = @Name where CaseId = @CaseId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, ca.CaseId);
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(deleteQuery, ca);
      }
    }
  }
}

