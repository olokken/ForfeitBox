using ForfeitCase.Entities;
using ForfeitCase.Service;
using ForfeitCase.Web.Dtos.Allocation;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitCase.Web.Controllers
{
  [ApiController]
  [Route("api/Case/[controller]")]
  public class AllocationController : ControllerBase
  {
    private IAllocationService _allocationService;
    public AllocationController(IAllocationService allocationService)
    {
      _allocationService = allocationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAllocation([FromBody] CreateAllocationDto createAllocationDto)
    {
      Allocation allocation = new Allocation
      {
        AllocationId = Guid.NewGuid().ToString(),
        CaseId = createAllocationDto.CaseId,
        ForfeitId = createAllocationDto.ForfeitId,
        ExecutorId = Utils.GetIdFromToken(HttpContext)
      };
      await _allocationService.CreateAllocation(allocation);
      return Ok(allocation);
    }

    [HttpDelete("{CaseId}&&{AllocationId}")]
    public async Task<IActionResult> DeleteAllocation(string allocationId, string caseId)
    {
      await _allocationService.DeleteAllocation(allocationId, caseId, Utils.GetIdFromToken(HttpContext));
      return Ok();
    }
  }
}

