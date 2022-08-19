using ForfeitBox.Entities;

namespace ForfeitBox.Service
{
  public interface IAllocationService
  {
    Task CreateAllocation(Allocation allocation);
    Task DeleteAllocation(string allocationId, string caseId, string executorId);
  }
}

