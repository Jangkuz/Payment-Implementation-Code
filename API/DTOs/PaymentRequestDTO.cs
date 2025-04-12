namespace API.DTOs;

public class PaymentRequestDTO
{
    public string Method { get; set; } = default!;       // "VNPay", "PayOS", "PayPal"  
    public decimal Amount { get; set; }
    public string OrderId { get; set; } = default!;      // Your system's order ID  
    public string ReturnUrl { get; set; } = default!;     // Callback URL after payment  
    public string Currency { get; set; } = "VND";
}
