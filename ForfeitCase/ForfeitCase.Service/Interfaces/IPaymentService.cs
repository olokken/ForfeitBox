﻿using ForfeitCase.Entities;

namespace ForfeitCase.Service
{
  public interface IPaymentService
  {
    Task CreatePayment(Payment payment);
    Task ConfirmPayment(PaymentConfirmation paymentConfirmation);
    Task DeletePayment(string paymentId, string executorId, string caseId);
  }
}

