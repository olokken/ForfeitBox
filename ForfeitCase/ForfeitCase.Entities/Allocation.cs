using System;
namespace ForfeitCase.Entities
{
  public class Allocation : Action
  {
    public string? AllocationId { get; set; }
    public User? Reciever { get; set; }
    public string? RecieverId { get; set; }
    public Forfeit? Forfeit { get; set; }
    public string? ForfeitId { get; set; }    
  }
}

