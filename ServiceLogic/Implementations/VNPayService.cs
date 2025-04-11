using Repository.DTOs;
using Repository.Entities;

namespace ServiceLogic;

public class VNPayService : IPaymentService
{
    OrderPayment currPayment = new();

    public VNPayService() { }

    public Task CreatePaymentAsync(PaymentRequestDTO paymentRequest)
    {
        throw new NotImplementedException();
    }
}
