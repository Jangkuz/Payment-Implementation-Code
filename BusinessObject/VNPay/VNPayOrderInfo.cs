namespace BusinessObject;

public class VNPayOrderInfo : OrderInfo
{
    public long PaymentTranId { get; set; }
    public string BankCode { get; set; } = default!;
    public string PayStatus { get; set; } = default!;
}
