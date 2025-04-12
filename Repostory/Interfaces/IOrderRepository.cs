using BusinessObject.Entities;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderInfo?> GetByIdAsync(string orderId);
        Task<IEnumerable<OrderInfo>> GetAllAsync();
        OrderInfo Add(OrderInfo entity);
        void Update(OrderInfo entity);
        void Remove(OrderInfo entity);

    }
}
