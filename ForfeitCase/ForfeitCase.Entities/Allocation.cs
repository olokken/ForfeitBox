using System;
namespace ForfeitCase.Entities
{
  public class Allocation : Action
  {
    public String? AllocationId { get; set; }
    public User? Reciever { get; set; }
    public Forfeit? Forfeit { get; set; }
  }
}

