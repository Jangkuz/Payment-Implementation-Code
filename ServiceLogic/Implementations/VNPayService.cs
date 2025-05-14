using BusinessObject.Helper;
using BusinessObject.ObjectEnum;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Repository.Entities;
using Repository.Interfaces;
using ServiceLogic.Library;

namespace ServiceLogic;

public class VNPayService : IPaymentService
{
    private static readonly string vnp_Version = "vnp_Version";
    private static readonly string vnp_Command = "vnp_Command";
    private static readonly string vnp_TmnCode = "vnp_TmnCode";
    private static readonly string vnp_Amount = "vnp_Amount";
    private static readonly string vnp_CreateDate = "vnp_CreateDate";
    private static readonly string vnp_CurrCode = "vnp_CurrCode";
    private static readonly string vnp_IpAddr = "vnp_IpAddr";
    private static readonly string vnp_Locale = "vnp_Locale";
    private static readonly string vnp_OrderInfo = "vnp_OrderInfo";
    private static readonly string vnp_OrderType = "vnp_OrderType";
    private static readonly string vnp_ReturnUrl = "vnp_ReturnUrl";
    //private static readonly string vnp_ExpireDate = "vnp_ExpireDate";
    private static readonly string vnp_TxnRef = "vnp_TxnRef";

    private readonly IHttpContextAccessor _contextAccessor;
    private readonly VNPayConfig _vnPayConfig;

    private readonly IOrderRepository _orderRepository;

    public VNPayService(IHttpContextAccessor contextAccessor, IOptions<VNPayConfig> nvpPayConfig, IOrderRepository orderRepository)
    {
        _contextAccessor = contextAccessor;
        _vnPayConfig = nvpPayConfig.Value;
        _orderRepository = orderRepository;
    }

    //public Task CreatePaymentAsync(OrderPayment paymentRequest)
    //{
    //    VnPayLibrary vnpay = new VnPayLibrary();

    //    vnpay.AddRequestData(vnp_Version, VnPayLibrary.VERSION);
    //    vnpay.AddRequestData(vnp_Command, "pay");
    //    vnpay.AddRequestData(vnp_TmnCode, _vnPayConfig.TmnCode);
    //    vnpay.AddRequestData(vnp_Command, (paymentRequest.Amount * 100).ToString());
    //    //skip bank code
    //    vnpay.AddRequestData(vnp_CreateDate, DateTime.Now.ToString("yyyyMMddHHmmss"));
    //    vnpay.AddRequestData(vnp_Locale, paymentRequest.Currency.ToString());
    //    vnpay.AddRequestData(vnp_IpAddr, Utils.GetIpAddress(_contextAccessor.HttpContext));
    //    vnpay.AddRequestData(vnp_Locale, "vn"); //hard code vietnamese for testing purposes
    //    vnpay.AddRequestData(vnp_OrderInfo, "Thanh toan don hang: " + paymentRequest.OrderId);
    //    vnpay.AddRequestData(vnp_OrderType, "other");
    //    vnpay.AddRequestData(vnp_ReturnUrl, _vnPayConfig.ReturnUrl);
    //    vnpay.AddRequestData(vnp_TxnRef, paymentRequest.OrderId);

    //    string paymentUrl = vnpay.CreateRequestUrl(_vnPayConfig.PaymentUrl, _vnPayConfig.HashSecret);


    //    throw new NotImplementedException();
    //}

    public async Task<string> TestCreatePayment(string orderId)
    {
        var orderInfo = await _orderRepository.GetByIdAsync(orderId);

        if (orderInfo == null)
        {
            return "Order is null";
        }

        VnPayLibrary vnpay = new VnPayLibrary();

        vnpay.AddRequestData(vnp_Version, VnPayLibrary.VERSION);
        vnpay.AddRequestData(vnp_Command, "pay");
        vnpay.AddRequestData(vnp_TmnCode, _vnPayConfig.TmnCode);
        vnpay.AddRequestData(vnp_Amount, (orderInfo.Amount * 100).ToString());
        //skip bank code
        vnpay.AddRequestData(vnp_CreateDate, DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData(vnp_CurrCode, Currency.VND.ToString());
        vnpay.AddRequestData(vnp_IpAddr, Utils.GetIpAddress(_contextAccessor.HttpContext));
        vnpay.AddRequestData(vnp_Locale, "vn"); //hard code vietnamese for testing purposes
        vnpay.AddRequestData(vnp_OrderInfo, "Thanh toan don hang: " + orderInfo.Id);
        vnpay.AddRequestData(vnp_OrderType, "other");
        vnpay.AddRequestData(vnp_ReturnUrl, _vnPayConfig.ReturnUrl);
        vnpay.AddRequestData(vnp_TxnRef, orderInfo.Id);

        string paymentUrl = vnpay.CreateRequestUrl(_vnPayConfig.PaymentUrl, _vnPayConfig.HashSecret);

        return paymentUrl;

    }

    public async Task<string> CreatePayment(OrderPayment paymentRequest)
    {
        var order = await _orderRepository.GetByIdAsync(paymentRequest.OrderId);
        if (order == null)
        {
            return "Order is null";
        }

        paymentRequest.Amount = order.Amount;
        paymentRequest.Description = order.OrderDesc;

        VnPayLibrary vnpay = new VnPayLibrary();

        vnpay.AddRequestData(vnp_Version, VnPayLibrary.VERSION);
        vnpay.AddRequestData(vnp_Command, "pay");
        vnpay.AddRequestData(vnp_TmnCode, _vnPayConfig.TmnCode);
        vnpay.AddRequestData(vnp_Amount, (paymentRequest.Amount * 100).ToString());
        //skip bank code
        vnpay.AddRequestData(vnp_CreateDate, DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData(vnp_CurrCode, paymentRequest.Currency.ToString());
        vnpay.AddRequestData(vnp_IpAddr, Utils.GetIpAddress(_contextAccessor.HttpContext));
        vnpay.AddRequestData(vnp_Locale, "vn"); //hard code vietnamese for testing purposes
        vnpay.AddRequestData(vnp_OrderInfo, "Thanh toan don hang: " + paymentRequest.OrderId);
        vnpay.AddRequestData(vnp_OrderType, "other");
        vnpay.AddRequestData(vnp_ReturnUrl, _vnPayConfig.ReturnUrl);
        vnpay.AddRequestData(vnp_TxnRef, paymentRequest.OrderId);

        string paymentUrl = vnpay.CreateRequestUrl(_vnPayConfig.PaymentUrl, _vnPayConfig.HashSecret);

        return paymentUrl;
    }
}
