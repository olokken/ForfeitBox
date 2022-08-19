using ForfeitBox.Entities;

namespace ForfeitBox.Service
{
  public interface IBoxService
  {
    Task CreateCase(Box box, string creatorId);
    Task UpdateCase(Box box, string executorId);
    Task DeleteCase(string caseId, string executorId);
    Task<Box> GetCase(string caseId, string executorId); 
  }
}

