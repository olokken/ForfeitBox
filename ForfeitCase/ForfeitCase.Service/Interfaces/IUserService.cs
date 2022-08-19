using ForfeitBox.Entities;

namespace ForfeitBox.Service
{
  public interface IUserService
  {   
    Task<User> GetUser(string userId);
    Task CreateUser(User user);
  }
}

