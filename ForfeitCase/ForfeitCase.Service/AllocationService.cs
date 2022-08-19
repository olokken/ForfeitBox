using System;
using ForfeitCase.Entities;
using ForfeitCase.Repository;

namespace ForfeitCase.Service
{
  public class AllocationService : IAllocationService
  {
    private IAllocationRepository _allocationRepository;
    public AllocationService(IAllocationRepository allocationRepository)
    {
      _allocationRepository = allocationRepository; 
    }

    public Task CreateAllocation(Allocation allocation)
    {
      return _allocationRepository.CreateAllocation(allocation); 
    }

    public Task DeleteAllocation(string allocationId, string caseId, string executorId)
    {
      return _allocationRepository.DeleteAllocation(allocationId, caseId, executorId);
    }
  }
}

