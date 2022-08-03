using System;
namespace ForfeitCase.Entities
{
  public class Allocation : Action
  {
    public String? AllocationId { get; set; }
    public User? Reciever { get; set; }
    public String? UserId { get; set; }
    public Forfeit? Forfeit { get; set; }
    public String? ForfeitId { get; set; }
  }
}

