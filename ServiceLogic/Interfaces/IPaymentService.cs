using Repository.Entities;

namespace ServiceLogic;

public interface IPaymentService
{
    Task<string> CreatePayment(OrderPayment paymentRequest);
    Task<string> TestCreatePayment(string orderId);
}
