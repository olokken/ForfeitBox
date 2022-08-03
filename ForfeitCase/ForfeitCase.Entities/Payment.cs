using System;
namespace ForfeitCase.Entities
{
  public class Payment : Action
  {
    public String? PaymentId { get; set; }
    public double Sum { get; set; }
  }
}

