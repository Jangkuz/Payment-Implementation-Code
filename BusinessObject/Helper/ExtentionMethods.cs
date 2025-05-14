using BusinessObject.DTOs;
using BusinessObject.Entities;
using BusinessObject.ObjectEnum;
using Repository.Entities;
using System;

namespace BusinessObject.Helper;

public static class ExtentionMethods
{
    public static OrderDTO ToOrderDTO(this OrderInfo orderInfo)
    {
        var orderDTO = new OrderDTO
        {
            Id = orderInfo.Id,
            Amount = orderInfo.Amount,
            OrderDesc = orderInfo.OrderDesc,
            Status = orderInfo.Status.ToString(),
            CreatedDate = orderInfo.CreatedDate
        };
        return orderDTO;
    }

    public static OrderInfo ToOrderInfo(this CreateOrderDTO createOrderDTO)
    {
        var order = new OrderInfo
        {
            Amount = createOrderDTO.Amount,
            OrderDesc = createOrderDTO.OrderDesc
        };

        return order;
    }

    public static OrderPayment ToOrderPayment(this PaymentRequestDTO paymentRequestDTO)
    {

        var orderPayment = new OrderPayment
        {
            PaymentMethod = Enum.TryParse<PaymentMethod>(paymentRequestDTO.Method, out var paymentMethod) ? paymentMethod : PaymentMethod.VNPay,
            Amount = paymentRequestDTO.Amount,
            Currency = Enum.TryParse<Currency>(paymentRequestDTO.Currency, out var paymentCurrency) ? paymentCurrency : Currency.VND,
            OrderId = paymentRequestDTO.OrderId
        };
        return orderPayment;
    }
}
