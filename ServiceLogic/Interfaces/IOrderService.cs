using BusinessObject.Entities;

namespace ServiceLogic.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderInfo>> GetAllOrders();
        Task<OrderInfo?> GetOrder(string id);
        Task<OrderInfo> CreateOrder(OrderInfo orderToCreate);
        Task DeleteOrder(string orderId);
    }
}
