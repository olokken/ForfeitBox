using ForfeitBox.Entities;
using ForfeitBox.Service;
using ForfeitBox.Web.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitBox.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
      string userId = Utils.GetIdFromToken(HttpContext); 
      User user = await _userService.GetUser(userId);
      if (user == null)
      {
        User? newUser = Utils.CreateUserFromToken(HttpContext);
        if(newUser == null)
        {
          return Forbid(); 
        }
        await _userService.CreateUser(newUser);
        return Ok(newUser); 
      }
      return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser()
    {
      //Slett bruker;     
      throw new NotImplementedException();
    }
  }
}

