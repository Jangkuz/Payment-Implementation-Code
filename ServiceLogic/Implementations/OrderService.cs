using BusinessObject.DTOs;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
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

    public async Task<OrderDTO> CreateOrder(CreateOrderDTO createOrderDTO)
    {
        var createdOrder = _orderRepository.Add(createOrderDTO.ToOrderInfo());
        await _dbContext.SaveChangesAsync();
        return createdOrder.ToOrderDTO();
    }

    public async Task DeleteOrder(string orderId)
    {
        var orderInfo = await _orderRepository.GetByIdAsync(orderId);
        if (orderInfo != null) {
            _orderRepository.Remove(orderInfo);
        }
    }

    public async Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        var orderInfo = await _orderRepository.GetAllAsync();
        return orderInfo.Select(ord => ord.ToOrderDTO());
    }

    public async Task<OrderDTO?> GetOrder(string id)
    {
        var result = new OrderDTO();
        var orderInfo = await _orderRepository.GetByIdAsync(id);
        if (orderInfo != null)
        {
            result = orderInfo.ToOrderDTO();
        }
        return result;
    }
}
