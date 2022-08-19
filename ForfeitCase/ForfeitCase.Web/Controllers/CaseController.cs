using ForfeitBox.Entities;
using ForfeitBox.Service;
using ForfeitBox.Web.Dtos.Case;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitBox.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CaseController : ControllerBase
  {
    private IBoxService _caseService;
    public CaseController(IBoxService caseService)
    {
      _caseService = caseService;
    }

    [HttpGet("{caseId}")]
    public async Task<IActionResult> GetCase(string caseId)
    {
      Box ca = await _caseService.GetCase(caseId, Utils.GetIdFromToken(HttpContext));
      if(ca == null)
      {
        return NotFound(); 
      }
      return Ok(ca); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateCase([FromBody] CreateCaseDto createCaseDto)
    {
      Box box = new Box
      {
        BoxId = Guid.NewGuid().ToString(),
        Name = createCaseDto.Name,      
      }; 
      await _caseService.CreateCase(box, Utils.GetIdFromToken(HttpContext));
      return Ok(box);
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
      Box box= new Box
      {
        Name = updateCaseDto.Name,
        BoxId = updateCaseDto.CaseId
      };
      await _caseService.UpdateCase(box, Utils.GetIdFromToken(HttpContext));
      return Ok(box);
    }
  }
}

