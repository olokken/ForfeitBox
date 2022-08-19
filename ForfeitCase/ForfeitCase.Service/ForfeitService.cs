using ForfeitCase.Entities;
using ForfeitCase.Repository;

namespace ForfeitCase.Service
{
  public class ForfeitService : IForfeitService
  {
    private IForfeitRepository _forfeitRepository;
    public ForfeitService(IForfeitRepository forfeitRepository)
    {
      _forfeitRepository = forfeitRepository; 
    }

    public Task CreateForfeit(Forfeit forfeit, string executorId)
    {
      return _forfeitRepository.CreateForfeit(forfeit, executorId); 
    }

    public Task DeleteForfeit(string forfeitId, string executorId, string caseId)
    {
      return _forfeitRepository.DeleteForfeit(forfeitId, executorId, caseId); 
    }

    public Task EditForfeit(Forfeit forfeit, string executorId)
    {
      return _forfeitRepository.EditForfeit(forfeit, executorId); 
    }
  }
}

