using Repository.Entities;

namespace ServiceLogic;

public interface IPaymentService
{
    string CreatePayment(OrderPayment paymentRequest);
    Task<string> TestCreatePayment(string orderId);
}
