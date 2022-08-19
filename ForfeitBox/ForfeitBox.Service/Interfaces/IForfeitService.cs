using ForfeitBox.Entities;

namespace ForfeitBox.Service
{
  public interface IForfeitService
  {
    Task CreateForfeit(Forfeit forfeit, string executorId);
    Task EditForfeit(Forfeit forfeit, string executorId);
    Task DeleteForfeit(string forfeitId, string executorId, string caseId);
  }
}

