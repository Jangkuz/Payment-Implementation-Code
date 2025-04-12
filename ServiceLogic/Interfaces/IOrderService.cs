using BusinessObject.DTOs;
using BusinessObject.Entities;

namespace ServiceLogic.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<OrderDTO?> GetOrder(string id);
        Task<OrderDTO> CreateOrder(CreateOrderDTO createOrderDTO);
        Task DeleteOrder(string orderId);
    }
}
