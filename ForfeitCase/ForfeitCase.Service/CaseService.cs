using ForfeitCase.Entities;
using ForfeitCase.Repository;

namespace ForfeitCase.Service
{
  public class CaseService : ICaseService
  {
    private ICaseRepository _caseRepository; 
    public CaseService(ICaseRepository caseRepository)
    {
      _caseRepository = caseRepository; 
    }

    public Task CreateCase(Case ca, string creatorId)
    {
      return _caseRepository.CreateCase(ca, creatorId); 
    }

    public Task DeleteCase(string caseId, string executorId)
    {
      return _caseRepository.DeleteCase(caseId, executorId); 
    }

    public Task<Case> GetCase(string caseId, string executorId)
    {
      return _caseRepository.GetCase(caseId, executorId); 
    }

    public Task UpdateCase(Case ca, string executorId)
    {
      return _caseRepository.UpdateCase(ca, executorId); 
    }
  }
}

