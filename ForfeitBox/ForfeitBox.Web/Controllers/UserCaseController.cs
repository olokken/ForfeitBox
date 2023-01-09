using ForfeitBox.Service;
using ForfeitBox.Web.Dtos.Allocation;
using ForfeitBox.Web.Dtos.UserCase;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitBox.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserCaseController : ControllerBase
  {
    private readonly IUserCaseService _userCaseService;
    public UserCaseController(IUserCaseService userCaseService)
    {
      _userCaseService = userCaseService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUserToCase([FromBody] AddUserToCaseDto addUserToCaseDto)
    {
      if (addUserToCaseDto.Code != null)
      {
        await _userCaseService.AddUser(Utils.GetIdFromToken(HttpContext), addUserToCaseDto.Code);        
      }
      return Ok();      
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUserFromCase([FromBody] RemoveUserFromBoxDto removeUserFromBoxDto)
    {
      if (removeUserFromBoxDto.UserId != null && removeUserFromBoxDto.BoxId != null)
      {
        await _userCaseService.RemoveUser(removeUserFromBoxDto.UserId, removeUserFromBoxDto.BoxId, Utils.GetIdFromToken(HttpContext));
      }
      return Ok();
    }
  }
}

