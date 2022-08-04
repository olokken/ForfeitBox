using System;
using ForfeitCase.Entities;
using ForfeitCase.Repository;

namespace ForfeitCase.Service
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

    public Task<IEnumerable<User>> GetUsers()
    {
      return _userRepository.GetUsers();
    }
  }
}

