using ForfeitBox.Entities;

namespace ForfeitBox.Repository
{
  public interface IPaymentRepository
  {
    Task CreatePayment(Payment payment);
    Task ConfirmPayment(PaymentConfirmation paymentConfirmation);
    Task DeletePayment(string paymentId, string executorId, string caseId); 
  }
}

