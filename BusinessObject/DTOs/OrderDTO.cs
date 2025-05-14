namespace BusinessObject.DTOs;

public class OrderDTO
{
    public string? Id { get; set; }
    public long Amount { get; set; }
    public string OrderDesc { get; set; } = default!;
    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }
}
