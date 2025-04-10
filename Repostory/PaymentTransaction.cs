namespace Repository
{
    public enum PaymentStatus
    {
        Pending,
        Success,
        Failed,
        Cancelled,
    }

    public class PaymentTransaction
    {
        public int Id { get; set; }
        public string TransactionId { get; set; } = default!; // Provider's transaction ID (e.g., PayPal "PAYID-123")
        public string PaymentMethod { get; set; } = default!; // "VNPay", "PayOS", "PayPal"
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "VND"; // Default to VND (adjust as needed)
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending; // "Pending", "Completed", "Failed", "Refunded"
        public string Description { get; set; } = default!; // Optional: e.g., "Order #12345"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } // Null until updated
        public string MetadataJson { get; set; } = default!; // Raw provider response (JSON) for debugging
    }
}
