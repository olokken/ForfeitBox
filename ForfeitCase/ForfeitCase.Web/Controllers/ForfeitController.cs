using ForfeitCase.Entities;
using ForfeitCase.Service;
using ForfeitCase.Web.Dtos.Forfeit;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitCase.Web.Controllers
{
  [ApiController]
  [Route("api/Case/[controller]")]
  public class ForfeitController : ControllerBase
  {
    private IForfeitService _forfeitService;
    public ForfeitController(IForfeitService forfeitService)
    {
      _forfeitService = forfeitService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateForfeit([FromBody] CreateForfeitDto createForfeitDto)
    {
      Forfeit forfeit = new Forfeit
      {
        ForfeitId = Guid.NewGuid().ToString(),
        Name = createForfeitDto.Name,
        Description = createForfeitDto.Description,
        Sum = createForfeitDto.Sum,
        CaseId = createForfeitDto.CaseId
      };
      await _forfeitService.CreateForfeit(forfeit, Utils.GetIdFromToken(HttpContext));
      return Ok(forfeit);
    }

    //Or get data from bodt, google if that could be a good solution :-)
    [HttpDelete("{forfeitId}&&{caseId}")]
    public async Task<IActionResult> DeleteForfeit(string forfeitId, string caseId)
    {
      await _forfeitService.DeleteForfeit(forfeitId, Utils.GetIdFromToken(HttpContext), caseId);
      return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> EditForfeit([FromBody] Forfeit forfeit)
    {
      await _forfeitService.EditForfeit(forfeit, Utils.GetIdFromToken(HttpContext));
      return Ok();
    }

  }
}

