using BusinessObject;
namespace ServiceLogic;

public interface IPaymentService { 
  Task CreatePaymentAsync(OrderInfo order);
}
