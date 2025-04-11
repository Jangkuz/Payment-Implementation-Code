using BusinessObject.Entities;
using BusinessObject.Enum;
using Repository.Enum;

namespace Repository.Entities;

public class OrderPayment:Entity<string>
{
    public string TransactionId { get; set; } = default!; // Provider's transaction ID (e.g., PayPal "PAYID-123")
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.VNPay; // "VNPay", "PayOS", "PayPal"
    public decimal Amount { get; set; }
    public Currency Currency { get; set; } = Currency.VND; // Default to VND (adjust as needed)
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending; // "Pending", "Completed", "Failed", "Refunded"
    public string Description { get; set; } = default!; // Optional: e.g., "Order #12345"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    //public DateTime? UpdatedAt { get; set; } // Null until updated
    //public string MetadataJson { get; set; } = default!; // Raw provider response (JSON) for debugging

    public string OrderId { get; set; } = default!;
    public virtual OrderInfo OrderInfo { get; set; } = default!;
}
