using System;
using ForfeitBox.Entities;
using ForfeitBox.Repository;

namespace ForfeitBox.Service
{
  public class AllocationService : IAllocationService
  {
    private readonly IAllocationRepository _allocationRepository;
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

