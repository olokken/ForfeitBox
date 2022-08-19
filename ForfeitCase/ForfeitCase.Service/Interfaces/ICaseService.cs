using ForfeitCase.Entities;

namespace ForfeitCase.Service
{
  public interface ICaseService
  {
    Task CreateCase(Case ca, string creatorId);
    Task UpdateCase(Case ca, string executorId);
    Task DeleteCase(string caseId, string executorId);
    Task<Case> GetCase(string caseId, string executorId); 
  }
}

