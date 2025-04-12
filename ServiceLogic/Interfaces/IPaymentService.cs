using Repository.DTOs;
namespace ServiceLogic;

public interface IPaymentService
{
    Task CreatePaymentAsync(PaymentRequestDTO paymentRequest);
}
