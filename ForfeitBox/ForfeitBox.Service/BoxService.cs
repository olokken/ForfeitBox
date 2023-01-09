using ForfeitBox.Entities;
using ForfeitBox.Repository;

namespace ForfeitBox.Service
{
  public class BoxService : IBoxService
  {
    private readonly IBoxRepository _caseRepository; 
    public BoxService(IBoxRepository caseRepository)
    {
      _caseRepository = caseRepository; 
    }

    public Task CreateCase(Box box, string creatorId)
    {
      return _caseRepository.CreateCase(box, creatorId); 
    }

    public Task DeleteCase(string caseId, string executorId)
    {
      return _caseRepository.DeleteCase(caseId, executorId); 
    }

    public Task<Box> GetCase(string boxId, string executorId)
    {
      return _caseRepository.GetCase(boxId, executorId); 
    }

    public Task UpdateCase(Box box, string executorId)
    {
      return _caseRepository.UpdateCase(box, executorId); 
    }
  }
}

