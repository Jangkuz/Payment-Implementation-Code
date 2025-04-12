using BusinessObject.Entities;

namespace API.DTOs;

public class CreateOrderDTO
{
    public long Amount { get; set; }
    public string OrderDesc { get; set; } = default!;
    public OrderInfo ToOrderInfo()
    {
        var order = new OrderInfo
        {
            Amount = Amount,
            OrderDesc = OrderDesc
        };

        return order;
    }
}
