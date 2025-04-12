using System.Net.NetworkInformation;

namespace BusinessObject.Helper;

public class VNPayConfig
{

    public string ReturnUrl { get; set; } = string.Empty;
    public string PaymentUrl { get; set; } = string.Empty ;
    public string TmnCode { get; set; } = string.Empty ;
    public string HashSecret { get; set; } = string.Empty ;
    public string Version { get; set; } = string.Empty ;
}
