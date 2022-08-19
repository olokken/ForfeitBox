using System.Data;
using Dapper;
using ForfeitCase.Entities;

namespace ForfeitCase.Repository
{
  public class PaymentRepository : IPaymentRepository
  {
    private IDbConnection _dbConnection;
    public PaymentRepository(IDbConnection dbConnection)
    {
      _dbConnection = dbConnection;
    }

    public async Task ConfirmPayment(PaymentConfirmation paymentConfirmation)
    {
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, paymentConfirmation.ExecutorId, paymentConfirmation.CaseId);
      var sql = "INSERT INTO payment_confirmation (PaymentConfirmationId, PaymentId, ExecutorId, CaseId) values (@PaymentConfirmationId, @PaymentId, @ExecutorId, @CaseId)";
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(sql, paymentConfirmation);
      }
    }

    public async Task CreatePayment(Payment payment)
    {
      var sql = "INSERT INTO payment (PaymentId, Sum, CaseId, ExecutorId) values (@PaymentId, @Sum, @CaseId, @ExecutorId)";
      await _dbConnection.ExecuteAsync(sql, payment);
    }

    public async Task DeletePayment(string paymentId, string executorId, string caseId)
    {
      bool isAdmin = await UserCaseRepository.IsAdmin(_dbConnection, executorId, caseId);
      var sql = "DELETE FROM payment where PaymentId = @PaymentId";
      //Or is executor in stored payment(?)
      if (isAdmin)
      {
        await _dbConnection.ExecuteAsync(sql, new { PaymentId = paymentId });
      }
    }
  }
}

