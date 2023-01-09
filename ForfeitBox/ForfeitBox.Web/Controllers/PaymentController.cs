using ForfeitBox.Entities;
using ForfeitBox.Service;
using ForfeitBox.Web.Dtos.Payment;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitBox.Web.Controllers
{
  [ApiController]
  [Route("api/Case/[controller]")]
  public class PaymentController : ControllerBase
  {
    private readonly IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
      _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
    {
      Payment payment = new Payment
      {
        PaymentId = Guid.NewGuid().ToString(),
        Sum = createPaymentDto.Sum,
        BoxId = createPaymentDto.BoxId,
        ExecutorId = Utils.GetIdFromToken(HttpContext)
      };
      await _paymentService.CreatePayment(payment); 
      return Ok(payment); 
    }

    [HttpPost("/Confirmation")]
    public async Task<IActionResult> ConfirmPayment([FromBody] ConfirmPaymentDto confirmPaymentDto)
    {
      PaymentConfirmation paymentConfirmation = new PaymentConfirmation
      {
        PaymentConfirmationId = Guid.NewGuid().ToString(),
        BoxId = confirmPaymentDto.BoxId,
        PaymentId = confirmPaymentDto.PaymentId,        
      };
      await _paymentService.ConfirmPayment(paymentConfirmation);
      return Ok(paymentConfirmation); 
    }

    [HttpDelete("{PaymentId}&&{CaseId}")]
    public async Task<IActionResult> DeletePayment(string paymentId, string caseId)
    {
      await _paymentService.DeletePayment(paymentId, Utils.GetIdFromToken(HttpContext), caseId); 
      return Ok();
    }
  }
}

