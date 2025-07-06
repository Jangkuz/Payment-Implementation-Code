using BusinessObject.DTOs;
using BusinessObject.ObjectEnum;
using FE.Const;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FE.Pages;

public class VNPayModel : PageModel
{
    private readonly ILogger<VNPayModel> _logger;
    private readonly IHttpClientFactory _clientFactory;

    public VNPayModel(ILogger<VNPayModel> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }

    [BindProperty]
    public PaymentRequestDTO NewPayment { get; set; } = default!;
    public string? PaymentResult { get; set; } = "";
    public List<OrderDTO> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        if (TempData.TryGetValue("PaymentResult", out object? result))
        {
            PaymentResult = result?.ToString();
            TempData.Keep("PaymentResult"); // Extend persistence
            Console.WriteLine($"PaymentResult: {PaymentResult}");
        }

        var client = _clientFactory.CreateClient(FERouting.ApiName);
        Orders = await client.GetFromJsonAsync<List<OrderDTO>>(FERouting.OrderEndpoint) ?? new();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Failed to create order.");
            return RedirectToPage();
        }

        NewPayment.Method = PaymentMethod.VNPay.ToString();
        NewPayment.Currency = Currency.VND.ToString();

        var client = _clientFactory.CreateClient(FERouting.ApiName);
        var response = await client.PostAsJsonAsync(FERouting.PaymentEndpoint, NewPayment);
        if (response.IsSuccessStatusCode)
        {
            PaymentResult = await response.Content.ReadAsStringAsync();
        }

        TempData["PaymentResult"] = PaymentResult; // Persists for one request
        return RedirectToPage(); // PRG pattern
        //await OnGetAsync(); // Load orders again in case of validation error
        //return RedirectToPage(response.Content);
    }
}
