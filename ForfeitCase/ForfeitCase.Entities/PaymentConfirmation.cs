using System;
namespace ForfeitCase.Entities
{
  public class PaymentConfirmation : Action
  {
    public string? PaymentConfirmationId { get; set; }
    public Payment? Payment { get; set; }
    public string? PaymentId { get; set; }    
  }
}

