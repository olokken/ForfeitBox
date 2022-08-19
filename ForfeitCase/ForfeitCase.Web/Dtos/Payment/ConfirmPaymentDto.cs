using System;
namespace ForfeitCase.Web.Dtos.Payment
{
  public class ConfirmPaymentDto
  {
    public string? PaymentId { get; set; }
    public string? CaseId { get; set; }
  }
}

