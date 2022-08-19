using System;
using ForfeitBox.Entities;

namespace ForfeitBox.Repository
{
  public interface IForfeitRepository
  {
    Task CreateForfeit(Forfeit forfeit, string executorId);
    Task EditForfeit(Forfeit forfeit, string executorId);
    Task DeleteForfeit(string forfeitId, string executorId, string caseId);     
  }
}

