using BusinessObject.Entities;
using Repository.Interfaces;

namespace Repository.Implements;

public class OrderRepository : Repository<OrderInfo, string>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}
