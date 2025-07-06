using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FE.Pages.Returned
{
    public class VnPayReturnModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Vnp_Amount { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Vnp_BankCode { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_BankTranNo { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_CardType { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_OrderInfo { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_PayDate { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_ResponseCode { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_TmnCode { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_TransactionNo { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_TransactionStatus { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_TxnRef { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string Vnp_SecureHash { get; set; } = string.Empty;

        //TODO: Add checksum api
        public void OnGet()
        {
        }
    }
}
