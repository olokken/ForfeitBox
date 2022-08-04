using System;
using ForfeitCase.Entities;

namespace ForfeitCase.Service
{
  public interface IUserService
  {
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(string userId);
    Task CreateUser(User user);
  }
}

