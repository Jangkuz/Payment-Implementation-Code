namespace BusinessObject.DTOs;

public class PaymentRequestDTO
{
    public string Method { get; set; } = string.Empty;       // "VNPay", "PayOS", "PayPal"  
    public decimal Amount { get; set; }
    public string OrderId { get; set; } = string.Empty;      // Your system's order ID  
    public string ReturnUrl { get; set; } = string.Empty;     // Callback URL after payment  
    public string Currency { get; set; } = "VND";
}
