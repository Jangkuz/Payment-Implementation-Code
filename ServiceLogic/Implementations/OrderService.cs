using BusinessObject.Entities;
using Repository;
using Repository.Interfaces;
using ServiceLogic.Interfaces;

namespace ServiceLogic;

public class OrderService : IOrderService
{
    private readonly AppDbContext _dbContext;
    private readonly IOrderRepository _orderRepository;

    public OrderService(
        AppDbContext dbContext,
        IOrderRepository orderRepository)
    {
        _dbContext = dbContext;
        _orderRepository = orderRepository;
    }

    public async Task<OrderInfo> CreateOrder(OrderInfo orderToCreate)
    {
        var createdOrder = _orderRepository.Add(orderToCreate);
        await _dbContext.SaveChangesAsync();
        return createdOrder;
    }

    public async Task DeleteOrder(string orderId)
    {
        var orderInfo = await _orderRepository.GetByIdAsync(orderId);
        if (orderInfo != null)
        {
            _orderRepository.Remove(orderInfo);
        }
    }

    public async Task<IEnumerable<OrderInfo>> GetAllOrders()
    {
        var orderInfo = await _orderRepository.GetAllAsync();
        return orderInfo;
    }

    public async Task<OrderInfo?> GetOrder(string id)
    {
        OrderInfo? result = null;
        var orderInfo = await _orderRepository.GetByIdAsync(id);
        if (orderInfo != null)
        {
            result = orderInfo;
        }
        return result;
    }
}
