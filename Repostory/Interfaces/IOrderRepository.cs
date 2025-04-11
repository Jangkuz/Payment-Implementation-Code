using BusinessObject.Entities;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderInfo?> GetByIdAsync(string  orderId);
        Task<IEnumerable<OrderInfo>> GetAllAsync();
    }
}
