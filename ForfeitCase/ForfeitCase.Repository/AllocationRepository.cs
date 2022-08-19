using System.Data;
using Dapper;
using ForfeitCase.Entities;

namespace ForfeitCase.Repository
{
  public class AllocationRepository : IAllocationRepository
  {
    private IDbConnection _dbConnection;
    public AllocationRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection;
    }

    public async Task CreateAllocation(Allocation allocation)
    {
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, allocation.ExecutorId, allocation.CaseId);
      var sql = "INSERT INTO allocation (AllocationId, RecieverId, ForfeitId, ExecutorId, CaseId) VALUES (@AllocationId, @RecieverId, @ForfeitId, @ExecutorId, @CaseId)";
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(sql, allocation);
      }
    }

    public async Task DeleteAllocation(string allocationId, string caseId, string executorId)
    {
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, caseId);
      var sql = "DELETE FROM allocation where AllocationId = allocationId";
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(sql, new { AllocationId = allocationId });
      }
    }
  }
}

