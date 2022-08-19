using System;
using ForfeitBox.Entities;

namespace ForfeitBox.Repository
{
  public interface IUserRepository
  {
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(string userId);
    Task CreateUser(User user);
  }
}

