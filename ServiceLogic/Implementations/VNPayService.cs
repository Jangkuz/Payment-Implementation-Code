using Repository;

namespace ServiceLogic;

public class VNPayService : IPaymentService
{
    PaymentTransaction currPayment = new();

    public VNPayService() { }
}
