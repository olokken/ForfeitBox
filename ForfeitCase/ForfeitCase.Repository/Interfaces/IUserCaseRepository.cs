using System;
using System.Data;

namespace ForfeitCase.Repository
{
  public interface IUserCaseRepository
  {
    Task AddUser(string userId, string caseId);
    Task UpdateCredentials(string userId, string caseId, bool isAdmin, string executorId);
    Task RemoveUser(string userId, string caseId, string executorId);    
  }
}

