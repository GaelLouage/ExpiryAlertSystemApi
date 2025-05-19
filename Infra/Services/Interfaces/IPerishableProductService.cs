using Infra.Dtos;

namespace Infra.Services.Interfaces
{
    public interface IPerishableProductService
    {
        Task<List<ExpiryAlertDto>> GetExpiryAlertsAsync(int daysThreshold = 7);
    }
}
