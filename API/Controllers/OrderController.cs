using BusinessObject.DTOs;
using BusinessObject.Helper;
using Microsoft.AspNetCore.Mvc;
using ServiceLogic.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            var orderInfos = await _orderService.GetAllOrders();
            return orderInfos.Select(ord => ord.ToOrderDTO());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrderDTO?> Get(string id)
        {
            var orderInfo = await _orderService.GetOrder(id);
            if (orderInfo != null)
            {
                return orderInfo.ToOrderDTO();
            }
            return null;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task Post([FromBody] CreateOrderDTO value)
        {
            await _orderService.CreateOrder(value.ToOrderInfo());
        }

        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _orderService.DeleteOrder(id);
        }
    }
}
