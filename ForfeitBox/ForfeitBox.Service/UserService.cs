using System;
using ForfeitBox.Entities;
using ForfeitBox.Repository;

namespace ForfeitBox.Service
{
  public class UserService : IUserService
  {
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository; 
    }

    public Task CreateUser(User user)
    {
      return _userRepository.CreateUser(user);
    }

    public Task<User> GetUser(string userId)
    {
      return _userRepository.GetUser(userId);
    }
  }
}

