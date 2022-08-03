using System;
namespace ForfeitCase.Entities
{
  public class User
  {
    public String? UserId { get; set; }
    public String? Email { get; set; }
    public String? Password { get; set; }
    public List<Case>? Cases { get; set; }
  }
}

