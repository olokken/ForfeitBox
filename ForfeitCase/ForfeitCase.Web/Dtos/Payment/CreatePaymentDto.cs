using System;
namespace ForfeitCase.Web.Dtos.Payment
{
  public class CreatePaymentDto
  {
    public double Sum { get; set; }
    public string? CaseId { get; set; }
  }
}

