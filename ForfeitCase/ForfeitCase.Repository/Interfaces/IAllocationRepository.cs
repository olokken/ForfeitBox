using ForfeitBox.Entities;

namespace ForfeitBox.Repository
{
  public interface IAllocationRepository
  {
    Task CreateAllocation(Allocation allocation);
    Task DeleteAllocation(string allocationId, string caseId, string executorId); 
  }
}

