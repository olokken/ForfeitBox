using ForfeitBox.Entities;
using ForfeitBox.Service;
using ForfeitBox.Web.Dtos.Allocation;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitBox.Web.Controllers
{
  [ApiController]
  [Route("api/Case/[controller]")]
  public class AllocationController : ControllerBase
  {
    private readonly IAllocationService _allocationService;
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
        BoxId = createAllocationDto.CaseId,
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

