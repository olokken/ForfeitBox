using System;
using ForfeitBox.Entities;
using ForfeitBox.Repository;

namespace ForfeitBox.Service
{
  public class PaymentService : IPaymentService
  {
    private readonly IPaymentRepository _paymentRepository; 
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

