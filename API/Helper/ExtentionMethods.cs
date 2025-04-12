using API.DTOs;
using BusinessObject.Entities;

namespace API.Helper;

public static class ExtentionMethods
{
    public static OrderDTO ToOrderDTO(this OrderInfo orderInfo)
    {
        var orderDTO = new OrderDTO
        {
            Id = orderInfo.Id,
            Amount = orderInfo.Amount,
            OrderDesc = orderInfo.OrderDesc,
            Status = orderInfo.Status.ToString(),
            CreatedDate = orderInfo.CreatedDate
        };
        return orderDTO;
    }

}
