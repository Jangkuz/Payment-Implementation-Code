using BusinessObject.DTOs;
using BusinessObject.Enum;
using Repository.Entities;

namespace BusinessObject.Entities;

public class OrderInfo : Entity<string>
{
    //public string OrderId { get; set; } = DateTime.Now.Ticks; // Unique Id to work with Payment System
    //Currently: Due Ids => overengineering
    public long Amount { get; set; }
    public string OrderDesc { get; set; } = default!;
    public OrderStatus Status { get; set; } = default!;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public virtual ICollection<OrderPayment> Payments { get; set; } = new List<OrderPayment>();

    public OrderDTO ToOrderDTO()
    {
        var orderDTO = new OrderDTO
        {
            Id = Id,
            Amount = Amount,
            OrderDesc = OrderDesc,
            Status = Status.ToString(),
            CreatedDate = CreatedDate
        };

        return orderDTO;
    }

}
