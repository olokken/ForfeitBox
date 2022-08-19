namespace ForfeitBox.Service
{
  public interface IUserCaseService
  {
    Task AddUser(string userId, string caseId);
    Task UpdateCredentials(string userId, string caseId, bool isAdmin, string executorId);
    Task RemoveUser(string userId, string caseId, string executorId);    
  }
}

