using System;
using ForfeitBox.Entities;

namespace ForfeitBox.Repository
{
  public interface IBoxRepository
  {
    Task CreateCase(Box box, string creatorId);
    Task UpdateCase(Box box, string executorId);
    Task DeleteCase(string boxId, string executorId);
    Task<Box> GetCase(string boxId, string executorId); 
  }
}

