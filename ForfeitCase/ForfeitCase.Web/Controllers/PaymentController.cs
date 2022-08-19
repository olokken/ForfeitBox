using ForfeitCase.Entities;
using ForfeitCase.Service;
using ForfeitCase.Web.Dtos.Payment;
using Microsoft.AspNetCore.Mvc;

namespace ForfeitCase.Web.Controllers
{
  [ApiController]
  [Route("api/Case/[controller]")]
  public class PaymentController : ControllerBase
  {
    private IPaymentService _paymentService;
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
        CaseId = createPaymentDto.CaseId,
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
        CaseId = confirmPaymentDto.CaseId,
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

