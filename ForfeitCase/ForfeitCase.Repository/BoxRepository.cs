using Dapper;
using ForfeitBox.Entities;
using System.Data;

namespace ForfeitBox.Repository
{
  public class BoxRepository : IBoxRepository
  {
    private IDbConnection _dbConnection;
    public BoxRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection; 
    }

    public async Task CreateCase(Box ca, string creatorId)
    {
      var insertCaseQuery = "INSERT INTO case(CaseId, Name) values (@CaseId, @Name)";
      var insertAdminQuery = "INSERT INTO user_case(UserId, BoxId, IsAdmin) values (@UserId, @BoxId, @IsAdmin)";
      using(IDbTransaction transaction = _dbConnection.BeginTransaction())
      {
        await _dbConnection.ExecuteAsync(insertCaseQuery, ca);
        await _dbConnection.ExecuteAsync(insertAdminQuery, new { UserId = creatorId, BoxId = ca.BoxId, isAdmin = true });
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

    public async Task<Box> GetCase(string caseId, string executorId)
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

        Box box = await _dbConnection.QueryFirstOrDefaultAsync<Box>(caseQuery, new { CaseId = caseId });
        IEnumerable<User> members = await _dbConnection.QueryAsync<User>(membersQuery, new { CaseId = caseId });
        IEnumerable<User> admins = await _dbConnection.QueryAsync<User>(adminsQuery, new { CaseId = caseId });
        IEnumerable<Payment> payments = await _dbConnection.QueryAsync<Payment>(paymentsQuery, new { CaseId = caseId });
        IEnumerable<Allocation> allocations = await _dbConnection.QueryAsync<Allocation>(allocationsQuery, new { CaseId = caseId });
        box.Members = members;
        box.Admins = admins;
        box.Payments = payments;
        box.Allocations = allocations;
        return box;
      }
      throw new UnauthorizedAccessException($"User with UserId : {executorId} is not member of Case with ID : {caseId}"); 
    }

    public async Task UpdateCase(Box ca, string executorId)
    {
      var deleteQuery = "UPDATE case SET Name = @Name where CaseId = @CaseId";
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, ca.BoxId);
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(deleteQuery, ca);
      }
    }
  }
}

