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
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly VNPayConfig _vnPayConfig;

    private readonly IOrderRepository _orderRepository;

    public VNPayService(IHttpContextAccessor contextAccessor, IOptions<VNPayConfig> nvpPayConfig, IOrderRepository orderRepository)
    {
        _contextAccessor = contextAccessor;
        _vnPayConfig = nvpPayConfig.Value;
        _orderRepository = orderRepository;
    }

    public async Task<string> TestCreatePayment(string orderId)
    {
        var orderInfo = await _orderRepository.GetByIdAsync(orderId);

        if (orderInfo == null)
        {
            return "Order is null";
        }

        VnPayLibrary vnpay = new VnPayLibrary();

        vnpay.AddRequestData(VNPayRequestParam.vnp_Version, VnPayLibrary.VERSION);
        vnpay.AddRequestData(VNPayRequestParam.vnp_Command, "pay");
        vnpay.AddRequestData(VNPayRequestParam.vnp_TmnCode, _vnPayConfig.TmnCode);
        vnpay.AddRequestData(VNPayRequestParam.vnp_Amount, (orderInfo.Amount * 100).ToString());
        //skip bank code
        vnpay.AddRequestData(VNPayRequestParam.vnp_CreateDate, DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData(VNPayRequestParam.vnp_CurrCode, Currency.VND.ToString());
        vnpay.AddRequestData(VNPayRequestParam.vnp_IpAddr, Utils.GetIpAddress(_contextAccessor.HttpContext));
        vnpay.AddRequestData(VNPayRequestParam.vnp_Locale, "vn"); //hard code vietnamese for testing purposes
        vnpay.AddRequestData(VNPayRequestParam.vnp_OrderInfo, "Thanh toan don hang: " + orderInfo.Id);
        vnpay.AddRequestData(VNPayRequestParam.vnp_OrderType, "other");
        vnpay.AddRequestData(VNPayRequestParam.vnp_ReturnUrl, _vnPayConfig.ReturnUrl);
        vnpay.AddRequestData(VNPayRequestParam.vnp_TxnRef, orderInfo.Id);

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

        vnpay.AddRequestData(VNPayRequestParam.vnp_Version, VnPayLibrary.VERSION);
        vnpay.AddRequestData(VNPayRequestParam.vnp_Command, "pay");
        vnpay.AddRequestData(VNPayRequestParam.vnp_TmnCode, _vnPayConfig.TmnCode);
        vnpay.AddRequestData(VNPayRequestParam.vnp_Amount, (paymentRequest.Amount * 100).ToString());
        //skip bank code
        vnpay.AddRequestData(VNPayRequestParam.vnp_CreateDate, DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData(VNPayRequestParam.vnp_CurrCode, paymentRequest.Currency.ToString());
        vnpay.AddRequestData(VNPayRequestParam.vnp_IpAddr, Utils.GetIpAddress(_contextAccessor.HttpContext));
        vnpay.AddRequestData(VNPayRequestParam.vnp_Locale, "vn"); //hard code vietnamese for testing purposes
        vnpay.AddRequestData(VNPayRequestParam.vnp_OrderInfo, "Thanh toan don hang: " + paymentRequest.OrderId);
        vnpay.AddRequestData(VNPayRequestParam.vnp_OrderType, "other");
        vnpay.AddRequestData(VNPayRequestParam.vnp_ReturnUrl, _vnPayConfig.ReturnUrl);
        vnpay.AddRequestData(VNPayRequestParam.vnp_TxnRef, paymentRequest.OrderId);

        string paymentUrl = vnpay.CreateRequestUrl(_vnPayConfig.PaymentUrl, _vnPayConfig.HashSecret);

        return paymentUrl;
    }
}
