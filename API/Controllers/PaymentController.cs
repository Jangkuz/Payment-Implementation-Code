using BusinessObject.DTOs;
using BusinessObject.Helper;
using BusinessObject.ObjectEnum;
using Microsoft.AspNetCore.Mvc;
using ServiceLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        //// GET: api/<TransactionController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<TransactionController>/5
        [HttpGet("{orderId}")]
        public async Task<string> Get(string orderId)
        {
            var result = await _paymentService.TestCreatePayment(orderId);
            return result;
        }

        //// POST api/<TransactionController>
        [HttpPost]
        public async Task<string> Post([FromBody] PaymentRequestDTO paymentRequestDTO)
        {
            var orderPayment = paymentRequestDTO.ToOrderPayment();
            string result = "Invalid link";
            switch (orderPayment.PaymentMethod)
            {
                case PaymentMethod.VNPay:
                    result = await _paymentService.CreatePayment(orderPayment);
                    break;

                case PaymentMethod.PayOS:
                    break;
                case PaymentMethod.PayPal:
                    break;
                default:
                    result = await _paymentService.CreatePayment(orderPayment);
                    break;
            }
            return result;
        }

        //// PUT api/<TransactionController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TransactionController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
