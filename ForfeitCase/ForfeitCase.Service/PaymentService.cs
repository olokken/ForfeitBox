using System;
using ForfeitCase.Entities;
using ForfeitCase.Repository;

namespace ForfeitCase.Service
{
  public class PaymentService : IPaymentService
  {
    private IPaymentRepository _paymentRepository; 
    public PaymentService(IPaymentRepository paymentRepository)
    {
      _paymentRepository = paymentRepository; 
    }

    public Task ConfirmPayment(PaymentConfirmation paymentConfirmation)
    {
      return _paymentRepository.ConfirmPayment(paymentConfirmation); 
    }

    public Task CreatePayment(Payment payment)
    {
      return _paymentRepository.CreatePayment(payment); 
    }

    public Task DeletePayment(string paymentId, string executorId, string caseId)
    {
      return _paymentRepository.DeletePayment(paymentId, executorId, caseId); 
    }
  }
}

