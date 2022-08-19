using ForfeitBox.Service;
using ForfeitBox.Web.Dtos.UserCase;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitBox.Web.Controllers
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
      if (addUserToCaseDto.UserId != null && addUserToCaseDto.BoxId != null)
      {
        await _userCaseService.AddUser(addUserToCaseDto.UserId, addUserToCaseDto.BoxId);        
      }
      return Ok();      
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUserFromCase([FromBody] AddUserToCaseDto addUserToCaseDto)
    {
      if (addUserToCaseDto.UserId != null && addUserToCaseDto.BoxId != null)
      {
        await _userCaseService.RemoveUser(addUserToCaseDto.UserId, addUserToCaseDto.BoxId, Utils.GetIdFromToken(HttpContext));
      }
      return Ok();
    }
  }
}

