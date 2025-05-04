using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FE.Pages;

public class PayOSModel : PageModel
{
    private readonly ILogger<PayOSModel> _logger;

    public PayOSModel(ILogger<PayOSModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
