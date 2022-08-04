using System;
using ForfeitCase.Entities;

namespace ForfeitCase.Repository
{
  public interface IUserRepository
  {
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(string userId);
    Task CreateUser(User user);
  }
}

