using ForfeitBox.Entities;
using ForfeitBox.Repository;

namespace ForfeitBox.Service
{
  public class ForfeitService : IForfeitService
  {
    private readonly IForfeitRepository _forfeitRepository;
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

