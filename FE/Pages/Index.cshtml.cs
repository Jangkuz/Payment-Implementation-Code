using BusinessObject.DTOs;
using FE.Const;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _clientFactory;

    public IndexModel(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [BindProperty]
    public CreateOrderDTO NewOrder { get; set; } = new();

    public List<OrderDTO> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        var client = _clientFactory.CreateClient(FERouting.ApiName);
        Orders = await client.GetFromJsonAsync<List<OrderDTO>>(FERouting.OrderEndpoint) ?? new();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _clientFactory.CreateClient(FERouting.ApiName);
        var response = await client.PostAsJsonAsync(FERouting.OrderEndpoint, NewOrder);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage();
        }

        ModelState.AddModelError("", "Failed to create order.");
        await OnGetAsync(); // Load orders again in case of validation error
        return Page();
    }
}

//public class CreateOrderDto
//{
//    public int Amount { get; set; }
//    public string OrderDesc { get; set; } = string.Empty;
//}

//public class OrderDto
//{
//    public string Id { get; set; } = string.Empty;
//    public int Amount { get; set; }
//    public string OrderDesc { get; set; } = string.Empty;
//    public string? Status { get; set; }

//    public DateTime? CreatedDate { get; set; }
//}
