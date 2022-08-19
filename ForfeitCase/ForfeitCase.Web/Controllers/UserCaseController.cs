using ForfeitCase.Service;
using ForfeitCase.Web.Dtos.UserCase;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitCase.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserCaseController : ControllerBase
  {
    private IUserCaseService _userCaseService;
    public UserCaseController(IUserCaseService userCaseService)
    {
      _userCaseService = userCaseService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUserToCase([FromBody] AddUserToCaseDto addUserToCaseDto)
    {
      if (addUserToCaseDto.UserId != null && addUserToCaseDto.CaseId != null)
      {
        await _userCaseService.AddUser(addUserToCaseDto.UserId, addUserToCaseDto.CaseId);        
      }
      return Ok();      
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUserFromCase([FromBody] AddUserToCaseDto addUserToCaseDto)
    {
      if (addUserToCaseDto.UserId != null && addUserToCaseDto.CaseId != null)
      {
        await _userCaseService.RemoveUser(addUserToCaseDto.UserId, addUserToCaseDto.CaseId, Utils.GetIdFromToken(HttpContext));
      }
      return Ok();
    }
  }
}

