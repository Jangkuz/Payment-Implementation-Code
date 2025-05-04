using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FE.Pages;

public class PayPalModel : PageModel
{
    private readonly ILogger<PayPalModel> _logger;

    public PayPalModel(ILogger<PayPalModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
