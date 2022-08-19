using System;
namespace ForfeitBox.Web.Dtos.Payment
{
  public class CreatePaymentDto
  {
    public double Sum { get; set; }
    public string? BoxId { get; set; }
  }
}

