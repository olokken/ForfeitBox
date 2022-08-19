using System;
namespace ForfeitBox.Entities
{
  public class Payment : Action
  {
    public string? PaymentId { get; set; }
    public double Sum { get; set; }    
  }
}

