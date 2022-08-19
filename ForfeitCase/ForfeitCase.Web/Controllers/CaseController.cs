using ForfeitCase.Entities;
using ForfeitCase.Service;
using ForfeitCase.Web.Dtos.Case;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitCase.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CaseController : ControllerBase
  {
    private ICaseService _caseService;
    public CaseController(ICaseService caseService)
    {
      _caseService = caseService;
    }

    [HttpGet("{caseId}")]
    public async Task<IActionResult> GetCase(string caseId)
    {
      Case ca = await _caseService.GetCase(caseId, Utils.GetIdFromToken(HttpContext));
      if(ca == null)
      {
        return NotFound(); 
      }
      return Ok(ca); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateCase([FromBody] CreateCaseDto createCaseDto)
    {
      Case ca = new Case
      {
        CaseId = Guid.NewGuid().ToString(),
        Name = createCaseDto.Name,      
      }; 
      await _caseService.CreateCase(ca, Utils.GetIdFromToken(HttpContext));
      return Ok(ca);
    }

    [HttpDelete("{caseId}")]
    public async Task<ActionResult> DeleteCase(string caseId)
    {
      await _caseService.DeleteCase(caseId, Utils.GetIdFromToken(HttpContext)); 
      return Ok(); 
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCase([FromBody] UpdateCaseDto updateCaseDto)
    {
      Case ca = new Case
      {
        Name = updateCaseDto.Name,
        CaseId = updateCaseDto.CaseId
      };
      await _caseService.UpdateCase(ca, Utils.GetIdFromToken(HttpContext));
      return Ok(ca);
    }
  }
}

