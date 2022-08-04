using System;
using ForfeitCase.Entities;
using ForfeitCase.Service;
using ForfeitCase.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitCase.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private IUserService _userService;
    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public Task<IEnumerable<User>> GetUsers()
    {
      return _userService.GetUsers();
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(string userId)
    {
      User user = await _userService.GetUser(userId);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
      User user = new User
      {
        UserId = Guid.NewGuid().ToString(),
        Name = userDto.Name,
        Email = userDto.Email
      };
      await _userService.CreateUser(user);
      return Ok(user); 
    }
  }
}

