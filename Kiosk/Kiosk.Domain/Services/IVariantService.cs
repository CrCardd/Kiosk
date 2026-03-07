using Kiosk.Domain.Payloads.Models;

namespace Kiosk.Domain.Services;

public interface IVariantService : IBaseService
{
    public Task<VariantPayload?> Create(VariantPayload payload, CancellationToken cancellationToken);
}