using ForfeitCase.Entities;

namespace ForfeitCase.Service
{
  public interface IUserService
  {   
    Task<User> GetUser(string userId);
    Task CreateUser(User user);
  }
}

