namespace BusinessObject;

public class OrderInfo
{
    public long OrderId { get; set; }
    public long Amount { get; set; }
    public string OrderDesc { get; set; } = default!;

    public DateTime CreatedDate { get; set; }
    public string Status { get; set; } = default!;
}
