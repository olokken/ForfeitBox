using ForfeitBox.Entities;
using ForfeitBox.Service;
using ForfeitBox.Web.Dtos.Case;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitBox.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BoxController : ControllerBase
  {
    private readonly IBoxService _boxService;
    public BoxController(IBoxService boxService)
    {
      _boxService = boxService;
    }

    [HttpGet("{boxId}")]
    public async Task<IActionResult> GetCase(string caseId)
    {
      Box ca = await _boxService.GetCase(caseId, Utils.GetIdFromToken(HttpContext));
      if(ca == null)
      {
        return NotFound(); 
      }
      return Ok(ca); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateCase([FromBody] CreateBoxDto createBoxDto)
    {
      Box box = new Box
      {
        BoxId = Guid.NewGuid().ToString(),
        Name = createBoxDto.Name,    
        Code = Utils.createCode(),
      };
      var token = Utils.GetIdFromToken(HttpContext); 
      await _boxService.CreateCase(box, token);
      return Ok(box);
    }

    [HttpDelete("{caseId}")]
    public async Task<ActionResult> DeleteCase(string caseId)
    {
      await _boxService.DeleteCase(caseId, Utils.GetIdFromToken(HttpContext)); 
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
      await _boxService.UpdateCase(box, Utils.GetIdFromToken(HttpContext));
      return Ok(box);
    }
  }
}

