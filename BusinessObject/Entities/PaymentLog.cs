﻿//namespace Repository.Entities;

//public class PaymentLog
//{
//    public int Id { get; set; }
//    public int PaymentId { get; set; }                // Foreign key to Payment  
//    public virtual OrderPayment? Payment { get; set; }              // Navigation property  
//    public string EventType { get; set; } = default!;            // e.g., "WebhookReceived", "StatusUpdated"  
//    public string Message { get; set; } = default!;               // e.g., "Payment completed via PayPal"  
//    public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
//    public string DetailsJson { get; set; } = default!;           // Additional context (JSON)  
//}
