using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FE.Pages;

public class VNPayModel : PageModel
{
    private readonly ILogger<VNPayModel> _logger;

    public VNPayModel(ILogger<VNPayModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
