using Infra.Enums;

namespace Infra.Dtos
{
    public class ExpiryAlertDto
    {
        public string ProductName { get; set; }
        public StatusType Status { get; set; } // "Expired" or "Expiring Soon"
    }
}
