using System;
namespace ForfeitBox.Web.Dtos.Payment
{
  public class ConfirmPaymentDto
  {
    public string? PaymentId { get; set; }
    public string? BoxId { get; set; }
  }
}

