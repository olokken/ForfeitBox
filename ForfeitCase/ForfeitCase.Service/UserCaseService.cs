using System;
using ForfeitBox.Repository;

namespace ForfeitBox.Service
{
  public class UserCaseService : IUserCaseService
  {
    private IUserCaseRepository _userCaseRepository; 
    public UserCaseService(IUserCaseRepository userCaseRepository)
    {
      _userCaseRepository = userCaseRepository; 
    }

    public Task AddUser(string userId, string caseId)
    {
      return _userCaseRepository.AddUser(userId, caseId);
    }

    public Task RemoveUser(string userId, string caseId, string executorId)
    {
      return _userCaseRepository.RemoveUser(userId, caseId, executorId); 
    }

    public Task UpdateCredentials(string userId, string caseId, bool isAdmin, string executorId)
    {
      return _userCaseRepository.UpdateCredentials(userId, caseId, isAdmin, executorId); 
    }
  }
}

